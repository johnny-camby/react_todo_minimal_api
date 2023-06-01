using BusinessLogic;
using BusinessLogic.CQRS.Todos.Commands.Create;
using BusinessLogic.CQRS.Todos.Commands.Delete;
using BusinessLogic.CQRS.Todos.Commands.Update;
using BusinessLogic.CQRS.Todos.Queries.GetDetails;
using BusinessLogic.CQRS.Todos.Queries.GetList;
using Data.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniValidation;

namespace TodoApi
{
    public static class StartUpExtensions
    {
        public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddCors();

            builder.Services.AddBusinessLogicServices();
            builder.Services.AddPersistenceServices(builder.Configuration);

            return builder.Build();
        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(p => p.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod());

            app.TodoEndPoints();

            return app;
        }

        public static void TodoEndPoints(this WebApplication app)
        {
            app.MapGet("/todos", (IMediator mediator) => mediator.Send(new GetTodoListQueryRequest()))
                .Produces<TodoList[]>(StatusCodes.Status200OK);

            app.MapGet("/todo/{id:int}", async (int id, IMediator mediator) =>
            {
                var todoQuery = new GetTodoDetailQueryRequest() { Id = id };
                var todo = mediator.Send(todoQuery);

                if (todo != null)
                    return Results.Problem($"Todo with ID {id} not found.", statusCode: 404);
                return Results.Ok(todo);
            })
                .ProducesProblem(404)
                .Produces<TodoDetail>(StatusCodes.Status200OK);

            app.MapPost("/todos", async ([FromBody] TodoCreateCommandRequest todo, IMediator mediator) =>
            {
                if (!MiniValidator.TryValidate(todo, out var errors))
                    return Results.ValidationProblem(errors);
                var id = await mediator.Send(todo);

                ///////////////// ---- needs to be changed ----- ////////////////////////////////
                var todoQuery = new GetTodoDetailQueryRequest() { Id = id };
                var data = mediator.Send(todoQuery);
                /////////////////////////////////////////////////

                return Results.Created($"/todo/{id}", data);
            })
                .ProducesValidationProblem()
                .Produces<TodoDetail>(StatusCodes.Status201Created);

            app.MapPut("/todos", async ([FromBody] TodoUpdateCommandRequest todo, IMediator mediator) =>
            {
                if (!MiniValidator.TryValidate(todo, out var errors))
                    return Results.ValidationProblem(errors);

                var todoQuery = new GetTodoDetailQueryRequest() { Id = todo.Id };
                var todoDetail = await mediator.Send(todoQuery);

                if (todoDetail == null)
                    return Results.Problem($"Todo with Id {todo.Id} not found", statusCode: 404);

                var data = mediator.Send(todo);
                return Results.Ok(data);
            })
                .ProducesValidationProblem()
                .ProducesProblem(404)
                .Produces<TodoDetail>(StatusCodes.Status200OK);

            app.MapDelete("/todos/{id:int}", async (int id, IMediator mediator) =>
            {
                var todoQuery = new GetTodoDetailQueryRequest() { Id = id };
                var todoToDetail = await mediator.Send(todoQuery);

                if (todoToDetail == null)
                    return Results.Problem($"Tod with Id {id} not found", statusCode: 404);

                var deleteCustomerCommand = new TodoDeleteCommandRequest() { Id = id };
                await mediator.Send(deleteCustomerCommand);
                return Results.Ok();
            })
                .ProducesProblem(404)
                .Produces(StatusCodes.Status200OK);
        }

        public static async Task ResetDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            try
            {
                var context = scope.ServiceProvider.GetService<TodoDbContext>();
                if (context != null)
                {
                    await context.Database.EnsureDeletedAsync();
                    await context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger>();
                logger.LogError(ex, "An error occurred while migrating the database.");
            }
        }
    }
}

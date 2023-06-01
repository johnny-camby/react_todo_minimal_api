using BusinessLogic.Exceptions;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Update
{
    public class TodoUpdateCommandHandler : IRequestHandler<TodoUpdateCommandRequest>
    {
        private readonly IDataRepository<TodoEntity> _todoRepository;
        public TodoUpdateCommandHandler(IDataRepository<TodoEntity> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(TodoUpdateCommandRequest request, CancellationToken cancellationToken)
        {
            var todoToUpdate = await _todoRepository.GetAsync(request.Id);
            
            if (todoToUpdate == null)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }

            todoToUpdate = new TodoEntity 
            {
                Id = request.Id,
                DeadLine = request.DeadLine,
                IsDone = request.IsDone,
                //IsDone = true,
                Text = request.Text
            };

            await _todoRepository.UpdateAsync(todoToUpdate);
            return Unit.Value;
        }
    }
}

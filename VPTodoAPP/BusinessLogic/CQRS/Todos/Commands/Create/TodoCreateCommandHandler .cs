

using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Create
{
    public class TodoCreateCommandHandler : IRequestHandler<TodoCreateCommandRequest, int>
    {
        private readonly IDataRepository<TodoEntity> _todoRepository;
        public TodoCreateCommandHandler(IDataRepository<TodoEntity> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<int> Handle(TodoCreateCommandRequest request, CancellationToken cancellationToken)
        {
            TodoEntity todo = new()
            {
                DeadLine = request.DeadLine,
                IsDone = request.IsDone,
                Text = request.Text,
            };

            todo = await _todoRepository.AddAsync(todo);
            return todo.Id;
        }
    }
}


using BusinessLogic.Exceptions;
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Delete
{
    public class TodoDeleteCommandHandler : IRequestHandler<TodoDeleteCommandRequest>
    {
        private readonly IDataRepository<TodoEntity> _todoRepository;
        public TodoDeleteCommandHandler(IDataRepository<TodoEntity> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<Unit> Handle(TodoDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            var todoToDelete = await _todoRepository.GetAsync(request.Id);

            if (todoToDelete == null)
            {
                throw new NotFoundException(nameof(TodoEntity), request.Id);
            }

            await _todoRepository.DeleteAsync(todoToDelete);
            return Unit.Value;
        }
    }
}

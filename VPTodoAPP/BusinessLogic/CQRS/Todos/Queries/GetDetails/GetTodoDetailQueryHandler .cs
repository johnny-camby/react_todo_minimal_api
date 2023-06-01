
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Todos.Queries.GetDetails
{
    public class GetTodoDetailQueryHandler : IRequestHandler<GetTodoDetailQueryRequest, TodoDetail>
    {
        private readonly IDataRepository<TodoEntity> _todoRepository;
        public GetTodoDetailQueryHandler(IDataRepository<TodoEntity> todoRepository)
        {
            _todoRepository = todoRepository;
        }

        public async Task<TodoDetail> Handle(GetTodoDetailQueryRequest request, CancellationToken cancellationToken)
        {
            var todo = await _todoRepository.GetAsync(request.Id);

            return new TodoDetail 
            {
                Id = todo.Id,
                DeadLine = todo.DeadLine,
                IsDone = todo.IsDone,
                Text = todo.Text
            };
        }
    }
}

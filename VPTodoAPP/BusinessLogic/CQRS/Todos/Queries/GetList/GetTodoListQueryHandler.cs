
using Data.Repository.Entities;
using Data.Repository.Interfaces;
using MediatR;

namespace BusinessLogic.CQRS.Todos.Queries.GetList
{
    public class GetTodoListQueryHandler : IRequestHandler<GetTodoListQueryRequest, List<TodoList>>
    {
        private readonly IDataRepository<TodoEntity> _todoRepository;
        public GetTodoListQueryHandler(IDataRepository<TodoEntity> todoRepository) 
        {
            _todoRepository = todoRepository;
        }

        public async Task<List<TodoList>> Handle(GetTodoListQueryRequest request, CancellationToken cancellationToken)
        {
            var todos = await _todoRepository.GetAsync();

            return todos.Select(todo => new TodoList 
            {
                Id = todo.Id,
                DeadLine = todo.DeadLine,
                IsDone = todo.IsDone,
                Text = todo.Text
            }).ToList();
        }
    }    
}

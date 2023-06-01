

using MediatR;

namespace BusinessLogic.CQRS.Todos.Queries.GetList
{
    public class GetTodoListQueryRequest : IRequest<List<TodoList>>
    {}
}

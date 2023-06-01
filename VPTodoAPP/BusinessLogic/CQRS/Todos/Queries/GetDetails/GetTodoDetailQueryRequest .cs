
using MediatR;

namespace BusinessLogic.CQRS.Todos.Queries.GetDetails
{
    public class GetTodoDetailQueryRequest : IRequest<TodoDetail>
    {
        public int Id { get; set; }
    }
}

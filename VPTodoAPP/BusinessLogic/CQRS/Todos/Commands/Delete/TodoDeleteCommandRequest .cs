
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Delete
{
    public class TodoDeleteCommandRequest : IRequest
    {
        public int Id { get; set; }
    }
}

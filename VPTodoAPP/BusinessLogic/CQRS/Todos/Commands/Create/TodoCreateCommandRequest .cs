
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Create
{
    public class TodoCreateCommandRequest : IRequest<int>
    {
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string DeadLine { get; set; }
    }
}

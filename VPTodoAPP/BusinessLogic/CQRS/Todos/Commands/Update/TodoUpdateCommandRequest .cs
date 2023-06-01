
using MediatR;

namespace BusinessLogic.CQRS.Todos.Commands.Update
{
    public class TodoUpdateCommandRequest : IRequest
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string DeadLine { get; set; }
    }
}

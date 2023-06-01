
namespace BusinessLogic.CQRS.Todos.Queries.GetDetails
{
    public class TodoDetail
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string DeadLine { get; set; }
    }
}

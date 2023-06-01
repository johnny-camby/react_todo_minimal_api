
namespace BusinessLogic.CQRS.Todos.Queries.GetList
{
    public class TodoList
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; }
        public string DeadLine { get; set; }
    }
}

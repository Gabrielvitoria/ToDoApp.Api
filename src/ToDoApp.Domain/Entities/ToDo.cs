namespace ToDoApp.Domain.Entities
{
    public class ToDo
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool isCompleted { get; set; }
    }
}

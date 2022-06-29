using ToDoApplication.Models;

namespace ToDoApplication.ViewModel
{
    public class TodoViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Status { get; set; }
        public string? Date { get; set; }
        public SelectedTodos TodoList { get; set; }
    }
}

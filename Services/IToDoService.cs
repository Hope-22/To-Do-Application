using ToDoApplication.Models;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Services
{
    public interface IToDoService
    {
        public List<TodoViewModel> AllList { get; }

        public Task<int> Insert(ToDo toDo);
        public void Update(ToDo toDo);
        public void Delete(ToDo todo);
        public void DeleteSelected(List<ToDo> todo);
        public Task<ToDo> GetById(int id);
        public Task<List<TodoViewModel>> Search(string word);

    }
}

using ToDoApplication.Models;

namespace ToDoApplication.Repository
{
    public interface IRepository
    {
        public Task<List<ToDo>> GetAllData();
        public void UpdateDataToDb(ToDo todo);
        public Task<bool> DeleteDataFromDb(ToDo todo);
        public Task<int> AddTodoToDb(ToDo todo);
        public Task<ToDo> GetDataById(int id);
        public Task<List<ToDo>> SearchList(string name);
        public Task<bool> DeleteSelectedTodos(List<ToDo> todo);
    }
}

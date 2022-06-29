using Microsoft.EntityFrameworkCore;
using ToDoApplication.Data;
using ToDoApplication.Models;

namespace ToDoApplication.Repository
{
    public class Repository : IRepository
    {
        private readonly TodoContext _context;

        public Repository(TodoContext context)
        {
            _context = context;
        }

        public async Task<int> AddTodoToDb(ToDo todo)
        {
            todo.Status = 0;

            await _context.Todos.AddAsync(todo);
            await _context.SaveChangesAsync();

            return todo.Id;
        }
        public async Task<bool> DeleteDataFromDb(ToDo todo)
        {
            _context.Todos.Remove(todo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteSelectedTodos(List<ToDo> todo)
        {
            _context.Todos.RemoveRange(todo);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<ToDo>> SearchList(string name)
        {
            var todos = await _context.Todos.Where(x => x.Name.Contains(name) || x.Date.ToString().Contains(name)).ToListAsync();

            return todos;
        }

        public async Task<List<ToDo>> GetAllData()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<ToDo> GetDataById(int id)
        {
            ToDo? todo = await _context.Todos.FirstOrDefaultAsync(e => e.Id == id);

            return todo;
        }

        public void UpdateDataToDb(ToDo todo)
        {
            _context.Todos.Update(todo);
            _context.SaveChanges();
        }

        //public void UpdateStatus(ToDo todo)
        //{
        //    _context.Todos.Update(todo);
        //}

    }
}

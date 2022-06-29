using ToDoApplication.Models;
using ToDoApplication.Repository;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Services
{
    public class ToDoService : IToDoService
    {
        private readonly IRepository _repo;

        public ToDoService(IRepository repo)
        {
            _repo = repo;
        }
        public List<TodoViewModel> AllList
        {
            get
            {
                var list = new List<TodoViewModel>();
                var todoList = _repo.GetAllData().Result;

                //Map the todomdel to todoviewmodel
                if (todoList != null)
                {
                    foreach (var todo in todoList)
                    {
                        list.Add(
                            new TodoViewModel()
                            {
                                Id = todo.Id,
                                Name = todo.Name,
                                Status = todo.Status,
                                Date = todo.Date.ToShortDateString()
                            }
                        );
                    }
                }

                return list;
            }
        }

        public void Delete(ToDo todo)
        {
            _repo.DeleteDataFromDb(todo);
        }

        public void DeleteSelected(List<ToDo> todo)
        {
            _repo.DeleteSelectedTodos(todo);
        }

        public async Task<ToDo> GetById(int id)
        {
            var todo = await _repo.GetDataById(id);
            return todo;
        }

        public async Task<int> Insert(ToDo toDo)
        {
            var id = await _repo.AddTodoToDb(toDo);

            if (id != 0)
                return id;

            else return 0;

        }

        public async Task<List<TodoViewModel>> Search(string word)
        {
            var todos = await _repo.SearchList(word);
            var list = new List<TodoViewModel>();

            if (todos != null)
            {
                foreach (var todo in todos)
                {
                    list.Add(
                        new TodoViewModel()
                        {
                            Id = todo.Id,
                            Name = todo.Name,
                            Status = todo.Status,
                            Date = todo.Date.ToShortDateString()
                        }
                    );
                }
            }

            return list;
        }

        public void Update(ToDo todo)
        {
            _repo.UpdateDataToDb(todo);
        }


    }
}

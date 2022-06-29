using Microsoft.AspNetCore.Mvc;
using ToDoApplication.Models;
using ToDoApplication.Services;
using ToDoApplication.ViewModel;

namespace ToDoApplication.Controllers
{
    public class ToDoController : Controller
    {
        private readonly IToDoService _todo;

        public ToDoController(IToDoService toDoService)
        {
            _todo = toDoService;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ToDo obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            int res = await _todo.Insert(obj);

            if (res > 0)
            {
                TempData["success"] = "Todo was addedd successfully";
                return RedirectToAction("index", "Home");
            }

            TempData["error"] = "Action was not successful";
            return View(obj);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int id)
        {
            if (id == 0)
                return RedirectToAction("NotFoundPage", "Home");

            var data = await _todo.GetById(id);

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(ToDo obj)
        {
            if (!ModelState.IsValid)
                return View(obj);

            _todo.Update(obj);
            TempData["success"] = "List updated successfully";

            return RedirectToAction("index", "Home");

            //return View(obj);
        }


        [HttpPost]
        public async Task<IActionResult> Delete(List<TodoViewModel> objs)
        {
            var todoList = new List<ToDo>();

            foreach (var obj in objs)
            {
                if (obj.TodoList.Selected)
                {
                    var singleTodo = await _todo.GetById(obj.Id);
                    todoList.Add(singleTodo);
                }
            }

            _todo.DeleteSelected(todoList);

            TempData["success"] = "Deleted successfully";

            return RedirectToAction("index", "Home");
        }


        [HttpPost]
        public async Task<IActionResult> Search(ToDo obj)
        {
            var result = await _todo.Search(obj.Name);

            if (result.Count == 0)
                TempData["error"] = "Not Found";
            else
                TempData["success"] = "Search Completed Successfully";

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> StatusUpdate(int Id)
        {
            var todo = await _todo.GetById(Id);
            todo.Status = 1;

            _todo.Update(todo);

            return RedirectToAction("index", "Home");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly TodoService _todoService;
        public TodoController(TodoContext context, TodoService todoService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
        }
        // GET request ": todo
        public IActionResult Index()
        {
            // geting user id
            string? userId = HttpContext.Session.GetString("UserId");
            if(string.IsNullOrEmpty(userId))
            {
                userId = Guid.NewGuid().ToString();
                HttpContext.Session.SetString("UserId", userId);
                string? userIp = HttpContext.Connection.RemoteIpAddress?.ToString();
            HttpContext.Items["UserIP"] = userIp;
            int requestCount = HttpContext.Items.ContainsKey("RequestCount") ? (int)HttpContext.Items["RequestCount"]! : 0;
            requestCount++;
            HttpContext.Items["RequestCount"] = requestCount;
            ViewBag.UserIP = userIp;
            ViewBag.RequestCount = requestCount;
            }
            var todos = _todoService.GetTodosAdoNet();
            ViewBag.UserId = userId;
            foreach (var todo in todos)
            {
                todo.Title = $"[{userId[..8]}] {todo.Title}";
            }
            return View(todos);
            

        }
        // GET todo/create
        public IActionResult Create()
        {
            return View();
        }
        // post: create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(todo);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "todo created successfully";
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
        //  GET: Taks/edit
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        // get to delete

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var todo = _context.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }
        // post for delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }    

        [HttpPost]
public IActionResult ToggleTheme()
{
    bool isDark = HttpContext.Request.Cookies["Theme"] != "dark";
    var cookieOptions = new CookieOptions
    {
        Expires = DateTime.Now.AddDays(30), 
        HttpOnly = false, 
        Secure = true 
    };
    HttpContext.Response.Cookies.Append("Theme", isDark ? "dark" : "light", cookieOptions);
    
    return RedirectToAction(nameof(Index));
}
    }
}
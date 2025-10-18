using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using TodoApp.Data;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;
        private readonly TodoService _todoService;
        private readonly IMemoryCache _cache;

        public TodoController(TodoContext context, TodoService todoService, IMemoryCache cache)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _todoService = todoService ?? throw new ArgumentNullException(nameof(todoService));
            _cache = cache;
        }
        // GET request ": todo
        public IActionResult Index(string? filter = null)
        {
            // geting user id
            string userIp = HttpContext.Connection.RemoteIpAddress?.ToString() switch
            {
                "::1" => "localhost (IPv6)",
                "127.0.0.1" => "localhost (IPv4)",
                var ip => ip ?? "Unknown"
            };
            HttpContext.Items["UserIP"] = userIp;
            int requestCount = HttpContext.Items.ContainsKey("RequestCount") ? (int)HttpContext.Items["RequestCount"]! : 0;
            requestCount++;
            HttpContext.Items["RequestCount"] = requestCount;
            ViewBag.UserIP = userIp;
            ViewBag.RequestCount = requestCount;
             string cacheKey = $"TotalTodos_{User.Identity!.Name}";
            if (!_cache.TryGetValue(cacheKey, out int totalTodos))
            {
                totalTodos = _context.Todos.Count(t => t.UserId == User.Identity!.Name);
                _cache.Set(cacheKey, totalTodos, TimeSpan.FromMinutes(5));
            }

             var todos = _todoService.GetTodosAdoNet()
                .Where(t => t.UserId == User.Identity!.Name)
                .AsEnumerable();

            if (filter == "completed")
            {
                todos = todos.Where(t => t.IsCompleted);
            }
            else if (filter == "pending")
            {
                todos = todos.Where(t => !t.IsCompleted);
            }
            ViewBag.Filter = filter;

            return View(todos);
        }
        // GET todo/create (admin only)
          [Authorize(Policy = "AdminOnly")]
        public IActionResult All()
        {
            var todos = _todoService.GetTodosAdoNet();
            return View("Index", todos); 
        }
        // post: create
        [HttpPost]
        [ValidateAntiForgeryToken] // CSRF protection
        public IActionResult Create(TodoItem todo)
        {
            if (ModelState.IsValid)
            {
                todo.UserId = User.Identity!.Name!; // Set owner
                todo.Title = HtmlEncoder.Default.Encode(todo.Title); // XSS protection
                todo.Description = todo.Description != null ? HtmlEncoder.Default.Encode(todo.Description) : null;
                _context.Add(todo);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Todo created successfully!";
                return RedirectToAction(nameof(Index));
            }
            return View(todo);
        }
        //  GET: Taks/edit (only owner)
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var todo = _context.Todos.Find(id);
            if (todo == null || todo.UserId != User.Identity!.Name)
            {
                return Unauthorized(); // Only owner can edit
            }
            return View(todo);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, TodoItem todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }
            if (todo.UserId != User.Identity!.Name)
            {
                return Unauthorized();
            }
            if (ModelState.IsValid)
            {
                todo.Title = HtmlEncoder.Default.Encode(todo.Title); // XSS
                todo.Description = todo.Description != null ? HtmlEncoder.Default.Encode(todo.Description) : null;
                _context.Update(todo);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Todo updated successfully!";
                return RedirectToAction(nameof(Index));
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
            if (todo == null || todo.UserId != User.Identity!.Name)
            {
                return Unauthorized();
            }
            return View(todo);
        }

        // post for delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = _context.Todos.Find(id);
            if (todo != null && todo.UserId == User.Identity!.Name)
            {
                _context.Todos.Remove(todo);
                _context.SaveChanges();
                TempData["SuccessMessage"] = "Todo deleted successfully!";
            }
            return RedirectToAction(nameof(Index));
        }
         [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ToggleTheme(string returnUrl = "/Todo")
        {
            bool isDark = HttpContext.Request.Cookies["Theme"] != "dark";
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(30),
                HttpOnly = false,
                Secure = false 
            };
            HttpContext.Response.Cookies.Append("Theme", isDark ? "dark" : "light", cookieOptions);

            // Open Redirect protection
            if (!Url.IsLocalUrl(returnUrl))
            {
                returnUrl = "/Todo";
            }
            return Redirect(returnUrl);
        }
    }
}
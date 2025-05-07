using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using TodoApp.Data;
using TodoApp.Models;

namespace TodoApp.Controllers
{
    public class TodosController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        // GET: Todos
        public async Task<IActionResult> Index(string? statusFilter)
        {
            var todos = _context.Todos.AsQueryable();

            if (!string.IsNullOrEmpty(statusFilter) &&
                Enum.TryParse<TodoStatus>(statusFilter, out var status))
            {
                todos = todos.Where(t => t.Status == status);
            }

            return View(await todos.ToListAsync());
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
                return NotFound();

            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            if (todo == null)
                return NotFound();

            return View(todo);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            ViewBag.StatusList = Enum.GetValues(typeof(TodoStatus)).Cast<TodoStatus>();
            ViewBag.PriorityList = Enum.GetValues(typeof(TodoPriority)).Cast<TodoPriority>();
            return View();
        }

        // POST: Todos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Description,Status,Priority,DueDate")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                todo.Id = Guid.NewGuid();
                todo.CreatedDate = DateTime.Now;
                todo.LastModifiedDate = DateTime.Now;

                _context.Add(todo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusList = Enum.GetValues(typeof(TodoStatus)).Cast<TodoStatus>();
            ViewBag.PriorityList = Enum.GetValues(typeof(TodoPriority)).Cast<TodoPriority>();
            return View(todo);
        }

        // GET: Todos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
                return NotFound();

            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();

            ViewBag.StatusList = Enum.GetValues(typeof(TodoStatus)).Cast<TodoStatus>();
            ViewBag.PriorityList = Enum.GetValues(typeof(TodoPriority)).Cast<TodoPriority>();
            return View(todo);
        }

        // POST: Todos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Title,Description,Status,Priority,DueDate,CreatedDate")] Todo todo)
        {
            if (id != todo.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    todo.LastModifiedDate = DateTime.Now;
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
                        return NotFound();
                    else
                        throw;
                }

                return RedirectToAction(nameof(Index));
            }

            ViewBag.StatusList = Enum.GetValues(typeof(TodoStatus)).Cast<TodoStatus>();
            ViewBag.PriorityList = Enum.GetValues(typeof(TodoPriority)).Cast<TodoPriority>();
            return View(todo);
        }

        // GET: Todos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
                return NotFound();

            var todo = await _context.Todos.FirstOrDefaultAsync(t => t.Id == id);
            if (todo == null)
                return NotFound();

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(Index));
        }

        // POST: Todos/MarkComplete
        [HttpPost]
        public async Task<IActionResult> MarkComplete(Guid id)
        {
            var todo = await _context.Todos.FindAsync(id);
            if (todo == null)
                return NotFound();

            todo.Status = TodoStatus.Completed;
            todo.LastModifiedDate = DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(Guid id)
        {
            return _context.Todos.Any(e => e.Id == id);
        }
    }
}

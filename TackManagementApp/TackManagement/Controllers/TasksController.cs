using Microsoft.AspNetCore.Mvc;
using TackManagementModle.Data;
using Microsoft.AspNetCore.Identity;
using TackManagementModle.Entities;
using TackManagementModle.Repository;
using TackManagementModle.Models.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Task = TackManagementModle.Entities.Tasks;
using TaskStatus = TackManagementModle.Enums.TaskStatus;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;

namespace TackManagementModle.Controllers
{
    [Authorize]
    public class TasksController : Controller
    {
        private readonly AppDbContexts _context;
        private readonly IBaseRepository<Task> _taskRepository;
        private UserManager<AppUser> _userManager;

        public TasksController(AppDbContexts context, UserManager<AppUser> userManager, IBaseRepository<Task> taskRepository)
        {
            _context = context;
            _userManager = userManager;
            _taskRepository = taskRepository;
        }

        // GET: Tasks

      

        public async Task<IActionResult> Index(string? filter)
        {
            var user = await _userManager.GetUserAsync(User);

            //var tasks = _context.Tasks.Where(x => x.UserId == user.Id);

            if (user != null)
            {
                var tasks = _context.Tasks.Where(x => x.UserId == user.Id);
                //var tasks = _context.Tasks.Where(x => x.User.Id == x.UserId);

                var viewModel = new ListOptions
                {
                    Tasks = filter switch
                    {
                        "completed" => tasks.Where(t => t.Status == TaskStatus.Completed),
                        "notcompleted" => tasks.Where(t => t.Status != TaskStatus.Completed),
                        _ => tasks
                    },
                    Filter = filter,
                    TaskStatuses = _ListOptions(),

                    //User = user
                };

                return View(viewModel);
            }

            return NotFound();
        }

        private IEnumerable<SelectListItem> _ListOptions()
        {
            return new List<SelectListItem>
                    {
                    new SelectListItem { Text = "All", Value = "" },
                    new SelectListItem { Text = "Completed", Value = "completed" },
                    new SelectListItem { Text = "Not Completed", Value = "notcompleted" }
                    };
        }



        public IActionResult ChangeTaskStatus(int id)
        {
            Task task = _context.Tasks.Find(id);

            task.Status = TaskStatus.Completed;

            _context.Update(task);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        
        // GET: Tasks/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tasks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Task task)
        {
            task.CreatedAt = DateTime.Now;
            task.Status = TaskStatus.NotCompelted;

            var user = await _userManager.GetUserAsync(User);

            if(user != null)
            {
                task.UserId = user.Id;
                task.User = user;
            }

            if (ModelState.IsValid)
            {
                await _context.AddAsync(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(task);
        }

        // GET: Tasks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {

            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return View("Create", task);
        }

        // POST: Tasks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Task task)
        {
            if (ModelState.IsValid)
            {
                _context.Update(task);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }

        // GET: Tasks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var task = await _context.Tasks.FindAsync(id);

            if (task != null)
            {
                _context.Tasks.Remove(task);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        

    }
}

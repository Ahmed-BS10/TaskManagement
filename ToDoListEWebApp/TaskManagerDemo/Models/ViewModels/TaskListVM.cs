using Microsoft.AspNetCore.Mvc.Rendering;
using TaskManagerDemo.Models.Identity;

namespace TaskManagerDemo.Models.ViewModels
{
    public class TaskListVM
    {
        public IEnumerable<Task> Tasks { get; set; }
        public string Filter { get; set; }
        public IEnumerable<SelectListItem> TaskStatuses { get; set; }

        //public AppUser User { get; set; }
    }
}

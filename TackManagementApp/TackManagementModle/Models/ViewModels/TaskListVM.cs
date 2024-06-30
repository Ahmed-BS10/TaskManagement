using Microsoft.AspNetCore.Mvc.Rendering;
using TackManagementModle.Models.Identity;

namespace TackManagementModle.Models.ViewModels
{
    public class TaskListVM
    {
        public IEnumerable<Task> Tasks { get; set; }
        public string Filter { get; set; }
        public IEnumerable<SelectListItem> TaskStatuses { get; set; }

        //public AppUser User { get; set; }
    }
}

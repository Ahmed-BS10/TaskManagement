using TaskManagerDemo.Models.Identity;
using TaskStatus = TaskManagerDemo.Enums.TaskStatus;

namespace TaskManagerDemo.Models
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public TaskStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public string UserId { get; set; } = string.Empty;
        public AppUser? User { get; set; } = null!;
    }
}

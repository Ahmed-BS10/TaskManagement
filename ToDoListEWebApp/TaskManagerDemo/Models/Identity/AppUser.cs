using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerDemo.Models.Identity
{
    public class AppUser : IdentityUser
    {
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        public ICollection<Task> Tasks { get; set; } = new List<Task>();
    }
}

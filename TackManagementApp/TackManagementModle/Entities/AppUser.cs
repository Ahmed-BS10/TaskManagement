using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TackManagementModle.Entities
{
    public class AppUser : IdentityUser
    {
      
        public ICollection<Tasks>? Tasks { get; set; } = new List<Tasks>();
    
    }
}

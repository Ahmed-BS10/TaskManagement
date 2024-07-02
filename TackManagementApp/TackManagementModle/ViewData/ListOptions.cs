using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TackManagementModle.Entities;

namespace TackManagementModle.Models.ViewModels
{


    public class ListOptions
    {
        public IEnumerable<Tasks> Tasks { get; set; }
        public string Filter { get; set; }
        public IEnumerable<SelectListItem> TaskStatuses { get; set; }
    }
        
    

      
    

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models.ViewModels
{
    public class UserFormViewModel
    {
        public User User { get; set; }
        public ICollection<Role> Roles { get; set; }
    }
}

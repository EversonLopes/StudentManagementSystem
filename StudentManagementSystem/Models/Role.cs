using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class Role
    {
        
        public int RoleID { get; set; }
        public string Role_Tittle { get; set; }
        public string Role_Description { get; set; }

        public Role() { }

        public Role(int roleID, string role_Tittle, string role_Description)
        {
            RoleID = roleID;
            Role_Tittle = role_Tittle;
            Role_Description = role_Description;
        }
    }

    
}

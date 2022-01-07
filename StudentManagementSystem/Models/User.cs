using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Models
{
    public class User
    {
        [Key]
        public int User_id { get; set; }
        public Role Role { get; set; }
        public string User_name { get; set; }
        public string User_email { get; set; }
        public DateTime User_dob { get; set; }
        public string User_adress { get; set; }

        public User()
        {
        }

        public User(int user_id, Role role, string user_name, string user_email, DateTime user_dob, string user_adress)
        {
            User_id = user_id;
            Role = role;
            User_name = user_name;
            User_email = user_email;
            User_dob = user_dob;
            User_adress = user_adress;
        }

        public void AddUser()
        {
        }

        public void RemoveUser()
        {
        }

        public void EditUser()
        {
        }

        public void SearchUser()
        {
        }
    }
}

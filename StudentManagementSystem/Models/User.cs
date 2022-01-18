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
        [Display(Name="User ID")]
        
        public int User_id { get; set; }
        
        public Role Role { get; set; }
      
        [Required(ErrorMessage = "{0} Required")]
        public int RoleID { get; set; }
      
        [StringLength(60, MinimumLength = 3, ErrorMessage = "{0} size should be between {2} and {1}")]
        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "User Name")]     
        public string User_name { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "User Email")]
        public string User_email { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Date of Birth")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime User_dob { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Adress")]
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

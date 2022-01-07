using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Data
{
    public class StudentManagementSystemContext : DbContext
    {
        public StudentManagementSystemContext (DbContextOptions<StudentManagementSystemContext> options)
            : base(options)
        {
        }

        public DbSet<StudentManagementSystem.Models.Role> Role { get; set; }
        public DbSet<StudentManagementSystem.Models.User> User { get; set; }
    }
}

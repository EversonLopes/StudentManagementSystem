using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagementSystem.Services
{
    public class UserService
    {

        private readonly StudentManagementSystemContext _context;

        public UserService(StudentManagementSystemContext context)
        {
            _context = context;
        }

        public List<User> FindAll()
        {
            return _context.User.ToList();
        }
        public void Insert(User obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}

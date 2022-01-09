using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            // obj.Role = _context.Role.First();
            _context.Add(obj);
            _context.SaveChanges();
        }
        public User FindByID(int id)
        {
            return _context.User.Include(obj=>obj.Role).FirstOrDefault(obj => obj.User_id == id);
        }
        public void Remove(int id) {
            var obj = _context.User.Find(id);
            _context.User.Remove(obj);
            _context.SaveChanges();
        }
    }
}

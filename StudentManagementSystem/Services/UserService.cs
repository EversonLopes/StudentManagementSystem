using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Services.Exceptions;

namespace StudentManagementSystem.Services
{
    public class UserService
    {

        private readonly StudentManagementSystemContext _context;

        public UserService(StudentManagementSystemContext context)
        {
            _context = context;
        }

        public async Task<List<User>> FindAllAsync()
        {
            return await  _context.User.ToListAsync();
        }
        public async Task InsertAsync(User obj)
        {
            // obj.Role = _context.Role.First();
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }
        public async Task <User> FindByIDAsync(int id)
        {
            return await _context.User.Include(obj => obj.Role).FirstOrDefaultAsync(obj => obj.User_id == id);
        }
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.User.FindAsync(id);
            _context.User.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User obj)
        {
            bool hasAny = await _context.User.AnyAsync(x => x.User_id == obj.User_id);
            if (!hasAny)
            {
                throw new NotFoundException("Id Not Found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }

            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
        }
        
    }
}

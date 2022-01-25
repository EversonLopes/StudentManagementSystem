using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentManagementSystem.Services
{
    public class RoleService
    {

        private readonly StudentManagementSystemContext _context;

        public RoleService(StudentManagementSystemContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> FindAllAsync()
        {
            return await _context.Role.OrderBy(x => x.Role_Tittle).ToListAsync();
        }
    }
}

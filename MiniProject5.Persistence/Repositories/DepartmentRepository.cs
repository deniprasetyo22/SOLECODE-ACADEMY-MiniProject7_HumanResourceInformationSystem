using Microsoft.EntityFrameworkCore;
using MiniProject7.Application.Interfaces.IRepositories;
using MiniProject7.Domain.Models;
using MiniProject7.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Persistence.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly HrisContext _context;

        public DepartmentRepository(HrisContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return await _context.Departments.ToListAsync();
        }

        public async Task<Department> GetDepartmentByIdAsync(int deptId)
        {
            return await _context.Departments
            .Include(d => d.Locations)
            .FirstOrDefaultAsync(d => d.Deptid == deptId);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            //var existingDept = await _context.Departments
            //    .Include(d => d.Locations)
            //    .FirstOrDefaultAsync(d => d.Deptid == deptId);

            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDepartmentAsync(int deptId)
        {
            var department = await _context.Departments.FindAsync(deptId);
            if (department != null)
            {
                _context.Departments.Remove(department);
                await _context.SaveChangesAsync();
            }
        }
    }
}

using MiniProject7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Application.Interfaces.IRepositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAllEmployeesAsync();
        Task<Employee> GetEmployeeByIdAsync(int empId);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task UpdateEmployeeAsync(int empId, Employee employee);
        Task DeactivateEmployeeAsync(Employee employee);
        Task DeleteEmployeeAsync(int empId);
        Task<Employee> GetEmployeeByUserIdAsync(string userId);
        Task DeleteDependentAsync(int dependentId);
        Task<IEnumerable<Employee>> GetSupervisedEmployeesAsync(int supervisorId);
    }
}

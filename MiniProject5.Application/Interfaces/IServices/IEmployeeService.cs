using MiniProject7.Application.DTOs;
using MiniProject7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Application.Interfaces.IServices
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetAllEmployeesNoPagesAsync();
        Task<object> GetAllEmployeesAsync(QueryObjectEmployee query);
        Task<Employee> GetEmployeeByIdAsync(int empId);
        Task<Employee> AddEmployeeAsync(Employee employee);
        Task<bool> UpdateEmployeeAsync(int empId, EmployeeDto employeeDto);
        Task DeactivateEmployeeAsync(int empId, string reason);
        Task ActivateEmployeeAsync(int empId);
        Task DeleteEmployeeAsync(int empId);
        Task<IEnumerable<Employee>> SearchEmployee(searchDto search, paginationDto pagination);
        Task<IEnumerable<Employee>> GetSupervisedEmployeesAsync(int supervisorId);
        Task<EmployeeDto> GetOwnProfile();
        Task<bool> UpdateOwnProfile(EmployeeDto employeeDto);
    }
}

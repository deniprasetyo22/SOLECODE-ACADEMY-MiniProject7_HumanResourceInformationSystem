using MiniProject7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Application.Interfaces.IRepositories
{
    public interface IProcessRepository
    {
        Task<IEnumerable<Process>> GetAllProcessAsync();
        Task<Process> GetProcessByIdAsync(int processId);
        Task AddProcessAsync(Process process);
        Task UpdateProcessAsync(Process process);
        Task DeleteProcessAsync(int processId);
    }
}

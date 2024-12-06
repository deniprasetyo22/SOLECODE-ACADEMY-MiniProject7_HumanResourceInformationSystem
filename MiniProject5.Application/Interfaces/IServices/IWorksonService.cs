using MiniProject7.Application.DTOs;
using MiniProject7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Application.Interfaces.IServices
{
    public interface IWorksOnService
    {
        Task<object> GetAllWorksOnAsync(paginationDto pagination);
        Task<IEnumerable<Workson>> GetAllWorksOnNoPagesAsync();
        Task<Workson> GetWorksOnByIdAsync(int empId, int projId);
        Task<Workson> AddWorksOnAsync(Workson worksOn);
        Task UpdateWorksOnAsync(int empId, int projId, Workson worksOn);
        Task DeleteWorksOnAsync(int empId, int projId);
        Task<Workson> GetOwnWorksonAsync();
    }
}

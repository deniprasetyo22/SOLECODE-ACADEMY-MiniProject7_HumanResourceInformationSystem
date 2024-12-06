using MiniProject7.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProject7.Application.Interfaces.IRepositories
{
    public interface IWorksOnRepository
    {
        Task<IEnumerable<Workson>> GetAllWorksOnAsync();
        Task<Workson> GetWorksOnByIdAsync(int empId, int projId);
        Task<Workson> AddWorksOnAsync(Workson worksOn);
        Task UpdateWorksOnAsync(Workson worksOn);
        Task DeleteWorksOnAsync(int empId, int projId);
    }
}

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
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly HrisContext _context;
        public LeaveRequestRepository(HrisContext context)
        {
            _context = context;
        }

        public async Task<Leaverequest> AddLeaveRequestAsync(Leaverequest leaveRequest)
        {
            _context.Leaverequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public IQueryable<Leaverequest> GetAllLeaveRequestsAsync()
        {
            return _context.Leaverequests
                .Include(b => b.Emp)
                .Include(b => b.Process).ThenInclude(b => b.Workflowactions);
        }

        public async Task<Leaverequest> GetLeaveRequestByIdAsync(int requestId)
        {
            return await _context.Leaverequests
                .Include(b => b.Emp)
                .Include(b => b.Process).ThenInclude(b => b.Workflowactions)
                .Where(b => b.Requestid == requestId)
                .FirstOrDefaultAsync(b => b.Requestid == requestId);
        }
    }
}

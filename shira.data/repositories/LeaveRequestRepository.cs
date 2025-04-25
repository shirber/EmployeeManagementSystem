using Microsoft.EntityFrameworkCore;
using shira.core.Entities;
using shira.core.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shira.data.repositories
{
    public class LeaveRequestRepository : ILeaveRequestRepository
    {
        private readonly DataContext _context;

        public LeaveRequestRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<LeaveRequest>> GetAllAsync()
        {
            return await _context.LeaveRequests.ToListAsync();
        }

        public async Task<LeaveRequest?> GetByIdAsync(int id)
        {
            return await _context.LeaveRequests.FindAsync(id);
        }

        public async Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest)
        {
            _context.LeaveRequests.Add(leaveRequest);
            await _context.SaveChangesAsync();
            return leaveRequest;
        }

        public async Task<LeaveRequest?> UpdateAsync(LeaveRequest leaveRequest)
        {
            var existing = await _context.LeaveRequests.FindAsync(leaveRequest.Id);
            if (existing == null) return null;

            _context.Entry(existing).CurrentValues.SetValues(leaveRequest);
            await _context.SaveChangesAsync();
            return existing;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var leaveRequest = await _context.LeaveRequests.FindAsync(id);
            if (leaveRequest == null) return false;

            _context.LeaveRequests.Remove(leaveRequest);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

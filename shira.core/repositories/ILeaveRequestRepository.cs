using shira.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shira.core.repositories
{
    public interface ILeaveRequestRepository
    {
        Task<IEnumerable<LeaveRequest>> GetAllAsync();
        Task<LeaveRequest?> GetByIdAsync(int id);
        Task<LeaveRequest> AddAsync(LeaveRequest leaveRequest);
        Task<LeaveRequest?> UpdateAsync(LeaveRequest leaveRequest);
        Task<bool> DeleteAsync(int id);
    }
}

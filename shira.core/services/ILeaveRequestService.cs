using shira.core.shira.core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shira.core.services
{
    public interface ILeaveRequestService
    {
        Task<IEnumerable<LeaveRequestDto>> GetAllAsync();
        Task<LeaveRequestDto?> GetByIdAsync(int id);
        Task<LeaveRequestDto> AddAsync(LeaveRequestDto leaveRequest);
        Task<LeaveRequestDto?> UpdateAsync(LeaveRequestDto leaveRequest);
        Task<bool> DeleteAsync(int id);
    }
}

using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Persistence.Contracts
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequestt>
    {
        Task<LeaveRequestt> GetLeaveRequestWithDetails(int Id);
        Task<List<LeaveRequestt>> GetLeaveRequestsWithDetails();
        Task ChangeApprovalStatus(LeaveRequestt leaveRequest, bool? ApprovalStatus);
    }
}

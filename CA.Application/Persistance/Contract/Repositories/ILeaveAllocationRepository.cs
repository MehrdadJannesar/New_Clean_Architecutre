using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Persistance.Contract.Repositories
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationList();
    }
}

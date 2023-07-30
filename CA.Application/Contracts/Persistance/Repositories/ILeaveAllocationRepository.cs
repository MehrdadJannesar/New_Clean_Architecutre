using CA.Application.Contracts.Persistance.CommonRepository;
using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Contracts.Persistance.Repositories
{
    public interface ILeaveAllocationRepository:IGenericRepository<LeaveAllocation>
    {
        Task<LeaveAllocation> GetLeaveAllocationWithDetails(Guid Id);
        Task<List<LeaveAllocation>> GetLeaveAllocationList();
    }
}

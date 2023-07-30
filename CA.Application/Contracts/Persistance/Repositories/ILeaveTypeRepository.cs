using CA.Application.Contracts.Persistance;
using CA.Application.Contracts.Persistance.CommonRepository;
using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CA.Application.Contracts.Persistance.Repositories
{
    public interface ILeaveTypeRepository:IGenericRepository<LeaveType>
    {
    }
}

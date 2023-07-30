using CA.Application.Persistance.Contract;
using CA.Application.Contracts.Persistance.Repositories;
using CA.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistance.Repositories
{
    public class LeaveTypeRepository:GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly CA_DbContext _dbContext;

        public LeaveTypeRepository(CA_DbContext dbContext) :base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}

using CA.Application.Persistance.Contract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CA.Persistance.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        /// <summary>
        /// Set<T> be in manast ke vaghti az in dastor estefade mikonim ebteda migoyim boro avar ro jadval T set sho va 
        /// bad query man ro ejra kon.
        /// </summary>

        private readonly CA_DbContext _dbContext;

        public GenericRepository(CA_DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T Entity)
        {
            await _dbContext.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
            return Entity;
        }

        public async Task Delete(T Entity)
        {
            _dbContext.Set<T>().Remove(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> Exist(Guid id)
        {
            var entry = await Get(id);
            return entry != null;
        }

        public async Task<T> Get(Guid Id)
        {
            return await _dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<IReadOnlyList<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T Entity)
        {
            _dbContext.Entry(Entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

        }
    }
}

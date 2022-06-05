using AutoMapper;
using GameDB.Data;
using Microsoft.EntityFrameworkCore;

namespace GameDB.Services
{
    public class GenericRepository<T> : IGenericRepository<T> where T: class, new()
    {
        private readonly DbContext _dbContext;
        public GenericRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
         }

        public virtual async Task CreateAsync(T obj)
        {
            await _dbContext.Set<T>().AddAsync(obj);
            await _dbContext.SaveChangesAsync();
        }       

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            var objList = await _dbContext.Set<T>().ToListAsync();            
            return objList;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var obj = await _dbContext.Set<T>().FindAsync(id);
            return obj;
        }

        public async Task UpdateAsync(int id, T newObj)
        {
            _dbContext.Set<T>().Update(newObj);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var obj = await _dbContext.Set<T>().FindAsync(id);
            _dbContext.Set<T>().Remove(obj);
            await _dbContext.SaveChangesAsync();        
        }

        public async Task DeleteRangeAsync(int[] ids)
        {
            var objs = await _dbContext.Set<T>().ToListAsync();
            _dbContext.RemoveRange(objs);
            await _dbContext.SaveChangesAsync();
        }
    }
}

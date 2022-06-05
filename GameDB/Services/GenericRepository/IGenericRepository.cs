namespace GameDB.Services
{
    public interface IGenericRepository<T> where T: class, new()
    {
        Task CreateAsync(T obj);
        Task UpdateAsync(int id, T obj);
        Task DeleteByIdAsync(int id);
        Task DeleteRangeAsync(int[] ids);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}

namespace UsrsMVCApp.Repositories
{
    public interface IBaseReporitory<T>
    {
        Task<IEnumerable<T>> getAllAsync();
        Task<T?> GetAsync(int id);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        void UpdateAsync(T entity);
        Task<bool> DeleteAsync(int id);
        Task<int> GetCountAsync();
    }
}

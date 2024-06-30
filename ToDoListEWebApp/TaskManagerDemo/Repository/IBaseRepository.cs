namespace TaskManagerDemo.Repository
{
    public interface IBaseRepository<T> where T : class
    {
        T GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        void AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}

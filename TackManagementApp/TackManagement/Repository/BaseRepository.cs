using Microsoft.EntityFrameworkCore;
using TackManagementModle.Data;
using TackManagementModle.Repository;

namespace ToDoList.Web.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly AppDbContexts _dbContext;

        public BaseRepository(AppDbContexts dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>();
        }

        public async void AddAsync(T entity)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _dbContext.Set<T>().Update(entity);
            _dbContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public T GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

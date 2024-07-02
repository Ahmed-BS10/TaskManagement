using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TackManagementModle.Data;

namespace TaskManagementRepository.Base
{
    public class Repository<T> : IRepository<T> where T : class
    {


        private readonly AppDbContexts _dbContext;

        public Repository(AppDbContexts dbContext)
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

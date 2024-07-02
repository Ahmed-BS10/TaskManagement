using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementRepository.Base
{
    public interface IRepository<T> where T : class
    {

        T GetByIdAsync(int id);
        IEnumerable<T> GetAll();
        void AddAsync(T entity);

        void Update(T entity);

        void Delete(T entity);


    }
}

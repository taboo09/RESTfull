using System.Collections.Generic;
using System.Threading.Tasks;

namespace REST.Domain.Services
{
    public interface IAppRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        T GetEntityById(int id);
        void Add(T entity);
        void Remove(T entity);
        Task<bool> EntityExists(int id);
        Task<int> SaveChanges();
    }
}
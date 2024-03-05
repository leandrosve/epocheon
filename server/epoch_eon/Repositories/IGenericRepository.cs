using EpochEon.Models;
using Prueba.Models;

namespace EpochEon.Repositories
{
    public interface IGenericRepository<T>
    {
        List<T> GetAll();
        T? GetById(int id);
        T Insert(T item);
        void Save();
    }
}

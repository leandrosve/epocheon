using EpochEon.Repositories;
using Prueba.Models;

namespace Prueba.Repositories
{
    public interface IBrandsRepository:IGenericRepository<Brand>
    {
        Brand? GetByName(string name);

        List<Brand> GetByCategory(int categoryId);
    }
}

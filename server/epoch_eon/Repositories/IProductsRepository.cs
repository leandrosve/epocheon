using EpochEon.Models;
using EpochEon.Repositories;
using Prueba.Models;

namespace Prueba.Repositories
{
    public interface IProductsRepository:IGenericRepository<Product>
    {
        Product? GetByIdAndStatus(int id, ProductStatus status);
    }
}

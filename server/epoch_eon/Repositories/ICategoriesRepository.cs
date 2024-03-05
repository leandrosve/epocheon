using EpochEon.Repositories;
using Prueba.Models;

namespace Prueba.Repositories
{
    public interface ICategoriesRepository:IGenericRepository<Category>
    {
        Category? GetByTitle(string title);
    }
}

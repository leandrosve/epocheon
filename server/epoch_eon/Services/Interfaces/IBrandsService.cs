using EpochEon.Models.DTOs.Categories;
using Prueba.Models;

namespace Prueba.Services.Interfaces
{
    public interface IBrandsService
    {
        public List<Brand> GetAll();
        public List<Brand> GetAllByCategory(int categoryId);
        public Brand? GetById(int id);
        public Brand GetOrCreate(BrandCreationDTO category);

    }
}

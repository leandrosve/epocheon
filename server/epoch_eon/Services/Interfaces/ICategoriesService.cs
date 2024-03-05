using EpochEon.Models.DTOs.Categories;
using Prueba.Models;

namespace Prueba.Services.Interfaces
{
    public interface ICategoriesService
    {
        public List<Category> GetAll();

        public Category? GetById(int id);
        public Category GetOrCreate(CategoryCreationDTO category);
        public Category Create(CategoryCreationDTO category);

    }
}

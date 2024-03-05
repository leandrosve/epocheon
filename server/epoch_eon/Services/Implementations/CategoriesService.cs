using EpochEon.Models.DTOs.Categories;
using Prueba.Models;
using Prueba.Repositories;
using Prueba.Services.Implementations;
using Prueba.Services.Interfaces;

namespace EpochEon.Services.Implementations
{
    public class CategoriesService : ICategoriesService
    {

        private readonly ILogger<AuthService> _logger;
        private readonly ICategoriesRepository _repository;

        public CategoriesService(ILogger<AuthService> logger, ICategoriesRepository repository, IConfiguration _configuration)
        {
            _logger = logger;
            _repository = repository;
        }
        public Category Create(CategoryCreationDTO dto)
        {
            var existing = _repository.GetByTitle(dto.Title);
            if (existing != null) return existing;
            var category = new Category { Title = dto.Title, ImageUrl = dto.ImageUrl, CreatedAt = DateTime.UtcNow};
            _repository.Insert(category);
            return category;
        }

        public Category GetOrCreate(CategoryCreationDTO dto)
        {
            Category? existing;
            if (dto.Id != null)
            {
                return _repository.GetById(dto.Id.Value) ?? throw new ArgumentException("category_not_found");
            }
            existing = _repository.GetByTitle(dto.Title);
            if (existing != null) return existing;
            var category = new Category { Title = dto.Title, ImageUrl = dto.ImageUrl, CreatedAt = DateTime.UtcNow };
            _repository.Insert(category);
            return category;
        }

        public List<Category> GetAll()
        {
            return _repository.GetAll();
        }

        public Category? GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}

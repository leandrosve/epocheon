using EpochEon.Models.DTOs.Categories;
using Prueba.Models;
using Prueba.Repositories;
using Prueba.Services.Interfaces;

namespace EpochEon.Services.Implementations
{
    public class BrandsService : IBrandsService
    {

        private readonly ILogger<BrandsService> _logger;
        private readonly IBrandsRepository _repository;


        public BrandsService(ILogger<BrandsService> logger, IBrandsRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public Brand GetOrCreate(BrandCreationDTO dto)
        {
            if (dto.Id != null)
            {
                return _repository.GetById(dto.Id.Value) ?? throw new ArgumentException("brand_not_found");
            }
            Brand? existing = _repository.GetByName(dto.Name);
            if (existing != null) return existing;
            var brand = new Brand { Name = dto.Name};
            _repository.Insert(brand);
            return brand;
        }

        public List<Brand> GetAll()
        {
            return _repository.GetAll();
        }

        public List<Brand> GetAllByCategory(int categoryId)
        {
            return _repository.GetByCategory(categoryId);
        }

        public Brand? GetById(int id)
        {
            return _repository.GetById(id);
        }
    }
}

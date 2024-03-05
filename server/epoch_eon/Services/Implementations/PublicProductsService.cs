using EpochEon.Mappings;
using EpochEon.Models;
using EpochEon.Models.DTOs;
using EpochEon.Models.DTOs.Products;
using EpochEon.Services.Interfaces;
using Prueba.Models;
using Prueba.Repositories;
using Prueba.Services.Implementations;
using Prueba.Services.Interfaces;

namespace EpochEon.Services.Implementations
{
    public class PublicProductService : IPublicProductsService
    {

        private readonly ILogger<AuthService> _logger;
        private readonly IProductsRepository _repository;
        private readonly IMapperService<Product, ProductDTO> _productMapper;
        private readonly IProductsIndexingService _indexingService;


        public PublicProductService(ILogger<AuthService> logger, IProductsRepository repository, IMapperService<Product, ProductDTO> productMapper, 
            IProductsIndexingService indexingService, IBrandsService brandsService, ICategoriesService categoryService)
        {
            _logger = logger;
            _repository = repository;
            _productMapper = productMapper;
            _indexingService = indexingService;
        }

        public async  Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO)
        {
            return await _indexingService.SearchPublished(searchDTO);
        }

        public ProductDTO GetById(int id)
        {
            var product = _repository.GetByIdAndStatus(id, ProductStatus.PUBLISHED) ?? throw new ArgumentException("not_found");
            return _productMapper.Map(product);
        }
    }
}

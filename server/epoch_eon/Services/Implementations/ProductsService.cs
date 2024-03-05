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
    public class ProductService : IProductsService
    {

        private readonly ILogger<AuthService> _logger;
        private readonly IProductsRepository _repository;
        private readonly ICategoriesService _categoriesService;
        private readonly IBrandsService _brandsService;
        private readonly IMapperService<Product, ProductDTO> _productMapper;
        private readonly IProductsIndexingService _indexingService;


        public ProductService(ILogger<AuthService> logger, IProductsRepository repository, IMapperService<Product, ProductDTO> productMapper, 
            IProductsIndexingService indexingService, IBrandsService brandsService, ICategoriesService categoryService)
        {
            _logger = logger;
            _repository = repository;
            _productMapper = productMapper;
            _indexingService = indexingService;
            _categoriesService = categoryService;
            _brandsService = brandsService;
        }

        public ProductDTO Create(ProductCreationDTO dto)
        {
            var category = _categoriesService.GetOrCreate(dto.Category);
            if (category == null) throw new ArgumentException("category_not_found");

            var brand = _brandsService.GetOrCreate(dto.Brand);
            if (brand == null) throw new ArgumentException("brand_not_found");

            var product = new Product
            {
                CreatedAt = DateTime.UtcNow,
                Title = dto.Title,
                Description = dto.Description,
                Sku = dto.Sku,
                Price = dto.Price,
                Specs = dto.Specs,
                Category = category,
                Status = GetProductStatus(dto.Status),
                Brand = brand,
            };
         
            product.Images = GetProductImagesFromUrls(dto.ImageUrls);

            _repository.Insert(product);

            var resultDTO = _productMapper.Map(product);
            _indexingService.Index(resultDTO);
            return resultDTO;
        }

        public List<ProductDTO> GetAll()
        {
            return _repository.GetAll().Select(_productMapper.Map).ToList();
        }

        public async  Task<SearchResultDTO<ProductDTO>> Search(ProductSearchDTO searchDTO)
        {
            return await _indexingService.Search(searchDTO);
        }

        public ProductDTO GetById(int id)
        {

            var product = _repository.GetById(id) ?? throw new ArgumentException("not_found");
            return _productMapper.Map(product);
        }

        public ProductDTO Update(int id, ProductUpdateDTO dto)
        {
            var product = _repository.GetById(id);
            if (product == null) throw new ArgumentException("not_found");

            if (dto.Title != null) product.Title = dto.Title;
            if (dto.Sku != null) product.Sku = dto.Sku;
            if (dto.Description != null) product.Description = dto.Description;
            if (dto.Specs != null) product.Specs = dto.Specs;
            if (dto.Category != null)
            {
                var category = _categoriesService.GetOrCreate(dto.Category);
                product.Category = category;
            };
            if (dto.Brand != null)
            {
                var brand = _brandsService.GetOrCreate(dto.Brand);
                product.Brand = brand;
            };
            if (dto.ImageUrls != null)
            {
                product.Images = GetProductImagesFromUrls(dto.ImageUrls);
            }
            if (dto.Status != null) product.Status = GetProductStatus(dto.Status);
            _repository.Save();
            var updated = GetById(product.Id);

            _indexingService.Index(updated);
            return updated;
        }

        public async void ReIndexAll()
        {
            var dtos = GetAll();
            await _indexingService.ClearAll();
            await _indexingService.IndexMany(dtos);
        }

        private List<ProductImage> GetProductImagesFromUrls(List<string> imageUrls)
        {
            var images = new List<ProductImage>();
            int index = 0;
            foreach (var item in imageUrls)
            {
                images.Add(new ProductImage { Url = item, DisplayOrder = index });
                index++;
            }
            return images;
        }

        private ProductStatus GetProductStatus(string status)
        {
            var mapping = new Dictionary<string, ProductStatus?>(){
                { "DRAFTED", ProductStatus.DRAFTED },
                { "PUBLISHED", ProductStatus.PUBLISHED },
                { "HIDDEN", ProductStatus.HIDDEN },
            };
            return mapping[status] ?? ProductStatus.DRAFTED;
        }
    }
}

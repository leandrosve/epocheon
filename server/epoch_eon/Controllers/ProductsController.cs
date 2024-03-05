using EpochEon.Models.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Services.Interfaces;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/products")]
    [Authorize]
    public class ProductsController : AdminControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;
        public ProductsController(ILogger<ProductsController> logger, IProductsService  productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet(Name = "Products")]
        public IActionResult Get()
        {
            return Ok(_productsService.GetAll());
        }

        [HttpGet("search", Name = "Search Products")]
        public  async Task<IActionResult > Search([FromBody] ProductSearchDTO searchDTO)
        {
            return Ok(await _productsService.Search(searchDTO));
        }

        [HttpGet("{id}", Name = "Retrieve Product")]
        public IActionResult Get(int id)
        {
            return Ok(_productsService.GetById(id));
        }

        [HttpPost(Name = "Create Product")]
        public IActionResult Create(ProductCreationDTO dto)
        {
            return Ok(_productsService.Create(dto));
        }

        [HttpPatch("{id}", Name = "Update Product")]
        public IActionResult Update(int id, ProductUpdateDTO dto)
        {
            return Ok(_productsService.Update(id, dto));
        }

        [HttpPost("reindex", Name = "Reindex Products")]
        public IActionResult ReIndex()
        {
            _productsService.ReIndexAll();
            return Ok();
        }
    }
}
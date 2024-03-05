using EpochEon.Models.DTOs.Products;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NpgsqlTypes;
using Prueba.Services.Interfaces;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/public/products")]
    public class PublicProductsController : AdminControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IPublicProductsService _publicProductsService;
        public PublicProductsController(ILogger<ProductsController> logger, IPublicProductsService productsService)
        {
            _logger = logger;
            _publicProductsService = productsService;
        }

        [HttpGet("search", Name = "Search Public Products")]
        public async Task<IActionResult> Search([FromBody] ProductSearchDTO searchDTO)
        {
            return Ok(await _publicProductsService.Search(searchDTO));
        }

        [HttpGet("{id}", Name = "Retrieve Public Product")]
        public IActionResult Get(int id)
        {
            return Ok(_publicProductsService.GetById(id));
        }

    }
}
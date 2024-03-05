using EpochEon.Models.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;
using Prueba.Services.Interfaces;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/brands")]
    [Authorize]
    public class BrandsController : AdminControllerBase
    {
        private readonly ILogger<BrandsController> _logger;

        private readonly IBrandsService _brandsService;

        public BrandsController(ILogger<BrandsController> logger, IBrandsService brandsService)
        {
            _logger = logger;
            _brandsService = brandsService;
        }

        [HttpGet(Name = "Brands")]
        public IActionResult GetAll([FromQuery] int? categoryId)
        {
            List<Brand> res;
            if (categoryId != null)
            {
                res = _brandsService.GetAllByCategory((int) categoryId);
                return Ok(res);
            }
            res = _brandsService.GetAll();
            return Ok(res);
            
        }


        [HttpPost(Name = "Create Brand")]
        public IActionResult Create(BrandCreationDTO brandCreationDTO)
        {
            var res = _brandsService.GetOrCreate(brandCreationDTO);
            return Ok(res);
        }
    }
}
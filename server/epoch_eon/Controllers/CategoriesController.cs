using EpochEon.Models.DTOs.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Prueba.Services.Interfaces;

namespace Prueba.Controllers
{
    [ApiController]
    [Route("api/categories")]
    [Authorize]
    public class CategoriesController : AdminControllerBase
    {
        private readonly ILogger<CategoriesController> _logger;

        private readonly ICategoriesService _categoriesService;


        public CategoriesController(ILogger<CategoriesController> logger, ICategoriesService categoriesService)
        {
            _logger = logger;
            _categoriesService = categoriesService;
        }

        [HttpGet(Name = "Categories")]
        public IActionResult GetAll()
        {
            var res = _categoriesService.GetAll();
            return Ok(res);
        }

        [HttpPost(Name = "Create Category")]
        public IActionResult Create(CategoryCreationDTO categoryCreationDTO)
        {
            var res = _categoriesService.Create(categoryCreationDTO);
            return Ok(res);
        }
    }
}
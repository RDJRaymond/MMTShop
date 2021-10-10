using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MMTShopDAL.Repositories;
using MMTShopDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MMTShopAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CategoriesController : Controller
    {
        private readonly ILogger<CategoriesController> _logger;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public CategoriesController(ILogger<CategoriesController> logger, ICategoryRepository categoryRepository, IProductRepository productRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Categories()
        {
            try
            {
                return Ok(await _categoryRepository.GetProductCategories());
            }
            catch (Exception e)
            {
                _logger.LogError("Error fetching featured products: {0}", e.Message);
                return Problem("Unable to fetch Products");
            }
        }

        [HttpGet]
        [Route("{categoryId}/Products")]
        public async Task<ActionResult> Products(int categoryId)
        {
            try
            {
                return Ok(await _productRepository.GetProductsForCategory(categoryId));
            }
            catch (Exception e)
            {
                _logger.LogError("Error fetching featured products: {0}", e.Message);
                return Problem("Unable to fetch Products");
            }
        }
    }
}

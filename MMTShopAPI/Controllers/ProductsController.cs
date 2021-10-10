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
    [Route("api/v1/[controller]/[action]")]
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductRepository _productsRepository;

        public ProductsController(ILogger<ProductsController> logger, IProductRepository productsRepository)
        {
            _logger = logger;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public async Task<ActionResult> Featured()
        {
            try
            {
                return Ok(await _productsRepository.GetFeaturedProducts());
            }
            catch (Exception e)
            {
                _logger.LogError("Error fetching featured products: {0}", e.Message);
                return Problem("Unable to fetch Products");
            }
        }
    }
}

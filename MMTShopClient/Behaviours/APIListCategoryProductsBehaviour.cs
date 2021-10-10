using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopClient.Behaviours
{
    class APIListCategoryProductsBehaviour : IListCategoryProductsBehaviour
    {
        private readonly IProductWriter _writeProductBehaviour;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public APIListCategoryProductsBehaviour(IProductWriter writeProductBehaviour, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _writeProductBehaviour = writeProductBehaviour;
            _httpClientFactory = httpClientFactory;
            _config = config;
        }

        public async Task ListCategoryProductsAsync(int categoryId)
        {
            var httpClient = _httpClientFactory.CreateClient("default");
            var url = string.Format("{0}/{1}/{2}", _config["API:CategoriesPath"], categoryId, "Products");
            var task = httpClient.GetAsync(url);
            Console.WriteLine("Fetching results...");
            var response = await task;
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Unable to retrieve Category {0} Products from the server, try again later.", categoryId);
                Console.WriteLine();
                return;
            }

            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            Console.WriteLine("Results: ");
            foreach (var product in products)
            {
                _writeProductBehaviour.WriteProduct(product);
                Console.WriteLine();
            }
        }
    }
}

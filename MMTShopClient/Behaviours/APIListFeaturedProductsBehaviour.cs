using Microsoft.Extensions.Configuration;
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
    internal class APIListFeaturedProductsBehaviour : IListFeaturedProductsBehaviour
    {
        private readonly IProductWriter _writeProductBehaviour;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public APIListFeaturedProductsBehaviour(IProductWriter writeProductBehaviour, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _writeProductBehaviour = writeProductBehaviour;
            _httpClientFactory = httpClientFactory;
            _config = config;
        }
        public async Task ListFeaturedProductsAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("default");

            var response = await httpClient.GetAsync(_config["API:ProductsPath"] + "/Featured");
            if (!response.IsSuccessStatusCode) {
                Console.WriteLine("Unable to retrieve Featured Products from the server, try again later.");
                Console.WriteLine();
                return;
            }

            var products = await response.Content.ReadFromJsonAsync<List<Product>>();
            foreach (var product in products)
            {
                _writeProductBehaviour.WriteProduct(product);
                Console.WriteLine();
            }
        }
    }
}

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
    internal class APIListCategoriesBehaviour : IListCategoriesBehaviour
    {
        private readonly ICategoryWriter _writeCategoryBehaviour;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfiguration _config;

        public APIListCategoriesBehaviour(ICategoryWriter writeCategoryBehaviour, IHttpClientFactory httpClientFactory, IConfiguration config)
        {
            _writeCategoryBehaviour = writeCategoryBehaviour;
            _httpClientFactory = httpClientFactory;
            _config = config;
        }
        public async Task ListCategoriesAsync()
        {
            var httpClient = _httpClientFactory.CreateClient("default");

            var response = await httpClient.GetAsync(_config["API:CategoriesPath"]);
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("Unable to retrieve Categories from the server, try again later.");
                Console.WriteLine();
                return;
            }
            var categories = await response.Content.ReadFromJsonAsync<List<ProductCategory>>();
            foreach (var category in categories)
                _writeCategoryBehaviour.WriteCategory(category);

            Console.WriteLine();
        }
    }
}

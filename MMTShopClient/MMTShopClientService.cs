using Microsoft.Extensions.Hosting;
using MMTShopClient.Behaviours;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MMTShopClient
{
    internal class MMTShopClientService
    {
        private readonly IListCategoriesBehaviour _listCategoriesBehaviour;
        private readonly IListFeaturedProductsBehaviour _listFeaturedProductsBehaviour;
        private readonly IListCategoryProductsBehaviour _listCategoryProductsBehaviour;

        public MMTShopClientService(IListCategoriesBehaviour listCategoriesBehaviour, IListFeaturedProductsBehaviour listFeaturedProductsBehaviour, IListCategoryProductsBehaviour listCategoryProductsBehaviour)
        {
            _listCategoriesBehaviour = listCategoriesBehaviour;
            _listFeaturedProductsBehaviour = listFeaturedProductsBehaviour;
            _listCategoryProductsBehaviour = listCategoryProductsBehaviour;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Welcome to the MMT Shop CLI.");
            Console.WriteLine("Use the listed commands to interact with the MMT Shop API.");
            Console.WriteLine();
            WriteHelp();

            string command;
            string finishedMessage = "Please enter another command, or type 'exit' to quit the application.";
            do
            {
                var input = Console.ReadLine().ToLower().Trim().Split(' ');
                command = input[0];
                if (string.IsNullOrWhiteSpace(command))
                    continue;
                switch (command)
                {
                    case "categories":
                        await _listCategoriesBehaviour.ListCategoriesAsync();
                        break;
                    case "featured":
                        await _listFeaturedProductsBehaviour.ListFeaturedProductsAsync();
                        break;
                    case "products":
                        if (!int.TryParse(input[1], out int categoryId))
                            finishedMessage = "Unable to parse category Id";
                        else
                            await _listCategoryProductsBehaviour.ListCategoryProductsAsync(categoryId);
                        break;
                    case "help":
                        WriteHelp();
                        break;
                    default:
                        finishedMessage = "Command not recognised.";
                        break;
                }
                Console.WriteLine(finishedMessage);
                Console.WriteLine();
            }
            while (command != "exit");
        }

        private void WriteHelp()
        {
            Console.WriteLine("categories - list the categories of product available");
            Console.WriteLine("products <categoryId>- list products within a category");
            Console.WriteLine("featured - list currently featured products");
            Console.WriteLine("exit - exit the application");
            Console.WriteLine("help - show this help text");
            Console.WriteLine();
            Console.WriteLine("All commands are case-insensitive");
        }
    }
}
using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopClient.Behaviours
{
    internal class ConsoleProductWriter : IProductWriter
    {
        public void WriteProduct(Product product)
        {
            Console.WriteLine("Product #{0}: {1} - {2}", product.Id, product.Name, product.Price.ToString("£#0.00"));
            Console.WriteLine("Category: " + (product.Category?.Name ?? product.CategoryId.ToString()));
            Console.WriteLine(product.Description);
        }
    }
}

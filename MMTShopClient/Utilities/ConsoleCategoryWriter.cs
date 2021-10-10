using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopClient.Behaviours
{
    internal class ConsoleCategoryWriter : ICategoryWriter
    {
        public void WriteCategory(ProductCategory category)
        {
            Console.WriteLine("{0}: {1}", category.Id, category.Name);
        }
    }
}

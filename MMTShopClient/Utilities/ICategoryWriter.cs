using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopClient.Behaviours
{
    interface ICategoryWriter
    {
        void WriteCategory(ProductCategory category);
    }
}

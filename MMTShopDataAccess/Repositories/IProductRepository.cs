using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDAL.Repositories
{
    public interface IProductRepository : IMMTShopRepositoryBase
    {
        Task<IList<Product>> GetFeaturedProducts();
        Task<IList<Product>> GetProductsForCategory(int categoryId);
    }
}

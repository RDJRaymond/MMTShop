using MMTShopDataAccess.EntityModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MMTShopDAL.Repositories
{
    public interface ICategoryRepository
    {
        Task<IList<ProductCategory>> GetProductCategories();
    }
}
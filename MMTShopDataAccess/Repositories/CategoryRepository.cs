using Microsoft.EntityFrameworkCore;
using MMTShopDataAccess;
using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDAL.Repositories
{
    public class CategoryRepository : MMTShopRepositoryBase, ICategoryRepository
    {
        public CategoryRepository(MMTShopDbContext context) : base(context) { }

        public async Task<IList<ProductCategory>> GetProductCategories()
        {
            return await Context.ProductCategories.FromSqlRaw("SP_GetProductCategories").ToListAsync();
        }
    }
}

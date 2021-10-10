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
    public class ProductRepository : MMTShopRepositoryBase, IProductRepository
    {
        public ProductRepository(MMTShopDbContext context) : base(context) { }

        // Entity Framework does not currently allow stored procedures to populate navigation properties, so I have strayed away from using SPs here
        // to take advantage of EF's navigational mapping.
        // Would need to evaluate the reasoning for using SPs over composed queries to determine whether EF is the way to go going forward
        public async Task<IList<Product>> GetFeaturedProducts()
        {
            return await Context.Products.Where(p => p.IsFeatured).Include(p => p.Category).ToListAsync();
        }

        public async Task<IList<Product>> GetProductsForCategory(int categoryId)
        {
            return await Context.Products.Where(p => p.CategoryId == categoryId).Include(p => p.Category).ToListAsync();
        }
    }
}

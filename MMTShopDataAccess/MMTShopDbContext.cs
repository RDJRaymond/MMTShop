using Microsoft.EntityFrameworkCore;
using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDataAccess
{
    public class MMTShopDbContext : DbContext
    {
        protected MMTShopDbContext() { }
        public MMTShopDbContext([NotNull] DbContextOptions options) : base(options) { }


        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductCategory> ProductCategories { get; set; }
    }
}

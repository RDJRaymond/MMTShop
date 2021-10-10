using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDataAccess.EntityModels
{
    public class Product : EntityBase<Product>
    {
        public int CategoryId { get; set; }
        public virtual ProductCategory Category { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsFeatured { get; set; }

        public override bool Equals(Product other)
            => Id == other.Id
            && CategoryId == other.CategoryId
            && Name == other.Name
            && Description == other.Description
            && Price == other.Price
            && IsFeatured == other.IsFeatured;

        public override int GetHashCode()
            => HashCode.Combine(Id, CategoryId, Name, Description, Price, IsFeatured);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShopDataAccess.EntityModels
{
    public class ProductCategory : EntityBase<ProductCategory>
    {
        public string Name { get; set; }

        public override bool Equals(ProductCategory other)
            => Id == other.Id && Name == other.Name;

        public override int GetHashCode()
            => HashCode.Combine(Id, Name);
    }
}

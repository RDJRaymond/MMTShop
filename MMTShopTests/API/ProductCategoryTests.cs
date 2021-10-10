using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MMTShopTests.API
{
    public class ProductCategoryTests
    {
        [Theory]
        [MemberData(nameof(ProductCategoryEquatableData))]
        public void ProductCategoryEquatable_IsEqual(ProductCategory ProductCategory, ProductCategory other, bool expected)
        {
            Assert.Equal(expected, ProductCategory.Equals(other));
        }

        public static IEnumerable<object[]> ProductCategoryEquatableData()
        {
            var productCategory = new ProductCategory {Id = 1, Name = "Category 1"};
            var identical = new ProductCategory { Id = 1, Name = "Category 1" };
            var idDiffers = new ProductCategory { Id = 2, Name = "Category 1" };
            var nameDiffers = new ProductCategory { Id = 1, Name = "Category 2" };

            return new List<object[]> {
                new object[]{productCategory, identical, true},
                new object[]{productCategory, idDiffers, false},
                new object[]{productCategory, nameDiffers, false},
            };
        }
    }
}

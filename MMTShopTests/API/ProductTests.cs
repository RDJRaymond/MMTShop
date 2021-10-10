using MMTShopDataAccess.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MMTShopTests.API
{
    public class ProductTests
    {
        [Theory]
        [MemberData(nameof(ProductEquatableData))]
        public void ProductEquatable_IsEqual(Product product, Product other, bool expected)
        {
            Assert.Equal(expected, product.Equals(other));
        }

        public static IEnumerable<object[]> ProductEquatableData()
        {
            static Product getProduct() => new Product
            {
                Id = 1,
                CategoryId = 1,
                Name = "ProductA",
                Description = "Product A",
                Price = 100,
                IsFeatured = false
            };

            var product = getProduct();
            var identical = getProduct();
            var idDiffers = getProduct();
            idDiffers.Id = 2;
            var categoryDiffers = getProduct();
            categoryDiffers.CategoryId = 2;
            var nameDiffers = getProduct();
            nameDiffers.Name = "ProductB";
            var descriptionDiffers = getProduct();
            descriptionDiffers.Description = "Product B";
            var priceDiffers = getProduct();
            priceDiffers.Price = 200;
            var featuredDiffers = getProduct();
            featuredDiffers.IsFeatured = true;


            return new List<object[]> {
                new object[]{product, identical, true},
                new object[]{product, idDiffers, false},
                new object[]{product, categoryDiffers, false},
                new object[]{product, nameDiffers, false},
                new object[]{product, descriptionDiffers, false},
                new object[]{product, priceDiffers, false},
                new object[]{product, featuredDiffers, false},
            };
        }
    }
}

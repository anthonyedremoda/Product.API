using Products.Domain;

namespace Products.Tests
{
    public class ProductTests
    {
        [Fact]
        public void Product_Should_Have_Valid_Data()
        {
            var product = new Product
            {
                Name = "Chair",
                Colour = "Red",
                Price = 100
            };

            Assert.Equal("Red", product.Colour);
        }
    }
}



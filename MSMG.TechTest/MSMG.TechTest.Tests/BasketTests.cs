using Xunit;
using Shouldly;

namespace MSMG.TechTest.Tests
{
    public class BasketTests
    {
        [Fact]
        public void AddProduct_Successfully_Adds_Product_To_Basket()
        {
            var basket = new Basket();

            basket.AddProduct(new Product());

            basket.TotalNumberOfProducts().ShouldBe(1);
        }

        [Fact]
        public void AddProduct_Successfully_Adds_Multiple_Products_To_Basket()
        {
            var basket = new Basket();

            basket.AddProduct(new Product());
            basket.AddProduct(new Product());

            basket.TotalNumberOfProducts().ShouldBe(2);
        }
    }
}

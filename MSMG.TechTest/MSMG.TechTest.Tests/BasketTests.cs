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

            basket.AddProduct(new Product(1, "Butter", 0.8m));

            basket.TotalNumberOfProducts().ShouldBe(1);
        }

        [Fact]
        public void AddProduct_Successfully_Adds_Multiple_Products_To_Basket()
        {
            var basket = new Basket();

            basket.AddProduct(new Product(1, "Butter", 0.8m));
            basket.AddProduct(new Product(2, "Milk", 1.15m));

            basket.TotalNumberOfProducts().ShouldBe(2);
        }

        [Fact]
        public void AddProduct_Successfully_Adds_More_Than_One_Of_A_Product_To_Basket()
        {
            var basket = new Basket();

            basket.AddProduct(new Product(1, "Butter", 0.8m, 2));

            basket.TotalNumberOfProducts().ShouldBe(2);
        }

        [Fact]
        public void RemoveProduct_Successfully_Removes_Product_From_Basket()
        {
            var basket = new Basket();

            var product = new Product(1, "Butter", 0.8m);

            basket.AddProduct(product);

            basket.RemoveProduct(product);

            basket.TotalNumberOfProducts().ShouldBe(0);
        }
    }
}

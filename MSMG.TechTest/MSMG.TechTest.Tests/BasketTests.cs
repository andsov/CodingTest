using Xunit;
using Shouldly;
using System;
using MSMG.TechTest.Discounts;
using System.Collections.Generic;

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

        [Fact]
        public void RemoveProduct_Successfully_Removes_All_But_One_Quantity_Of_Product_From_Basket()
        {
            var basket = new Basket();

            basket.AddProduct(new Product(1, "Butter", 0.8m, 2));

            basket.RemoveProduct(new Product(1, "Butter", 0.8m, 1));

            basket.TotalNumberOfProducts().ShouldBe(1);
        }

        [Fact]
        public void RemoveProduct_Should_Throw_Error_If_Attempting_To_Remove_Product_Not_In_Basket()
        {
            const string expectedErrorMessage = "Product Butter not present in basket";

            var basket = new Basket();

            var exception = Should.Throw<Exception>(() => basket.RemoveProduct(new Product(1, "Butter", 0.8m, 1)));

            exception.Message.ShouldBe(expectedErrorMessage);
        }

        [Theory]
        [InlineData(1, 0.8)]
        [InlineData(2, 1.6)]
        public void GetTotal_Returns_The_Basket_Total_Price_For_A_Product(int quantity, decimal expectedTotal)
        {
            var basket = new Basket();

            var product = new Product(1, "Butter", 0.8m, quantity);

            basket.AddProduct(product);

            basket.GetTotal().ShouldBe(expectedTotal);
        }

        [Fact]
        public void GetTotal_Returns_The_Basket_Total_Price_When_It_Contains_One_Of_Each_Product()
        {
            var basket = new Basket();

            basket.AddProduct(new Product(1, "Butter", 0.8m));
            basket.AddProduct(new Product(2, "Milk", 1.15m));
            basket.AddProduct(new Product(3, "Bread", 1.0m));

            basket.GetTotal().ShouldBe(2.95m);
        }

        [Theory]
        [InlineData(2, 2, 3.1)]
        [InlineData(4, 2, 4.2)]
        public void GetTotal_Returns_The_Basket_Total_Price_With_Discount_Applied_For_Butter_And_Bread(int butterQuantity, int breadQuantity, decimal expectedTotal)
        {
            var discounts = new List<IDiscount>
            {
                new ProductPercentageDiscount()
            };

            var basket = new Basket(discounts);

            basket.AddProduct(new Product(1, "Butter", 0.8m, butterQuantity));
            basket.AddProduct(new Product(3, "Bread", 1.0m, breadQuantity));

            basket.GetTotal().ShouldBe(expectedTotal);
        }

        [Fact]
        public void GetTotal_Returns_The_Basket_Total_Price_With_Discount_Applied_For_Getting_The_Fourth_Milk_Free()
        {
            var discounts = new List<IDiscount>
            {
                new ProductForFreeDiscount()
            };

            var basket = new Basket(discounts);

            basket.AddProduct(new Product(2, "Milk", 1.15m, 4));

            basket.GetTotal().ShouldBe(3.45m);
        }

        [Fact]
        public void GetTotal_Returns_The_Basket_Total_Price_With_All_Discounts_Applied()
        {
            var discounts = new List<IDiscount>
            {
                new ProductPercentageDiscount(),
                new ProductForFreeDiscount()
            };

            var basket = new Basket(discounts);

            basket.AddProduct(new Product(1, "Butter", 0.8m, 2));
            basket.AddProduct(new Product(2, "Milk", 1.15m, 8));
            basket.AddProduct(new Product(3, "Bread", 1.0m));

            basket.GetTotal().ShouldBe(9.00m);
        }
    }
}

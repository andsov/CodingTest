﻿using Xunit;
using Shouldly;
using System;

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
    }
}

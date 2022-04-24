using MSMG.TechTest.Discounts;
using System;

namespace MSMG.TechTest
{
    public class Basket
    {
        private IList<Product> _products;
        private ProductPercentageDiscount _productPercentageDiscount;

        public Basket()
        {
            _products = new List<Product>();
            _productPercentageDiscount = new ProductPercentageDiscount();
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public int TotalNumberOfProducts()
        {
            return _products.Sum(p => p.Quantity);
        }

        public void RemoveProduct(Product product)
        {
            var productInBasket = _products.FirstOrDefault(p => p.Id == product.Id);

            if (productInBasket == null)
                throw new Exception($"Product {product.Name} not present in basket");
            else if (productInBasket.Quantity > 1)
                productInBasket.DecrementQuantity();
            else
                _products.Remove(productInBasket);
        }

        public decimal GetTotal()
        {
            var discount = _productPercentageDiscount.CalculateDiscount(_products);

            var milk = _products.FirstOrDefault(p => p.Name == "Milk");

            if (milk != null && milk.Quantity >= 4)
                discount += milk.Price;

            return _products.Select(p => p.Quantity * p.Price).Sum() - discount;
        }
    }
}
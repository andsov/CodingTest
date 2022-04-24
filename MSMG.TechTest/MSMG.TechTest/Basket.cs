using MSMG.TechTest.Discounts;
using System;

namespace MSMG.TechTest
{
    public class Basket
    {
        private IList<Product> _products;
        private IList<IDiscount> _discounts;

        public Basket(IList<IDiscount>? discounts = null)
        {
            _products = new List<Product>();
            _discounts = discounts ?? new List<IDiscount>();
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
            var discount = _discounts.Select(d => d.CalculateDiscount(_products)).Sum();

            return _products.Select(p => p.Quantity * p.Price).Sum() - discount;
        }
    }
}
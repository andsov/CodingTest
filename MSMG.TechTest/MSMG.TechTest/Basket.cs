using System;

namespace MSMG.TechTest
{
    public class Basket
    {
        private IList<Product> _products;

        public Basket()
        {
            _products = new List<Product>();
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
            var discount = 0m;
            var butterQuantity = _products.Where(p => p.Name == "Butter").Select(p => p.Quantity).Sum();
            var bread = _products.FirstOrDefault(p => p.Name == "Bread");

            if (butterQuantity >= 2)
                discount += (bread?.Price ?? 0m) * 0.5m;

            return _products.Select(p => p.Quantity * p.Price).Sum() - discount;
        }
    }
}
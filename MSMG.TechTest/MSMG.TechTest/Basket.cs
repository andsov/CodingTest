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
            return _products.Sum(product => product.Quantity);
        }
    }
}
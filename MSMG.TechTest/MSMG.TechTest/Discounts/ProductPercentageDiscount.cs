using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSMG.TechTest.Discounts
{
    public class ProductPercentageDiscount
    {
        public decimal CalculateDiscount(IList<Product> products)
        {
            var discount = 0m;
            var butterQuantity = products.Where(p => p.Name == "Butter").Select(p => p.Quantity).Sum();
            var bread = products.FirstOrDefault(p => p.Name == "Bread");

            if (butterQuantity >= 2)
                discount += (bread?.Price ?? 0m) * 0.5m;

            return discount;
        }
    }
}

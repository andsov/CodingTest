namespace MSMG.TechTest.Discounts
{
    public class ProductPercentageDiscount : IDiscount
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

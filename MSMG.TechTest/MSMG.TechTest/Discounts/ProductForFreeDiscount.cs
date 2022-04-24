namespace MSMG.TechTest.Discounts
{
    public class ProductForFreeDiscount : IDiscount
    {
        public decimal CalculateDiscount(IList<Product> products)
        {
            var discount = 0m;

            var milk = products.FirstOrDefault(p => p.Name == "Milk");

            if (milk != null && milk.Quantity >= 4)
                discount += milk.Price;

            return discount;
        }
    }
}

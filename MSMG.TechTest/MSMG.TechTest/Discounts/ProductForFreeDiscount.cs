namespace MSMG.TechTest.Discounts
{
    public class ProductForFreeDiscount : IDiscount
    {
        public decimal CalculateDiscount(IList<Product> products)
        {
            var milk = products.FirstOrDefault(p => p.Name == "Milk");
            var numberOfFreeMilks = (milk?.Quantity ?? 0) / 4;

            return (milk?.Price ?? 0) * numberOfFreeMilks;
        }
    }
}

namespace MSMG.TechTest.Discounts
{
    public class ProductPercentageDiscount : IDiscount
    {
        public decimal CalculateDiscount(IList<Product> products)
        {
            var butterQuantity = products.Where(p => p.Name == "Butter").Select(p => p.Quantity).Sum();
            var numberOfDiscountsToApply = butterQuantity / 2;
            var bread = products.FirstOrDefault(p => p.Name == "Bread");

            return Enumerable.Range(1, bread?.Quantity ?? 0)
                .Select(p =>
                {
                    var discount = 0m;

                    if (numberOfDiscountsToApply > 0)
                    {
                        discount = (bread?.Price ?? 0) * 0.5m;
                        numberOfDiscountsToApply--;
                    }

                    return discount;
                }).Sum();
        }
    }
}

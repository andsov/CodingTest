namespace MSMG.TechTest.Discounts
{
    public interface IDiscount
    {
        decimal CalculateDiscount(IList<Product> products);
    }
}
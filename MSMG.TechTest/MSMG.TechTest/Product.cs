namespace MSMG.TechTest
{
    public class Product
    {
        public Product(int id, string name, decimal price, int quantity = 1)
        {
            
            Quantity = quantity;
        }

        public int Quantity { get; internal set; }
        public object Id { get; internal set; }
    }
}
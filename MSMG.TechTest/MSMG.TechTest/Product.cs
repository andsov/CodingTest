namespace MSMG.TechTest
{
    public class Product
    {
        public Product(int id, string name, decimal price, int quantity = 1)
        {
            
            Quantity = quantity;
        }

        public int Quantity { get; private set; }
        public int Id { get; }

        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}
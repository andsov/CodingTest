namespace MSMG.TechTest
{
    public class Product
    {
        public Product(int id, string name, decimal price, int quantity = 1)
        {
            Quantity = quantity;
            Name = name;
            Price = price;
        }

        public int Quantity { get; private set; }
        public int Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }

        public void DecrementQuantity()
        {
            Quantity--;
        }
    }
}
namespace ApplicationBakery.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }

        //forekey
        public int CustomerId { get; set; }

        //property navegation 
        public Customer Customer { get; set; }

    }
}

namespace ApplicationBakery.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        //Navegation uno a varios con pedido
        public ICollection<Order> Orders { get; set; }

    }
}

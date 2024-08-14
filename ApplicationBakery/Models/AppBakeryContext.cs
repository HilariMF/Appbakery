using Microsoft.EntityFrameworkCore;

namespace ApplicationBakery.Models
{
    public class AppBakeryContext : DbContext
    {

        public AppBakeryContext(DbContextOptions<AppBakeryContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //FLUENT API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //primary key
            #region "Primary Key"
            modelBuilder.Entity<Customer>()
                .HasKey(customer => customer.Id); //lambda Where
            modelBuilder.Entity<Order>()
                .HasKey(oder => oder.Id);
            #endregion

            //relaciones 
            #region
            modelBuilder.Entity<Customer>()
                .HasMany<Order>(Customer => Customer.Orders) //cliente varios pedidos
                .WithOne(Order => Order.Customer) //pedido un cliente
                .HasForeignKey(Order => Order.CustomerId);
            #endregion

            #region "Property"
            //Campos requeridos
            #region "Customer"
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Customer>()
                 .Property(customer => customer.Phone)
                 .IsRequired()
                 .HasMaxLength(50);

            modelBuilder.Entity<Customer>()
                 .Property(customer => customer.Address)
                 .IsRequired().HasMaxLength(200);

            #endregion

            #region "Order"
            modelBuilder.Entity<Order>()
                .Property(order => order.OrderDate)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Order>()
                .Property(order => order.Description)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Order>()
                .Property(order => order.CustomerId)
                .IsRequired();
            #endregion


            #endregion
        }


    }
}

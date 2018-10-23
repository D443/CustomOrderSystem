namespace CustomOrderSystem.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CusDataContext : DbContext
    {
        public CusDataContext()
            : base("name=CusDataContext")
        {
        }

        public virtual DbSet<CustomerOrder> CustomerOrder { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasMany(e => e.CustomerOrder)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.CustomerOrder)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.CustomerId)
                .WillCascadeOnDelete(false);
        }
    }
}

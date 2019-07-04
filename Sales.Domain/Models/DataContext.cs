namespace Sales.Domain.Models
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using Common.Models;

    public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Student> Students { get; set; }

        public DbSet<Assistant> Assistants { get; set; }

        public DbSet<Shop> Shops { get; set; }

        public DbSet<Seller> Sellers { get; set; }

        public DbSet<Mark> Marks { get; set; }

        public DbSet<Gallery> Galleries { get; set; }

        public DataContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Configurations.Add(new GalleriesMap());
        }
    }
}
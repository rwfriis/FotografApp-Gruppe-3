namespace WS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FotografAppContext : DbContext
    {
        public FotografAppContext()
            : base("name=FotografAppContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<TypesOfPhotograph> TypesOfPhotographs { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Pictures)
                .WithRequired(e => e.Category1)
                .HasForeignKey(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TypesOfPhotograph>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.TypesOfPhotograph)
                .HasForeignKey(e => e.TypeOf)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(e => e.Order)
                .WithRequired(e => e.User);
        }
    }
}

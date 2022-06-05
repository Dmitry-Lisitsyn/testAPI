using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using testAPI.Models;

#nullable disable

namespace testAPI.Data
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProvidedProduct> ProvidedProducts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<SalesId> SalesIds { get; set; }
        public virtual DbSet<SalesPoint> SalesPoints { get; set; }
        public virtual DbSet<SaleData> SalesData { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);

            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<SaleCreate>();

        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

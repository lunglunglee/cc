namespace cc.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model_cc : DbContext
    {
        public Model_cc()
            : base("name=Model_cc")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Data_Area> Data_Area { get; set; }
        public virtual DbSet<Data_City> Data_City { get; set; }
        public virtual DbSet<Data_Province> Data_Province { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Endded> Enddeds { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Pay> Pays { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<代理表> 代理表 { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.訂購貨品)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_Area>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Data_Area)
                .HasForeignKey(e => e.區域);

            modelBuilder.Entity<Data_City>()
                .HasMany(e => e.Data_Area)
                .WithRequired(e => e.Data_City)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_City>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Data_City)
                .HasForeignKey(e => e.城市);

            modelBuilder.Entity<Data_Province>()
                .HasMany(e => e.Data_City)
                .WithRequired(e => e.Data_Province)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Data_Province>()
                .HasMany(e => e.Orders)
                .WithOptional(e => e.Data_Province)
                .HasForeignKey(e => e.省府);

            modelBuilder.Entity<Endded>()
                .Property(e => e.貨品狀況)
                .IsFixedLength();

            modelBuilder.Entity<Endded>()
                .HasMany(e => e.Order_Details)
                .WithOptional(e => e.Endded)
                .HasForeignKey(e => e.貨品狀況);

            modelBuilder.Entity<Order_Detail>()
                .Property(e => e.價格)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Order_Detail>()
                .HasOptional(e => e.Order)
                .WithRequired(e => e.Order_Details);

            modelBuilder.Entity<Pay>()
                .HasMany(e => e.Order_Details)
                .WithOptional(e => e.Pay)
                .HasForeignKey(e => e.支付方式);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.採購項目)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.原材價錢)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.購入數量)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.單件產品耗量)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .Property(e => e.已使用數量)
                .IsFixedLength();

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Categories)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.貨源);

            modelBuilder.Entity<代理表>()
                .HasMany(e => e.Order_Details)
                .WithRequired(e => e.代理表)
                .HasForeignKey(e => e.訂購代理)
                .WillCascadeOnDelete(false);
        }
    }
}

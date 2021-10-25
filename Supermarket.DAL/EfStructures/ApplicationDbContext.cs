using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Supermarket.Model.Entities;

#nullable disable

namespace Supermarket.Dal.EfStructures
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AddressLocation> AddressLocations { get; set; }
        public virtual DbSet<Branch> Branches { get; set; }
        public virtual DbSet<Cashbox> Cashboxes { get; set; }
        public virtual DbSet<CashboxTransaction> CashboxTransactions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CellProduct> CellProducts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<DeliveryStatus> DeliveryStatuses { get; set; }
        public virtual DbSet<Deliveryman> Deliverymen { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DisposableProductsHistory> DisposableProductsHistories { get; set; }
        public virtual DbSet<DisposePackage> DisposePackages { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<LogSession> LogSessions { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderProduct> OrderProducts { get; set; }
        public virtual DbSet<OrderStatus> OrderStatuses { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductPackage> ProductPackages { get; set; }
        public virtual DbSet<Proffesion> Proffesions { get; set; }
        public virtual DbSet<Shipping> Shippings { get; set; }
        public virtual DbSet<SpecialCare> SpecialCares { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<TransactionProduct> TransactionProducts { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WishList> WishLists { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Branch>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__branch__location__48CFD27E");
            });

            modelBuilder.Entity<Cashbox>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Cashboxes)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__cashbox__branch___49C3F6B7");
            });

            modelBuilder.Entity<CashboxTransaction>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Date)
                    .IsRowVersion()
                    .IsConcurrencyToken();

                entity.HasOne(d => d.Cashbox)
                    .WithMany(p => p.CashboxTransactions)
                    .HasForeignKey(d => d.CashboxId)
                    .HasConstraintName("FK__cashbox_t__cashb__4BAC3F29");

                entity.HasOne(d => d.CashierNavigation)
                    .WithMany(p => p.CashboxTransactions)
                    .HasForeignKey(d => d.Cashier)
                    .HasConstraintName("FK__cashbox_t__cashi__4AB81AF0");
            });

            modelBuilder.Entity<CellProduct>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__cell_prod__branc__4CA06362");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__cell_prod__produ__4D94879B");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.PhoneNumber)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__customer__addres__4F7CD00D");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__customer__id__4E88ABD4");
            });

            modelBuilder.Entity<DeliveryStatus>(entity =>
            {
                entity.Property(e => e.Name).IsUnicode(false);
            });

            modelBuilder.Entity<Deliveryman>(entity =>
            {
                entity.HasOne(d => d.Employee)
                    .WithMany()
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK__deliverym__emplo__5070F446");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DisposableProductsHistory>(entity =>
            {
                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__disposable_p__id__5165187F");

                entity.HasOne(d => d.Refunder)
                    .WithMany()
                    .HasForeignKey(d => d.RefunderId)
                    .HasConstraintName("FK__disposabl__refun__52593CB8");
            });

            modelBuilder.Entity<DisposePackage>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__dispose_p__branc__5441852A");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__dispose_p__prod___534D60F1");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.Property(e => e.PhoneNumber)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany()
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK__employee__addres__5629CD9C");

                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__employee__branch__59063A47");

                entity.HasOne(d => d.Department)
                    .WithMany()
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__employee__depart__5812160E");

                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__employee__id__5535A963");

                entity.HasOne(d => d.Profession)
                    .WithMany()
                    .HasForeignKey(d => d.ProfessionId)
                    .HasConstraintName("FK__employee__profes__571DF1D5");
            });

            modelBuilder.Entity<LogSession>(entity =>
            {
                entity.HasOne(d => d.IdNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Id)
                    .HasConstraintName("FK__log_sessions__id__59FA5E80");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderDescription).IsUnicode(false);

                entity.Property(e => e.PeymentStatus).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__order__branch_id__5EBF139D");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.OrderCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__order__customer___5AEE82B9");

                entity.HasOne(d => d.DeliveryMan)
                    .WithMany(p => p.OrderDeliveryMen)
                    .HasForeignKey(d => d.DeliveryManId)
                    .HasConstraintName("FK__order__delivery___5DCAEF64");

                entity.HasOne(d => d.DeliveryStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DeliveryStatusId)
                    .HasConstraintName("FK__order__delivery___5BE2A6F2");

                entity.HasOne(d => d.OrderStatus)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderStatusId)
                    .HasConstraintName("FK__order__order_sta__5CD6CB2B");
            });

            modelBuilder.Entity<OrderProduct>(entity =>
            {
                entity.HasOne(d => d.Order)
                    .WithMany()
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__order_pro__order__5FB337D6");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__order_pro__produ__60A75C0F");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__product__categor__628FA481");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__product__supplie__619B8048");
            });

            modelBuilder.Entity<ProductPackage>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany()
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__product_p__branc__6477ECF3");

                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__product_p__prod___656C112C");

                entity.HasOne(d => d.Shipping)
                    .WithMany()
                    .HasForeignKey(d => d.ShippingId)
                    .HasConstraintName("FK__product_p__shipp__6383C8BA");
            });

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("FK__shipping__branch__66603565");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.Shippings)
                    .HasForeignKey(d => d.SupplierId)
                    .HasConstraintName("FK__shipping__suppli__6754599E");
            });

            modelBuilder.Entity<SpecialCare>(entity =>
            {
                entity.HasOne(d => d.Prod)
                    .WithMany()
                    .HasForeignKey(d => d.ProdId)
                    .HasConstraintName("FK__special_c__prod___68487DD7");
            });

            modelBuilder.Entity<Supplier>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK__supplier__locati__693CA210");
            });

            modelBuilder.Entity<TransactionProduct>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__transacti__produ__6B24EA82");

                entity.HasOne(d => d.Transaction)
                    .WithMany()
                    .HasForeignKey(d => d.TransactionId)
                    .HasConstraintName("FK__transacti__trans__6A30C649");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Passwd)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.Username)
                    .IsUnicode(false)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<WishList>(entity =>
            {
                entity.HasOne(d => d.Customer)
                    .WithMany()
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__wish_list__custo__6D0D32F4");

                entity.HasOne(d => d.Product)
                    .WithMany()
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__wish_list__produ__6C190EBB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Koffee_Hotel.Models
{
    public partial class MyDbContext : DbContext
    {
        public MyDbContext()
            : base("name=MyDbContext_CON")
        {
        }

        public virtual DbSet<Catergory> Catergories { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Parking> Parkings { get; set; }
        public virtual DbSet<Reservation> Reservations { get; set; }
        public virtual DbSet<Setting> Settings { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserType> UserTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catergory>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Catergory>()
                .HasOptional(e => e.Catergory1)
                .WithRequired(e => e.Catergory2);

            modelBuilder.Entity<Catergory>()
                .HasMany(e => e.FoodItems)
                .WithRequired(e => e.Catergory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catergory>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Catergory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.FoodName)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<FoodItem>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.FoodItem)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reservation>()
                .HasMany(e => e.Parkings)
                .WithRequired(e => e.Reservation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Setting>()
                .Property(e => e.ItemType)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.StatusType)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Gender)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.EmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Reservations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserType>()
                .Property(e => e.UserTypeName)
                .IsUnicode(false);
        }
    }
}

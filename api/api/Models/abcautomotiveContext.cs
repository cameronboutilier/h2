using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace api.Models
{
    public partial class abcautomotiveContext : DbContext
    {
        public abcautomotiveContext()
        {
        }

        public abcautomotiveContext(DbContextOptions<abcautomotiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Car> Cars { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NBTKDE7\\SQLEXPRESS;Database=abcautomotive;User Id=testuser;Password=testpassword");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CarColor)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carColor");

                entity.Property(e => e.CarCost).HasColumnName("carCost");

                entity.Property(e => e.CarType)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("carType");

                entity.Property(e => e.Convertible).HasColumnName("convertible");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

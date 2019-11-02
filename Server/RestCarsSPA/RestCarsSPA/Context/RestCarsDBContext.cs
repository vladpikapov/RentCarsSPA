using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace RestCarsSPA
{
    public partial class RestCarsDBContext : DbContext
    {
        public RestCarsDBContext()
        {
        }

        public RestCarsDBContext(DbContextOptions<RestCarsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cars> Cars { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.RegistrationNumber)
                    .HasName("PK__Cars__E8864603E49D0B78");

                entity.Property(e => e.RegistrationNumber)
                    .HasMaxLength(8)
                    .ValueGeneratedNever();

                entity.Property(e => e.CarClass)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Mark)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.Model)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.YearOfIssue).HasColumnType("date");
            });

            modelBuilder.Entity<Drivers>(entity =>
            {
                entity.HasKey(e => e.NumberDriverLicense)
                    .HasName("PK__Drivers__9DF71368E77132AE");

                entity.Property(e => e.NumberDriverLicense)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.Property(e => e.CarId).HasMaxLength(8);

                entity.Property(e => e.Comment).HasMaxLength(200);

                entity.Property(e => e.DriverLicense).HasMaxLength(10);

                entity.Property(e => e.EndDate).HasColumnType("date");

                entity.Property(e => e.StartDate).HasColumnType("date");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Orders__CarId__3D5E1FD2");

                entity.HasOne(d => d.DriverLicenseNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DriverLicense)
                    .HasConstraintName("FK__Orders__DriverLi__3C69FB99");
            });
        }
    }
}

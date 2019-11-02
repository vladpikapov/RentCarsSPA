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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-PQ7CV0T\\SQL2017;Database=RestCarsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Cars>(entity =>
            {
                entity.HasKey(e => e.RegistrationNumber)
                    .HasName("PK__Cars__E8864603C1F5A740");

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
                    .HasName("PK__Drivers__9DF713682DF1A949");

                entity.HasIndex(e => e.FullName)
                    .HasName("UQ__Drivers__89C60F11D289283F")
                    .IsUnique();

                entity.Property(e => e.NumberDriverLicense)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);
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
                    .HasConstraintName("FK__Orders__CarId__3E52440B");

                entity.HasOne(d => d.DriverLicenseNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.DriverLicense)
                    .HasConstraintName("FK__Orders__DriverLi__3D5E1FD2");
            });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DogBusinessDB
{
    public partial class DogBusinessContext : DbContext
    {
        public DogBusinessContext()
        {
        }

        public DogBusinessContext(DbContextOptions<DogBusinessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Breeder> Breeder { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=DogBusiness;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Breeder>(entity =>
            {
                entity.HasKey(e => e.DogId);

                entity.Property(e => e.DogBreed).HasMaxLength(50);

                entity.Property(e => e.DogCreatedDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DogGender).HasMaxLength(7);

                entity.Property(e => e.DogName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.DogNotes).HasMaxLength(1000);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

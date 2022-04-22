using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace netcoremvc
{
    public partial class registerdbContext : DbContext
    {
        public registerdbContext()
        {
        }

        public registerdbContext(DbContextOptions<registerdbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<student> RegistrationInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              optionsBuilder.UseSqlServer("data source=.;initial catalog=registerdb;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Chinese_PRC_CI_AS");

            modelBuilder.Entity<student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Birthday)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreateTime).HasColumnType("datetime");

                entity.Property(e => e.Mobile)
                    .IsRequired()
                    .HasMaxLength(13);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(1);

                entity.Property(e => e.Temperature).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

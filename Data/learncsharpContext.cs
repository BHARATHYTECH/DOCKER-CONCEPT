using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using learncsharp.Models;

namespace learncsharp.Data
{
    public partial class learncsharpContext : DbContext
    {
        public learncsharpContext()
        {
        }

        public learncsharpContext(DbContextOptions<learncsharpContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = null!;
        public virtual DbSet<Tblemployee> Tblemployees { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("employee");

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Department).HasMaxLength(20);

                entity.Property(e => e.Gender).HasMaxLength(6);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            modelBuilder.Entity<Tblemployee>(entity =>
            {
                entity.HasKey(e => e.EmployeeId)
                    .HasName("PRIMARY");

                entity.ToTable("tblemployee");

                entity.Property(e => e.City).HasMaxLength(20);

                entity.Property(e => e.Department).HasMaxLength(20);

                entity.Property(e => e.Gender).HasMaxLength(6);

                entity.Property(e => e.Name).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

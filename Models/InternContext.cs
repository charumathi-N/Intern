using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Intern.Models;

public partial class InternContext : DbContext
{
    public InternContext()
    {
    }

    public InternContext(DbContextOptions<InternContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginDetail> LoginDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginDetail>(entity =>
        {
            entity.HasKey(e => e.EmailId).HasName("PK__Intern__7ED91ACFB766D0D3");

            entity.Property(e => e.EmailId).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}

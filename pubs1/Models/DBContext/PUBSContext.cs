﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace pubs1.Models;

public partial class PUBSContext : DbContext
{
    public PUBSContext()
    {
    }

    public PUBSContext(DbContextOptions<PUBSContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<Store> Stores { get; set; }

    public virtual DbSet<Title> Titles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        => optionsBuilder.UseSqlServer("Data Source=TYPHAT\\SQLEXPRESS;Initial Catalog=PUBS;Persist Security Info=True;User ID=sa;Password=12345");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmpId)
                .HasName("PK_emp_id")
                .IsClustered(false);

            entity.ToTable("employee", tb => tb.HasTrigger("employee_insupd"));

            entity.HasIndex(e => new { e.Lname, e.Fname, e.Minit }, "employee_ind").IsClustered();

            entity.Property(e => e.EmpId)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("emp_id");
            entity.Property(e => e.Fname)
                .IsRequired()
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("fname");
            entity.Property(e => e.HireDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("hire_date");
            entity.Property(e => e.JobId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("job_id");
            entity.Property(e => e.JobLvl)
                .HasDefaultValueSql("((10))")
                .HasColumnName("job_lvl");
            entity.Property(e => e.Lname)
                .IsRequired()
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("lname");
            entity.Property(e => e.Minit)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("minit");
            entity.Property(e => e.PubId)
                .IsRequired()
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasDefaultValueSql("('9952')")
                .IsFixedLength()
                .HasColumnName("pub_id");
        });

        modelBuilder.Entity<Store>(entity =>
        {
            entity.HasKey(e => e.StorId).HasName("UPK_storeid");

            entity.ToTable("stores");

            entity.Property(e => e.StorId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("stor_id");
            entity.Property(e => e.City)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("city");
            entity.Property(e => e.State)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("state");
            entity.Property(e => e.StorAddress)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("stor_address");
            entity.Property(e => e.StorName)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("stor_name");
            entity.Property(e => e.Zip)
                .HasMaxLength(5)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Title>(entity =>
        {
            entity.HasKey(e => e.TitleId).HasName("UPKCL_titleidind");

            entity.ToTable("titles");

            entity.HasIndex(e => e.Title1, "titleind");

            entity.Property(e => e.TitleId)
                .HasMaxLength(6)
                .IsUnicode(false)
                .HasColumnName("title_id");
            entity.Property(e => e.Advance)
                .HasColumnType("money")
                .HasColumnName("advance");
            entity.Property(e => e.Notes)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("notes");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("price");
            entity.Property(e => e.PubId)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("pub_id");
            entity.Property(e => e.Pubdate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("pubdate");
            entity.Property(e => e.Royalty).HasColumnName("royalty");
            entity.Property(e => e.Title1)
                .IsRequired()
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("title");
            entity.Property(e => e.Type)
                .IsRequired()
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasDefaultValueSql("('UNDECIDED')")
                .IsFixedLength()
                .HasColumnName("type");
            entity.Property(e => e.YtdSales).HasColumnName("ytd_sales");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
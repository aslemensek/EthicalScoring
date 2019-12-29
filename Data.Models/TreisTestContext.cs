﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EthicalScoring.Data.Models
{
    public partial class TreisTestContext : DbContext
    {
        public TreisTestContext()
        {
        }

        public TreisTestContext(DbContextOptions<TreisTestContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EsgCriteria> EsgCriteria { get; set; }
        public virtual DbSet<EsgCriteriaScore> EsgCriteriaScore { get; set; }
        public virtual DbSet<EsgScore> EsgScore { get; set; }
        public virtual DbSet<Institution> Institution { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:treistest.database.windows.net,1433;Initial Catalog=TreisTest;Persist Security Info=False;User ID=aslemensek;Password=TreisTest007;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EsgCriteria>(entity =>
            {
                entity.Property(e => e.EsgCriteriaId).HasColumnName("esgCriteriaId");

                entity.Property(e => e.CategoryName)
                    .IsRequired()
                    .HasColumnName("categoryName")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CriteriaName)
                    .IsRequired()
                    .HasColumnName("criteriaName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.WeightAsPercentageOfTotal)
                    .HasColumnName("weightAsPercentageOfTotal")
                    .HasColumnType("decimal(9, 8)");
            });

            modelBuilder.Entity<EsgCriteriaScore>(entity =>
            {
                entity.Property(e => e.EsgCriteriaScoreId).HasColumnName("esgCriteriaScoreId");

                entity.Property(e => e.EsgCriteriaId).HasColumnName("esgCriteriaId");

                entity.Property(e => e.EsgScoreId).HasColumnName("esgScoreId");

                entity.Property(e => e.InstitutionId).HasColumnName("institutionId");

                entity.HasOne(d => d.EsgCriteria)
                    .WithMany(p => p.EsgCriteriaScore)
                    .HasForeignKey(d => d.EsgCriteriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.EsgScore)
                    .WithMany(p => p.EsgCriteriaScore)
                    .HasForeignKey(d => d.EsgScoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Institution)
                    .WithMany(p => p.EsgCriteriaScore)
                    .HasForeignKey(d => d.InstitutionId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<EsgScore>(entity =>
            {
                entity.Property(e => e.EsgScoreId).HasColumnName("esgScoreId");

                entity.Property(e => e.Score)
                    .IsRequired()
                    .HasColumnName("score")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ScoreAsPercentage)
                    .HasColumnName("scoreAsPercentage")
                    .HasColumnType("decimal(9, 8)");
            });

            modelBuilder.Entity<Institution>(entity =>
            {
                entity.Property(e => e.InstitutionId).HasColumnName("institutionId");

                entity.Property(e => e.InstitutionName)
                    .IsRequired()
                    .HasColumnName("institutionName")
                    .HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

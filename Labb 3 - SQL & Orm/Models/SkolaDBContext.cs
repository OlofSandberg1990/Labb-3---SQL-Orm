using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Labb_3___SQL___Orm.Models
{
    public partial class SkolaDBContext : DbContext
    {
        public SkolaDBContext()
        {
        }

        public SkolaDBContext(DbContextOptions<SkolaDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblBetyg> TblBetygs { get; set; } = null!;
        public virtual DbSet<TblBetygskala> TblBetygskalas { get; set; } = null!;
        public virtual DbSet<TblElever> TblElevers { get; set; } = null!;
        public virtual DbSet<TblKurser> TblKursers { get; set; } = null!;
        public virtual DbSet<TblPersonal> TblPersonals { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data source = OLOFSPC; Initial Catalog = SkolaDB; Integrated Security = True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblBetyg>(entity =>
            {
                entity.HasKey(e => e.BetygId)
                    .HasName("PK_tblBetygFörElev");

                entity.ToTable("tblBetyg");

                entity.Property(e => e.BetygId).HasColumnName("BetygID");

                entity.Property(e => e.BetygskalaId).HasColumnName("BetygskalaID");

                entity.Property(e => e.DatumFörBetyg).HasColumnType("date");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.HasOne(d => d.Betygskala)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.BetygskalaId)
                    .HasConstraintName("FK_tblBetygFörElev_tblBetygskala");

                entity.HasOne(d => d.Elev)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.ElevId)
                    .HasConstraintName("FK_tblBetygFörElev_tblElever");

                entity.HasOne(d => d.Kurs)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.KursId)
                    .HasConstraintName("FK_tblBetygFörElev_tblKurser");

                entity.HasOne(d => d.Personal)
                    .WithMany(p => p.TblBetygs)
                    .HasForeignKey(d => d.PersonalId)
                    .HasConstraintName("FK_tblBetygFörElev_tblPersonal");
            });

            modelBuilder.Entity<TblBetygskala>(entity =>
            {
                entity.HasKey(e => e.BetygskalaId);

                entity.ToTable("tblBetygskala");

                entity.Property(e => e.BetygskalaId).HasColumnName("BetygskalaID");

                entity.Property(e => e.BetygNamn)
                    .HasMaxLength(3)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblElever>(entity =>
            {
                entity.HasKey(e => e.ElevId);

                entity.ToTable("tblElever");

                entity.Property(e => e.ElevId).HasColumnName("ElevID");

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);

                entity.Property(e => e.Klass)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Personnummer)
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblKurser>(entity =>
            {
                entity.HasKey(e => e.KursId);

                entity.ToTable("tblKurser");

                entity.Property(e => e.KursId).HasColumnName("KursID");

                entity.Property(e => e.Kursnamn)
                    .HasMaxLength(30)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TblPersonal>(entity =>
            {
                entity.HasKey(e => e.PersonalId);

                entity.ToTable("tblPersonal");

                entity.Property(e => e.PersonalId).HasColumnName("PersonalID");

                entity.Property(e => e.Befattning)
                    .HasMaxLength(30)
                    .IsFixedLength();

                entity.Property(e => e.Efternamn).HasMaxLength(50);

                entity.Property(e => e.Förnamn).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Models.EF
{
    public partial class Model_shop : DbContext
    {
        public Model_shop()
            : base("name=Model_shop")
        {
        }

        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<NHANXET> NHANXETs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<USER> USERS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.DIACHI)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.THANHTIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HOADON>()
                .HasOptional(e => e.CHITIETHOADON)
                .WithRequired(e => e.HOADON)
                .WillCascadeOnDelete();

            modelBuilder.Entity<NHANXET>()
                .Property(e => e.BINHLUAN)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HINHANH)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.HANGSANXUAT)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.GIATIEN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.SIZE)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.TOPHOT)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.HOADONs)
                .WithOptional(e => e.SANPHAM)
                .WillCascadeOnDelete();

            modelBuilder.Entity<USER>()
                .Property(e => e.TEN)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .Property(e => e.REPASS)
                .IsUnicode(false);

            modelBuilder.Entity<USER>()
                .HasMany(e => e.HOADONs)
                .WithOptional(e => e.USER)
                .WillCascadeOnDelete();
        }
    }
}

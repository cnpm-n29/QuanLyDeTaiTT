namespace QuanLyDeTai.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DefaultDbContext : DbContext
    {
        public DefaultDbContext()
            : base("name=DefaultDbContext")
        {
        }

        public virtual DbSet<BoMon> BoMons { get; set; }
        public virtual DbSet<ChucVu> ChucVus { get; set; }
        public virtual DbSet<ChucVuGV> ChucVuGVs { get; set; }
        public virtual DbSet<DeTai> DeTais { get; set; }
        public virtual DbSet<DeTaiSinhVienTT> DeTaiSinhVienTTs { get; set; }
        public virtual DbSet<DiemTT> DiemTTs { get; set; }
        public virtual DbSet<GiangVien> GiangViens { get; set; }
        public virtual DbSet<HocKy> HocKies { get; set; }
        public virtual DbSet<Khoa> Khoas { get; set; }
        public virtual DbSet<LoaiTT> LoaiTTs { get; set; }
        public virtual DbSet<Nganh> Nganhs { get; set; }
        public virtual DbSet<PhanCongGV> PhanCongGVs { get; set; }
        public virtual DbSet<Quyen> Quyens { get; set; }
        public virtual DbSet<Quyen_CV> Quyen_CV { get; set; }
        public virtual DbSet<SinhVien> SinhViens { get; set; }
        public virtual DbSet<SinhVienTT> SinhVienTTs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<ThucTap> ThucTaps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BoMon>()
                .HasMany(e => e.GiangViens)
                .WithOptional(e => e.BoMon)
                .HasForeignKey(e => e.MaBM);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.ChucVuGVs)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.ID_ChucVu);

            modelBuilder.Entity<ChucVu>()
                .HasMany(e => e.Quyen_CV)
                .WithOptional(e => e.ChucVu)
                .HasForeignKey(e => e.ID_ChucVu);

            modelBuilder.Entity<GiangVien>()
                .Property(e => e.SDT)
                .IsFixedLength();

            modelBuilder.Entity<GiangVien>()
                .HasMany(e => e.ChucVuGVs)
                .WithOptional(e => e.GiangVien)
                .HasForeignKey(e => e.ID_GV);

            modelBuilder.Entity<Quyen>()
                .HasMany(e => e.Quyen_CV)
                .WithOptional(e => e.Quyen)
                .HasForeignKey(e => e.ID_Quyen);

            modelBuilder.Entity<SinhVien>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}

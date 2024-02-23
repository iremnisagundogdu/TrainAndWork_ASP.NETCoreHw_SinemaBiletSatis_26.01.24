using Microsoft.EntityFrameworkCore;
using SinemaBiletSatis.Entities;

namespace SinemaBiletSatis.Data
{
    public class DatabaseContext : DbContext
    {
        //public DatabaseContext(DbContextOptions<DatabaseContext> options)
        //    : base(options)
        //{
        //} Burayı ekleyince neden view kuramadığımı anlamadım.Buraya bakmayı unutma!! 

    public DbSet<Sinema> Sinemalar { get; set; }
        public DbSet<Salon> Salonlar { get; set; }
        public DbSet<Film> Filmler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<FilmKategori> FilmKategoriler { get; set; }
        public DbSet<Gosterim> Gosterimler { get; set; }
        public DbSet<Bilet> Biletler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Rol> Roller { get; set; }
    


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"server=LAPTOP-H6HRAGN7\SQLEXPRESS; database=SinemaBiletSatis; integrated security=True; MultipleActiveResultSets=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent API 
            modelBuilder.Entity<Rol>().HasData(new Rol
            {
                Id = 1,
                Adi = "Admin"
            });

            modelBuilder.Entity<Kullanici>().HasData(new Kullanici
            {
                Id = 1,
                Adi = "Admin",
                Soyadi="Admin",
                AktifMi = true,
                EklenmeTarihi = DateTime.Now,
                Eposta = "admin@admin.com",
                KullaniciAdi="admin",
                Sifre="123456789",
                //Rol= new Rol { Id = 1 },
                RolId= 1,
               //Biletler var İrem 

            }); ;
            base.OnModelCreating(modelBuilder);

            // FilmKategori için bileşik anahtar tanımlaması ve ilişkilerin yapılandırılması
            modelBuilder.Entity<FilmKategori>()
                .HasKey(fk => new { fk.FilmID, fk.KategoriID });

            modelBuilder.Entity<FilmKategori>()
                .HasOne(fk => fk.Film)
                .WithMany(f => f.FilmKategoriler)
                .HasForeignKey(fk => fk.FilmID);

            modelBuilder.Entity<FilmKategori>()
                .HasOne(fk => fk.Kategori)
                .WithMany(k => k.FilmKategoriler)
                .HasForeignKey(fk => fk.KategoriID);
        }
    }
}

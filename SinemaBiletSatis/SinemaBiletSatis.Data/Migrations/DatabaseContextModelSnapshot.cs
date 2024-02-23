﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SinemaBiletSatis.Data;

#nullable disable

namespace SinemaBiletSatis.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    partial class DatabaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SinemaBiletSatis.Entities.Bilet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("Fiyat")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GosterimID")
                        .HasColumnType("int");

                    b.Property<string>("KoltukNumarasi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("KullaniciID")
                        .HasColumnType("int");

                    b.Property<DateTime>("SatisTarihi")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GosterimID");

                    b.HasIndex("KullaniciID");

                    b.ToTable("Biletler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Film", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Aciklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AltyaziVarMi")
                        .HasColumnType("bit");

                    b.Property<string>("Dil")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FilmAdi")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan?>("Sure")
                        .HasColumnType("time");

                    b.Property<string>("Yonetmen")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Filmler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.FilmKategori", b =>
                {
                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<int>("KategoriID")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.HasKey("FilmID", "KategoriID");

                    b.HasIndex("KategoriID");

                    b.ToTable("FilmKategoriler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Gosterim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("FilmID")
                        .HasColumnType("int");

                    b.Property<DateTime>("GosterimSaati")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("GosterimTarihi")
                        .HasColumnType("datetime2");

                    b.Property<int>("SalonID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FilmID");

                    b.HasIndex("SalonID");

                    b.ToTable("Gosterimler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Kategori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("KategoriAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kategoriler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Kullanici", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("AktifMi")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EklenmeTarihi")
                        .HasColumnType("datetime2");

                    b.Property<string>("Eposta")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("KullaniciAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<string>("Sifre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Soyadi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RolId");

                    b.ToTable("Kullanicilar");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Admin",
                            AktifMi = true,
                            EklenmeTarihi = new DateTime(2024, 1, 26, 5, 10, 18, 845, DateTimeKind.Local).AddTicks(6729),
                            Eposta = "admin@admin.com",
                            KullaniciAdi = "admin",
                            RolId = 1,
                            Sifre = "123456789",
                            Soyadi = "Admin"
                        });
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roller");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Adi = "Admin"
                        });
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Salon", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("KoltukSayisi")
                        .HasColumnType("int");

                    b.Property<string>("SalonAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SinemaID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SinemaID");

                    b.ToTable("Salonlar");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Sinema", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adres")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SinemaAdi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Telefon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sinemalar");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Açiklama")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Baslik")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Resim")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Bilet", b =>
                {
                    b.HasOne("SinemaBiletSatis.Entities.Gosterim", "Gosterim")
                        .WithMany("Biletler")
                        .HasForeignKey("GosterimID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SinemaBiletSatis.Entities.Kullanici", "Kullanici")
                        .WithMany("Biletler")
                        .HasForeignKey("KullaniciID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gosterim");

                    b.Navigation("Kullanici");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.FilmKategori", b =>
                {
                    b.HasOne("SinemaBiletSatis.Entities.Film", "Film")
                        .WithMany("FilmKategoriler")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SinemaBiletSatis.Entities.Kategori", "Kategori")
                        .WithMany("FilmKategoriler")
                        .HasForeignKey("KategoriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Kategori");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Gosterim", b =>
                {
                    b.HasOne("SinemaBiletSatis.Entities.Film", "Film")
                        .WithMany("Gosterimler")
                        .HasForeignKey("FilmID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SinemaBiletSatis.Entities.Salon", "Salon")
                        .WithMany("Gosterimler")
                        .HasForeignKey("SalonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Film");

                    b.Navigation("Salon");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Kullanici", b =>
                {
                    b.HasOne("SinemaBiletSatis.Entities.Rol", "Rol")
                        .WithMany()
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Salon", b =>
                {
                    b.HasOne("SinemaBiletSatis.Entities.Sinema", "Sinema")
                        .WithMany("Salonlar")
                        .HasForeignKey("SinemaID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sinema");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Film", b =>
                {
                    b.Navigation("FilmKategoriler");

                    b.Navigation("Gosterimler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Gosterim", b =>
                {
                    b.Navigation("Biletler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Kategori", b =>
                {
                    b.Navigation("FilmKategoriler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Kullanici", b =>
                {
                    b.Navigation("Biletler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Salon", b =>
                {
                    b.Navigation("Gosterimler");
                });

            modelBuilder.Entity("SinemaBiletSatis.Entities.Sinema", b =>
                {
                    b.Navigation("Salonlar");
                });
#pragma warning restore 612, 618
        }
    }
}

using Core.Enums;
using Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastracture.Db
{
    public class SqlDbContext : IdentityDbContext<User, UserRole, int>
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<PublishingHouse> publishingHouses { get; set; }
        public SqlDbContext(DbContextOptions<SqlDbContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //{
        //    options.UseSqlite("Data Source= ..\\book.db");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.HasKey(e => e.UserId);
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(b => b.Id);

                entity.HasOne(b => b.Author)
                      .WithMany(a => a.Books)
                      .HasForeignKey(b => b.AuthorId);

                entity.HasOne(b => b.PublishingHouse)
                      .WithMany(p => p.Books)
                      .HasForeignKey(b => b.PublishingHouseId);
            });
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.HasMany(a => a.Books)
                      .WithOne(b => b.Author)
                      .HasForeignKey(a => a.AuthorId);
            });
            modelBuilder.Entity<PublishingHouse>(entity =>
            {
                entity.HasKey(p => p.Id);

                entity.HasMany(p => p.Books)
                      .WithOne(b => b.PublishingHouse)
                      .HasForeignKey(p => p.PublishingHouseId);
            });
            modelBuilder.Entity<Book>().HasData(
                new Book() { Id = 1, Title = "Pan Tadeusz", Description = "Epopeja Narodowa", PageNumber = 376, ReleaseDate = new DateTime(1834, 06, 28), Category = Category.Poetry, AuthorId = 1, PublishingHouseId = 1 },
                new Book() { Id = 2, Title = "Kordian", Description = "Dramat romantyczny", PageNumber = 120, ReleaseDate = new DateTime(1834, 09, 20), Category = Category.Romance, AuthorId = 2, PublishingHouseId = 1 });

            modelBuilder.Entity<Author>().HasData(
                new Author() { Id = 1, FirstName = "Adam", LastName = "Mickiewicz", DateOfBirth = new DateTime(1798, 12, 24) },
                new Author() { Id = 2, FirstName = "Juliusz", LastName = "Słowacki", DateOfBirth = new DateTime(1809, 09, 04) });

            modelBuilder.Entity<PublishingHouse>().HasData(
                new PublishingHouse() { Id = 1, Name = "Przez Twórcę", Address = "Nie Dotyczy"},
                new PublishingHouse() { Id = 2, Name = "Tygodnik", Address = "Kraków" },
                new PublishingHouse() { Id = 3, Name = "Gazeta", Address = "Warszawa" }
            );
        }
    }
}

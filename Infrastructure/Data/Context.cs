using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ArticleOfferContext : DbContext
    {
        public ArticleOfferContext(DbContextOptions options) : base(options)
        {

        }

        DbSet<Article> Articles { get; set; }
        DbSet<Offer> Offers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Offer>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Offers)
                .UsingEntity<ArticleOfferItem>(
                    l => l.HasOne<Offer>(e => e.Offer).WithMany(e => e.ArticleOfferItems).HasForeignKey(e => e.OfferId));

            modelBuilder.Entity<Offer>()
                .HasMany(e => e.Articles)
                .WithMany(e => e.Offers)
                .UsingEntity<ArticleOfferItem>(
                    r => r.HasOne<Article>(e => e.Article).WithMany(e => e.ArticleOfferItems).HasForeignKey(e => e.ArticleId));
            
            modelBuilder.Entity<Offer>().Navigation(e => e.Articles).AutoInclude();
            modelBuilder.Entity<Offer>().Navigation(e => e.ArticleOfferItems).AutoInclude();
            modelBuilder.Entity<Offer>().Property(e => e.Date).IsRequired();

            modelBuilder.Entity<Article>().Property(e => e.ArticleName).IsRequired();
            modelBuilder.Entity<Article>().Property(e => e.ArticleDescription).IsRequired();
            modelBuilder.Entity<Article>().Property(e => e.Price).IsRequired();

            modelBuilder.Entity<ArticleOfferItem>().Property(e => e.Quantity).IsRequired();
            modelBuilder.Entity<ArticleOfferItem>().Property(e => e.UnitPrice).IsRequired();


            // Insert dummy data on inital migration

            modelBuilder.Entity<Article>().HasData(new Article() { Id = 1, ArticleName = "item1", ArticleDescription = "desc1", Price = 10 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 2, ArticleName = "item2", ArticleDescription = "desc1", Price = 22 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 3, ArticleName = "item3", ArticleDescription = "desc1", Price = 3 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 4, ArticleName = "item4", ArticleDescription = "desc1", Price = 40 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 5, ArticleName = "item5", ArticleDescription = "desc1", Price = 52 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 6, ArticleName = "item6", ArticleDescription = "desc1", Price = 62 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 7, ArticleName = "item7", ArticleDescription = "desc1", Price = 17 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 8, ArticleName = "item8", ArticleDescription = "desc1", Price = 28 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 9, ArticleName = "item9", ArticleDescription = "desc1", Price = 39 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 10, ArticleName = "item10", ArticleDescription = "desc1", Price = 10 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 11, ArticleName = "item11", ArticleDescription = "desc1", Price = 11 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 12, ArticleName = "item12", ArticleDescription = "desc1", Price = 1 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 13, ArticleName = "item13", ArticleDescription = "desc1", Price = 21 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 14, ArticleName = "item14", ArticleDescription = "desc1", Price = 22 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 15, ArticleName = "item15", ArticleDescription = "desc1", Price = 13 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 16, ArticleName = "item16", ArticleDescription = "desc1", Price = 100 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 17, ArticleName = "item17", ArticleDescription = "desc1", Price = 114 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 18, ArticleName = "item18", ArticleDescription = "desc1", Price = 13 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 19, ArticleName = "item19", ArticleDescription = "desc1", Price = 221 });
            modelBuilder.Entity<Article>().HasData(new Article() { Id = 20, ArticleName = "item20", ArticleDescription = "desc1", Price = 111 });

            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 1, Date = new DateTime(2024, 11, 1)});
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 2, Date = new DateTime(2024, 11, 2) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 3, Date = new DateTime(2024, 11, 3) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 4, Date = new DateTime(2024, 11, 4) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 5, Date = new DateTime(2024, 11, 5) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 6, Date = new DateTime(2024, 11, 6) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 7, Date = new DateTime(2024, 11, 7) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 8, Date = new DateTime(2024, 11, 8) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 9, Date = new DateTime(2024, 11, 9) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 10, Date = new DateTime(2024, 11, 10) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 11, Date = new DateTime(2024, 11, 11) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 12, Date = new DateTime(2024, 11, 12) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 13, Date = new DateTime(2024, 11, 13) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 14, Date = new DateTime(2024, 11, 14) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 15, Date = new DateTime(2024, 11, 15) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 16, Date = new DateTime(2024, 11, 16) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 17, Date = new DateTime(2024, 11, 17) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 18, Date = new DateTime(2024, 11, 18) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 19, Date = new DateTime(2024, 11, 18) });
            modelBuilder.Entity<Offer>().HasData(new Offer() { Id = 20, Date = new DateTime(2024, 11, 20) });

            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 1, UnitPrice = 10, Quantity = 2});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 4, UnitPrice = 10, Quantity = 4});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 8, UnitPrice = 10, Quantity = 1});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 20, UnitPrice = 10, Quantity = 2});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 18, UnitPrice = 10, Quantity = 3});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 7, UnitPrice = 10, Quantity = 4});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 2, UnitPrice = 10, Quantity = 3});
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 1, ArticleId = 15, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 2, ArticleId = 1, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 2, ArticleId = 4, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 2, ArticleId = 13, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 3, ArticleId = 15, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 4, ArticleId = 7, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 4, ArticleId = 2, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 5, ArticleId = 1, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 6, ArticleId = 1, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 6, ArticleId = 4, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 7, ArticleId = 3, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 8, ArticleId = 5, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 9, ArticleId = 10, UnitPrice = 10, Quantity = 32 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 10, ArticleId = 1, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 10, ArticleId = 18, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 11, ArticleId = 11, UnitPrice = 10, Quantity = 33 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 12, ArticleId = 12, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 13, ArticleId = 6, UnitPrice = 10, Quantity = 34 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 14, ArticleId = 4, UnitPrice = 10, Quantity = 11 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 14, ArticleId = 5, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 14, ArticleId = 12, UnitPrice = 10, Quantity = 4 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 15, ArticleId = 8, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 16, ArticleId = 19, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 17, ArticleId = 19, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 18, ArticleId = 4, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 2, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 6, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 7, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 11, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 12, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 14, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 15, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 18, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 19, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 19, ArticleId = 20, UnitPrice = 10, Quantity = 3 });
            modelBuilder.Entity<ArticleOfferItem>().HasData(new ArticleOfferItem() { OfferId = 20, ArticleId = 10, UnitPrice = 10, Quantity = 3 });
        }
    }
}

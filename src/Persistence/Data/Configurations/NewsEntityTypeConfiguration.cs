using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Domain.News;

namespace Project.Persistence.Data.Configurations
{
    public class NewsEntityTypeConfiguration : IEntityTypeConfiguration<NewsArticle>
    {
        public void Configure(EntityTypeBuilder<NewsArticle> builder)
        {
            builder.Property(c => c.Title).IsRequired();
            builder.Property(c => c.NewsText).IsRequired();
            builder.Property(c => c.Image).IsRequired();

            builder.HasOne(n => n.Author).WithMany(d => d.NewsArticles).IsRequired();
            builder.HasOne(n => n.Category).WithMany(c => c.NewsArticles).IsRequired();

        }
    }
}

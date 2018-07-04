using FluentApiEFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiEFCoreExample.EntityConfigurations
{
    public class ArticleCategoryConfig : EntityConfiguration<ArticleCategory>, IEntityTypeConfiguration<ArticleCategory>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            DefaultConfigs(builder, tableName: "ARTICLES_CATEGORIES");


            // Relacionamento N x N
            builder.HasOne(x => x.Article)
                .WithMany(x => x.CategoryArticles)
                .HasForeignKey("ArticleUId")
                .IsRequired();

            // Relacionamento N x N
            builder.HasOne(x => x.Category)
                .WithMany(x => x.CategoryArticles)
                .HasForeignKey("CategoryUId")
                .IsRequired();
        }
    }
}

using FluentApiEFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiEFCoreExample.EntityConfigurations
{
    public class ArticleConfig : EntityConfiguration<Article>, IEntityTypeConfiguration<Article>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            // Com este método, já configuramos as propriedades comuns,
            // bem como nome da tabela e a chave primária
            DefaultConfigs(builder, tableName: "ARTICLES");

            // Crio um index na propriedade de título e marco como único,
            // ou seja, eu garato que jamais havará 2 ou mais títulos iguais
            // em nossa base
            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Title)  // Pego a propriedade de título
                .HasMaxLength(120)          // Informo que o título poderá ter no máximo 50 caracters
                .IsRequired();              // Informo que o título é obrigatório em nossa base

            builder.Property(x => x.Body)  // Pego a propriedade de corpo do artigo
                .IsRequired();             // Informo que o corpo do artigo é obrigatório
        }
    }
}

using FluentApiEFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiEFCoreExample.EntityConfigurations
{
    public class CategoryConfig : EntityConfiguration<Category>, IEntityTypeConfiguration<Category>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            // Com este método, já configuramos as propriedades comuns,
            // bem como nome da tabela e a chave primária
            DefaultConfigs(builder, tableName: "CATEGORIES");

            // Crio um index na propriedade de nome da categoria e marco como único,
            // ou seja, eu garato que jamais havará 2 ou mais nomes de categorias iguais
            // em nossa base
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Name).HasMaxLength(45).IsRequired();
        }
    }
}

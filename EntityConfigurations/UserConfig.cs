using FluentApiEFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiEFCoreExample.EntityConfigurations
{
    public class UserConfig : EntityConfiguration<User>, IEntityTypeConfiguration<User>, IEntityConfig
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Com este método, já configuramos as propriedades comuns,
            // bem como nome da tabela e a chave primária
            DefaultConfigs(builder, tableName: "USERS");

            // Crio um index na propriedade de e-mail e marco como única,
            // ou seja, eu garato que jamais havará 2 ou mais e-mails iguais
            // em nossa base
            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.Name)   // Pego a propriedade de nome
                .HasMaxLength(45)           // Informo que o nome poderá ter no máximo 45 caracters
                .IsRequired();              // Informo que o nome é obrigatório

            builder.Property(x => x.Email) // Pego a propriedade de email
                .HasMaxLength(45)          // Informo que o e-mail poderá ter no máximo 45 caracters
                .IsRequired();             // Informo que o e-mail é obrigatório


            // Relacionamento 1 para N: Um usuário pode ter vários artigos.
            // Um artigo só pode ser de um usuário
            builder
                .HasMany(x => x.Articles)   // Atribuimos a relação de N
                .WithOne(x => x.User)       // Atribuimos a relação principal
                .HasForeignKey("UserUId");  // Damos o nome que quisermos para a nossa chave estrangeira
        }
    }
}

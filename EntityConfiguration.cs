using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FluentApiEFCoreExample
{
    public class EntityConfiguration<TEntity> where TEntity : Entity
    {
        public void DefaultConfigs(EntityTypeBuilder<TEntity> builder, string tableName)
        {
            builder.ToTable(tableName);
            builder.HasKey(x => x.UId);

            builder.Property(x => x.CreatedAt).IsRequired();
        }
    }
}

using FluentApiEFCoreExample.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace FluentApiEFCoreExample
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) 
            : base(options)
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui estou obtendo todas as classes de configuração das entidades.
            // através da interface IEntityConfig, criada única e exclusivamente para isto.
            // Sendo assim, não precisamos lembrar de, ao criar a configuração de alguma entidade, colocar mais uma linha de código neste trecho.
            var typesToRegister = AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => typeof(IEntityConfig).IsAssignableFrom(x) && !x.IsAbstract).ToList();

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }
        }
    }
}

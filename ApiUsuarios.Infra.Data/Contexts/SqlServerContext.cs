using ApiUsuarios.Domain.Models;
using ApiUsuarios.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuarios.Infra.Data.Contexts
{
    /// <summary>
    /// Classe de contexto do EntityFramework para acesso ao banco de dados
    /// </summary>
    public class SqlServerContext : DbContext
    {
        /// <summary>
        /// Método para configurar o banco de dados do projeto
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DEV");
        }

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
        }

        /// <summary>
        /// Unidade de trabalho para a entidade Usuário (CRUD)
        /// </summary>
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
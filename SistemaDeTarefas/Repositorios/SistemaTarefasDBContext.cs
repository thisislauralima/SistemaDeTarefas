using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data.Map;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces.Context;
namespace SistemaDeTarefas.Repository.Context
{
    public class SistemaTarefasDBContext : DbContext, IContext
    {
        public virtual DbSet<UsuarioModel> Usuarios { get; set; }
        public virtual DbSet<TarefaModel> Tarefas { get; set; }

        public SistemaTarefasDBContext() { }

        public SistemaTarefasDBContext(DbContextOptions<SistemaTarefasDBContext> options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=127.0.0.1;Database=SistemaDeTarefas;User=sa;Password=Minhasenha12!;TrustServerCertificate=True");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Models;
using System.Collections.Generic;

namespace SistemaDeTarefas.Repositorios.Interfaces.Context
{
    public interface IContext
    {
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<TarefaModel> Tarefas { get; set; }
    }
}

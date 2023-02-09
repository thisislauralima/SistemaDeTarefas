using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces.Usuario;
using SistemaDeTarefas.Repository.Context;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext context)
        {
            // Dando acesso a todas as tabelas do db
            _dbContext = context;
        }

        public UsuarioModel DBBuscarPorId(int id) => _dbContext.Usuarios.FirstOrDefault(x => x.Id == id);


        public List<UsuarioModel> DBBuscarTodosUsuarios()
        {
            var query = from u in _dbContext.Usuarios
                        orderby u.Nome
                        select u;
            return query.ToList();
        }

        public UsuarioModel DBAdicionar(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
            return usuario;
        }

        public void DBApagar(UsuarioModel usuarioPorId)
        {
            _dbContext.Usuarios.Remove(usuarioPorId);
            _dbContext.SaveChanges();
        }

        public UsuarioModel DBAtualizar(UsuarioModel usuarioAtualizado)
        {
            var usuarioParaAtualizar = DBBuscarPorId(usuarioAtualizado.Id);

            usuarioParaAtualizar.Nome = usuarioAtualizado.Nome;
            usuarioParaAtualizar.Email = usuarioAtualizado.Email;

            _dbContext.Usuarios.Update(usuarioParaAtualizar);
            _dbContext.SaveChanges();

            return usuarioAtualizado;
        }
    }
}
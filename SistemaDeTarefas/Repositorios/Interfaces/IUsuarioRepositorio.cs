using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Repositorios.Interfaces.Usuario
{
    public interface IUsuarioRepositorio
    {
        List<UsuarioModel> DBBuscarTodosUsuarios();
        UsuarioModel DBBuscarPorId(int id);
        UsuarioModel DBAdicionar(UsuarioModel usuario);
        UsuarioModel DBAtualizar(UsuarioModel usuario);
        void DBApagar(UsuarioModel usuarioPorId);
    }
}
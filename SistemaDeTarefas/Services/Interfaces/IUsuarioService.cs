using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Services.Interfaces.Usuario
{
    public interface IUsuarioService
    {
        List<UsuarioModel> BuscarTodosUsuarios();
        UsuarioModel BuscarPorId(int id);
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);
        void Apagar(UsuarioModel usuario);
    }
}
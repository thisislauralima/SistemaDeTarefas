using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces.Usuario;
using SistemaDeTarefas.Services.Interfaces.Usuario;

namespace SistemaDeTarefas.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepositorio _repositorio;

        public UsuarioService(IUsuarioRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public UsuarioModel BuscarPorId(int id)
        {
            return _repositorio.DBBuscarPorId(id);
        }

        public List<UsuarioModel> BuscarTodosUsuarios()
        {
            return _repositorio.DBBuscarTodosUsuarios();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            return _repositorio.DBAdicionar(usuario);
        }

        public void Apagar(UsuarioModel usuarioPorId)
        {
            _repositorio.DBApagar(usuarioPorId);
        }

        public UsuarioModel Atualizar(UsuarioModel usuarioAtualizado)
        {
            return _repositorio.DBAtualizar(usuarioAtualizado);
        }
    }
}
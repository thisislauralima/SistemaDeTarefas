using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Services.Interfaces.Usuario;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _service;

        public UsuarioController(IUsuarioService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<UsuarioModel>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<List<UsuarioModel>> BuscarTodosUsuariosController()
        {
             return _service.BuscarTodosUsuarios();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<UsuarioModel>), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<List<UsuarioModel>> BuscarUsuarioPorIdController(int id)
        {
            var usuario = _service.BuscarPorId(id);
            if (usuario == null)
            {
                return NotFound($"Pessoa usuária de id {id} não encontrada.");
            }
            return Ok(usuario);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(UsuarioModel))]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<UsuarioModel> AdicionaUsuarioController([FromBody] UsuarioModel usuario)
        {
            _service.Adicionar(usuario);
            return new ObjectResult(usuario.Id) { StatusCode = 201 };
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(204)]
        [ProducesResponseType(500)]
        public ActionResult<UsuarioModel> DeletarUsuarioController(int id)
        {
            var usuarioPorId = _service.BuscarPorId(id);
            if (usuarioPorId == null)
            {
                return NotFound("Pessoa usuária não encontrada.");
            }
            _service.Apagar(usuarioPorId);
            return NoContent();
        }

        [HttpPut]
        [ProducesResponseType(200, Type = typeof(UsuarioModel))]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<UsuarioModel> AtualizarUsuarioController([FromBody] UsuarioModel usuario)
        {
            var usuarioPorId = _service.BuscarPorId(usuario.Id);
            if (usuarioPorId == null)
            {
                return NotFound("Pessoa usuária não encontrada.");
            }
            _service.Atualizar(usuarioPorId);
            return Ok(usuario);
        }
    }
}
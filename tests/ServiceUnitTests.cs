using Moq;
using NUnit.Framework;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces.Usuario;
using SistemaDeTarefas.Service;
using Assert = NUnit.Framework.Assert;

namespace tests
{
    internal class ServiceUnitTests
    {
        private readonly Mock<IUsuarioRepositorio> _mockRepository;

        private readonly UsuarioService _service;

        public ServiceUnitTests()
        {
            _mockRepository = new Mock<IUsuarioRepositorio>();
            _service = new UsuarioService(_mockRepository.Object);
        }

        [Test]
        public void Adicionar()
        {
            // Arrange
            var sampleUser = new UsuarioModel() { Nome = "teste", Email = "teste@email.com" };

            _mockRepository.Setup(x => x.DBAdicionar(It.IsAny<UsuarioModel>())).Returns(sampleUser);


            // Act
            var response = _service.Adicionar(sampleUser);

            // Assert
            Assert.AreEqual(response, sampleUser);
            Assert.That(response.Nome, Is.EqualTo("teste"));
            Assert.That(response.Email, Is.EqualTo("teste@email.com"));
        }

        [Test]
        public void Buscar_Todos_Usuarios()
        {
            // Arrange
            var sampleData = new List<UsuarioModel>()
            {
                new UsuarioModel() { Id = 0, Nome = "Joao", Email = "joao@email.com" },
                new UsuarioModel() { Id = 1, Nome = "Maria", Email = "maria@email.com" },
            };

            // Act
            _mockRepository.Setup(x => x.DBBuscarTodosUsuarios()).Returns(sampleData);

            var response = _service.BuscarTodosUsuarios();

            // Assert
            Assert.That(response.Count(), Is.EqualTo(2));
            Assert.That(response[0].Nome, Is.EqualTo("Joao"));
            Assert.That(response[1].Nome, Is.EqualTo("Maria"));
        }

        [Test]
        public void Buscar_Por_Id()
        {
            // Arrange
            var sampleData = new UsuarioModel() { Id = 1, Nome = "Maria", Email = "maria@email.com" };

            _mockRepository.Setup(x => x.DBBuscarPorId(1)).Returns(sampleData);

            // Act
            var response = _service.BuscarPorId(1);

            // Assert
            //response.Nome.Should().Be("Maria");
            Assert.That(response.Nome, Is.EqualTo("Maria"));
        }

        [Test]
        public void Apagar()
        {
            // Arrange
            var sampleUser = new UsuarioModel() { Id = 1, Nome = "teste", Email = "teste@email.com" };

            _mockRepository.Setup(x => x.DBApagar(sampleUser));

            // Act
            _service.Apagar(sampleUser);

            // Assert
            _mockRepository.Verify(x => x.DBApagar(sampleUser));
        }

        [Test]
        public void Atualizar()
        {
            // Arrange
            var sampleUser = new UsuarioModel() { Id = 1, Nome = "teste", Email = "teste@email.com" };

            _mockRepository.Setup(x => x.DBAtualizar(sampleUser)).Returns(sampleUser);

            // Act
            _service.Atualizar(sampleUser);

            // Assert
            _mockRepository.Verify(x => x.DBAtualizar(sampleUser), Times.Once());
        }
    }
}

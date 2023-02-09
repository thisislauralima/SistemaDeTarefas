using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using NUnit.Framework;
using SistemaDeTarefas.Models;
using System.Net;
using System.Text;

namespace SistemaDeTarefasIntegrationTests
{
    public class SistemaDeTarefasIntegrationTest
    {
        private HttpClient _httpClient;

        public SistemaDeTarefasIntegrationTest()
        {

            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [Test]
        public async Task AdicionaUsuarioController_WhenPassedCorrectUser_Returns200OK()
        {
            var user = new UsuarioModel() { Nome = "teste", Email = "teste@email.com" };
            var serializedUser = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(serializedUser, UnicodeEncoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/usuario", stringContent);

            Assert.That(HttpStatusCode.Created, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task BuscarTodosUsuariosController_Returns200OK()
        {
            var response = await _httpClient.GetAsync("api/usuario");

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task BuscarUsuarioPorIdController_WhenPassedInexistentId_Returns404()
        {
            var response = await _httpClient.GetAsync($"api/usuario{3}");

            Assert.That(HttpStatusCode.NotFound, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task DeletarUsuarioController_WhenPassedInexistentId_ShouldReturn404()
        {
            var response = await _httpClient.DeleteAsync($"api/usuario/{999}");

            Assert.That(HttpStatusCode.NotFound, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task DeletarUsuarioController_WhenPassedCorrectId_ShouldReturn204()
        {
            var response = await _httpClient.DeleteAsync($"api/usuario/{2}");

            Assert.That(HttpStatusCode.NoContent, Is.EqualTo(response.StatusCode));
        }

        [Test]
        public async Task AtualizarUsuarioController_WhenPassedCorrectIdAndUser_ShouldReturnOk()
        {
            var user = new UsuarioModel() { Id = 3, Nome = "Maria", Email = "Maria@email.com" };
            var serializedUser = JsonConvert.SerializeObject(user);
            var stringContent = new StringContent(serializedUser, UnicodeEncoding.UTF8, "application/json");

            var response = await _httpClient.PutAsync("api/usuario", stringContent);

            Assert.That(HttpStatusCode.OK, Is.EqualTo(response.StatusCode));
        }

        //private async Task postUserToTest()
        //{
        //    var user = new UsuarioModel() { Nome = "Maria", Email = "Maria@email.com" };
        //    var serializedUser = JsonConvert.SerializeObject(user);
        //    var stringContent = new StringContent(serializedUser, UnicodeEncoding.UTF8, "application/json");

        //    await _httpClient.PostAsync("api/usuario", stringContent);

        //    var user2 = new UsuarioModel() { Nome = "Joao", Email = "joao@email.com" };
        //    var serializedUser2 = JsonConvert.SerializeObject(user2);
        //    var stringContent2 = new StringContent(serializedUser2, UnicodeEncoding.UTF8, "application/json");

        //    await _httpClient.PostAsync("api/usuario", stringContent2);
        //}
    }
}
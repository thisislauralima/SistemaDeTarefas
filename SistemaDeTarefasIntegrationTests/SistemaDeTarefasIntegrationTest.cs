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
        public async Task BuscarTodosUsuariosController_WhenOccursInternalError_ShouldReturn500()
        {
            var response = await _httpClient.GetAsync("api/usuario");

            Assert.That(HttpStatusCode.InternalServerError, Is.EqualTo(response.StatusCode));
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
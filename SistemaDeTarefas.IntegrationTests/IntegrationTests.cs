using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace SistemaDeTarefas.IntegrationTests
{
    public class SistemaDeTarefasIntegrationTests
    {
        [Fact]
        public async Task HelloWorldTest()
        {
            var application = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureTestServices(services => {
                        var options = new SistemaTarefasDBContext<ApiContext>()
                                        .UseSqlServer(TestingConstants.SqlConnection)
                                        .Options;
                        services.AddSingleton(options);
                        services.AddSingleton<ApiContext>();
                        services.AddSingleton(NotificationServiceFake);
                    });
                });

            var client = application.CreateClient();
            //...
        }
    }
}
using System;
using System.Net.Http;
using System.Threading.Tasks;
using IdentityModel.Client;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;
using Newtonsoft.Json.Linq;

namespace Mmu.IdentityProvider.TestConsole.Areas.Commands
{
    public class ClientCredentials : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;

        public string Description { get; } = "Do something";
        public ConsoleKey Key { get; } = ConsoleKey.F1;

        public ClientCredentials(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public async Task ExecuteAsync()
        {
            var client = new HttpClient();

            var disco = await client.GetDiscoveryDocumentAsync("http://localhost:5000");
            if (disco.IsError)
            {
                Console.WriteLine(disco.Error);
                return;
            }

            var tokenResponse = await client.RequestClientCredentialsTokenAsync(
                new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "ConsoleClient",
                    ClientSecret = "secret",
                    Scope = "api.write"
                });

            if (tokenResponse.IsError)
            {
                Console.WriteLine(tokenResponse.Error);
                return;
            }

            Console.WriteLine(tokenResponse.Json);
            Console.WriteLine("\n\n");

            var apiClient = new HttpClient();
            apiClient.SetBearerToken(tokenResponse.AccessToken);

            var response = await apiClient.GetAsync("http://localhost:5000/api/accounts");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(JArray.Parse(content).ToString());

                _consoleWriter.WriteLine(content);
            }
        }
    }
}
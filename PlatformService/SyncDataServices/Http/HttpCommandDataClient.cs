using System;
using System.Net.Http;
using System.Threading.Tasks;
using PlatformService.Dtos;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
         private readonly HttpClient _httpClient;
         private readonly IConfiguration _configuration;

         public HttpCommandDataClient(HttpClient httpClient, IConfiguration configuration)
         {
             _httpClient = httpClient;
             _configuration = configuration;
         }


         public async Task SendPlatformToCommand(PlatformReadDto plat)
         {
              var httpContent = new StringContent(
                   JsonSerializer.Serialize(plat),
                   Encoding.UTF8,
                   "application/json"
              );

               /*We need to not hardcode this, we put in appsettings.Development.json*/
              var res = await _httpClient.PostAsync($"{_configuration["CommandService"]}", httpContent);

              if(res.IsSuccessStatusCode){
                   Console.WriteLine("---> Sync POST to Command Service was OK!");
              }else
              {
                  Console.WriteLine("---> Sync POST to CommandService was NOT OK!");
              }
         }
    }
}
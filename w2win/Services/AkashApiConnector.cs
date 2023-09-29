using System.Collections.Concurrent;
using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using Amazon.Runtime;
using MongoDB.Bson;
using Proj.Models;
namespace Proj.Services
{
    public class AkashApiConnector : IAkashApiConnector
    {
        private readonly HttpClient _httpClient;
        
        public AkashApiConnector()
        {
            HttpClientHandler clientHandler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; }
            };
            _httpClient = new HttpClient(clientHandler)
            {
                Timeout = TimeSpan.FromSeconds(10)
            };
        }
        public async Task<HostDto[]> GetHostData(OwnerDto[] ownerDtos,string batchId)
        {
            ThreadSafeCounter counter = new ThreadSafeCounter(){
                goal = ownerDtos.Length
            };
            System.Console.WriteLine("Starting HostData Gathering");
            var hostTasks = ownerDtos.Select(async owner =>
            {
                return await TryToResolveHost(owner,counter,batchId);
            }).ToArray();

            var hostDatas = await Task.WhenAll(hostTasks);
            return hostDatas;
        }
        private async Task<HostDto> TryToResolveHost(OwnerDto owner,ThreadSafeCounter counter,string batchId)
        {
            var uri = $"{owner.Provider.host_uri}/status".Replace("https://", "http://");
            
            try
            {
                var responseMessage = await _httpClient.GetAsync(uri);
                var messageData = System.Text.Encoding.UTF8.GetBytes(await responseMessage.Content.ReadAsStringAsync());
                var hostDto = new HostDto()
                {
                    ownerId = owner.OwnerId,
                    HostName = uri,
                    jsonDataBase64 = Convert.ToBase64String(messageData),
                    PollDate = DateTime.UtcNow,
                    Active = true,
                    BatchId = batchId
                };
                counter.Increment();
                System.Console.WriteLine($"{counter.Count}/{counter.goal}");
                return hostDto;
            }
            catch (Exception ex)
            {
                counter.Increment();
                System.Console.WriteLine($"{counter.Count}/{counter.goal}");
                return new HostDto()
                {
                    ownerId = owner.OwnerId,
                    HostName = uri,
                    jsonDataBase64 = $"{ex}",
                    PollDate = DateTime.UtcNow,
                    Active = false,
                    BatchId = batchId
                };
            }
            
        }
        public async Task<OwnerDto[]> GetOwnerData(string batchId)
        {
            var output = new List<OwnerDto>();
            var responseMessage = await _httpClient.GetStringAsync("https://akash-api.polkachu.com/akash/provider/v1beta3/providers");
            var ownerData = JsonSerializer.Deserialize<Root>(responseMessage);
            foreach (var provider in ownerData.providers)
            {
                output.Add(new OwnerDto()
                {
                    OwnerId = provider.owner,
                    Provider = provider,
                    PollDate = DateTime.UtcNow,
                    BatchId = batchId
                });
            }
            return output.ToArray();
        }
    }
}
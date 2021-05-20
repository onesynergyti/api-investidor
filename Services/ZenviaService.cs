using API_Investidor.Models.Zenvia;
using API_Investidor.Options;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace API_Investidor.Services
{
    public interface IZenviaService
    {
        Task<SendSmsResponse> EnviarSMSAsync(SendSmsRequest request);
    }

    public class ZenviaService : IZenviaService
    {
        private readonly HttpClient _httpClient;
        private readonly IOptions<ZenviaOptions> _zenviaOptions;

        public ZenviaService(IOptions<ZenviaOptions> options)
        {
            _httpClient = new HttpClient { Timeout = TimeSpan.FromSeconds(20) };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", options.Value.Authorization);

            _zenviaOptions = options;
        }


        public async Task<SendSmsResponse> EnviarSMSAsync(SendSmsRequest request)
        {
            var json = new StringContent(
                JsonSerializer.Serialize(request),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync(_zenviaOptions.Value.UriSendMessage, json);

            return JsonSerializer.Deserialize<SendSmsResponse>(await response.Content.ReadAsStringAsync());
        }
    }
}

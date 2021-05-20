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
        Task<SendSmsResponse> EnviarCodigoSMSAsync(string numero, string codigo);
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


        public async Task<SendSmsResponse> EnviarCodigoSMSAsync(string numero, string codigo)
        {
            // Garante o código DDI Brasil
            numero = numero.Substring(0, 2) == "55" ? numero : "55" + numero;

            SendSmsRequest request = new SendSmsRequest
            {
                from = _zenviaOptions.Value.From,
                msg = _zenviaOptions.Value.MensagemCodigo.Replace(_zenviaOptions.Value.TagCodigo, codigo),
                to = numero
            };

            var json = new StringContent(
                JsonSerializer.Serialize(new { sendSmsRequest = request }),
                Encoding.UTF8,
                "application/json");

            var response = await (await _httpClient.PostAsync(_zenviaOptions.Value.UriSendMessage, json)).Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ReturnSendSmsResponse>(response).sendSmsResponse;
        }
    }
}

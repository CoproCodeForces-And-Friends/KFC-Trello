using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KFCTrello.Models;
using Newtonsoft.Json;

namespace KFCTrello
{
    public class TrelloAdapter
    {
        private const string PatrickUrl = "https://api.trello.com/1/tokens/ed6d251e8c92f1f5774439bf374aab4d3fcea025aa3939c224f8c3f8a61f0283/webhooks/";

        private readonly HttpClient _httpClient;

        public TrelloAdapter()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5),
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };
        }
        
        public async Task RegisterInTrello(WebhookTokenRegister token)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(token), Encoding.UTF8, "application/json");
                var response = await _httpClient.PostAsync(PatrickUrl, content);
                if (!response.IsSuccessStatusCode)
                {
                    throw new Exception();
                }
            }
            catch (Exception e)
            {
                //сюда бы логи :\
                throw new Exception();
            }
        }
    }
}
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KFCTrello.Models;
using Microsoft.Azure.KeyVault.Models;
using Newtonsoft.Json;

namespace KFCTrello
{
    public class KFCServiceAdapter
    {
        private const string PatrickUrl = "http://localhost:500/api/Storage/StoreData";

        private readonly HttpClient _httpClient;

        public KFCServiceAdapter()
        {
            _httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5),
                DefaultRequestHeaders = {Accept = {new MediaTypeWithQualityHeaderValue("application/json")}}
            };
        }

        public async Task SendToStorage(WebhookModel hook)
        {
            var storageHook = new StorageSaveModel()
            {
                Id = hook.Action.Id,
                Name = hook.Action.Data.Board.Name,
                Description = hook.Action.Data.Board.Id,
                Status = "Ok",
                CreatorId = hook.Action.IdMemberCreator,
                DeveloperId = hook.Action.MemberCreator.FullName,
                Labels = new[] {"I", "want", "to", "sleep"},
                ProjectId = hook.Action.Id,
                RelatedIssue = new[]
                {
                    new RelatedIssue()
                    {
                        IssueId = hook.Action.Data.Card.Id,
                        ConnectionType = hook.Action.Data.Card.Name
                    }
                },
                CreationDate = hook.Action.Date,
                UpdatedDate = hook.Action.Date
            };
            await SendTrelloWebhoock(storageHook);
        }
        
        private async Task SendTrelloWebhoock(StorageSaveModel hook)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(hook), Encoding.UTF8, "application/json");
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
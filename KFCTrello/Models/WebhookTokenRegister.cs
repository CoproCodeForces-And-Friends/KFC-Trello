using Newtonsoft.Json;

namespace KFCTrello.Models
{
    public class WebhookTokenRegister
    {
        public WebhookTokenRegister()
        {
            Key = "b2784d0964076d7f2e2c740896ddfdd1";
            CallbackUrl = "http://www.mywebsite.com/trelloCallback222";
            Description = "KFC Trello hook";
            IdModel = "4d5ea62fd76aa1136000000c";
        }
    
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("callbackURL")]
        public string CallbackUrl { get; set; }
        
        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("idModel")]
        public string IdModel { get; set; }
    }
}
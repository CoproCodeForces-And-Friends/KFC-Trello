using System.Threading.Tasks;
using KFCTrello.Models;
using Microsoft.AspNetCore.Mvc;

namespace KFCTrello.Controllers
{
    [Route("api/trello/webhook")]
    public class WebhookContoller : Controller
    {
        // PUT api/webhook
        [HttpPut]
        public async Task PutHook()
        {
            await WebhookHelper.WebhookRegister();
            
        }

        // POST api/webhook
        [HttpPost]
        public async Task PostHook([FromBody] WebhookModel hook)
        {
            await WebhookHelper.ToPatrickServiceSender(hook);
        }
    }
}
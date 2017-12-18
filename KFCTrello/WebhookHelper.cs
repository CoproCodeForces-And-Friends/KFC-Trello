using System;
using System.Data;
using System.Threading.Tasks;
using KFCTrello.Models;

namespace KFCTrello
{
    public static class WebhookHelper
    {
        private static readonly Lazy<KFCServiceAdapter> Adapter = new Lazy<KFCServiceAdapter>(() => new KFCServiceAdapter());
        private static readonly Lazy<TrelloAdapter> TrelloAdapter = new Lazy<TrelloAdapter>(() => new TrelloAdapter());
        
        public static async Task WebhookRegister()
        {
            await TrelloAdapter.Value.RegisterInTrello(new WebhookTokenRegister());
        }

        public static async Task ToPatrickServiceSender(WebhookModel hook)
        {
            await Adapter.Value.SendToStorage(hook);
        }
    }
}
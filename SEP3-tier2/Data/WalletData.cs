using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class WalletData : IWalletData
    {
        
        public async Task<IList<Wallet>>getAllWallets()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/wallet");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Wallet> chat = JsonSerializer.Deserialize<IList<Wallet>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return chat;
        }
        
        public async Task<Wallet> getWalletById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/wallet/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();
            
            Wallet chat = JsonSerializer.Deserialize<Wallet>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return chat;
        }

    }
}
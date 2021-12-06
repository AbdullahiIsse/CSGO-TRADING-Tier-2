using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class WalletData : IWalletData
    {
        public async Task<long> SumOfPrice(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/wallet/price/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();


            long SumPrice = JsonSerializer.Deserialize<long>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return SumPrice;
        }

        public async void AddWallet(Wallet wallet)
        {
            
            using HttpClient client = new HttpClient();

            var walletAsJson = JsonSerializer.Serialize(wallet);

            HttpContent httpContent = new StringContent(walletAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/wallet", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }

        }

        public async Task<Wallet> UpdatePriceByPaymentId(Wallet wallet, long id)
        {
            using HttpClient client = new HttpClient();

            var walletSerialize = JsonSerializer.Serialize(wallet);

            HttpContent httpContent = new StringContent(
                walletSerialize, Encoding.UTF8, "application/json");

            var httpResponseMessage = await client.PatchAsync($"http://localhost:8080/wallet/{id}", httpContent);
            
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to update data");
            }

            return wallet;
        }
    }
}
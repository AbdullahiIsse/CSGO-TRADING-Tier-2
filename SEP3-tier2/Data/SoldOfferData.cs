using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class SoldOfferData : ISoldOfferData
    {
        public async Task<IList<SoldOffer>> getAllSoldOffers()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/soldoffer");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            IList<SoldOffer> items = JsonSerializer.Deserialize<IList<SoldOffer>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return items;
        }

        public async Task<SoldOffer> getSoldOfferDataByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/soldoffer/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            SoldOffer item = JsonSerializer.Deserialize<SoldOffer>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
        
        
      
        public async Task<List<SoldOffer>> getSoldOfferByOrderId(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/soldoffer/order_id/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            List<SoldOffer> item = JsonSerializer.Deserialize<List<SoldOffer>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
        
        
        public async Task<List<SoldOffer>> getSoldOfferBySellerWalletId(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/soldoffer/seller_wallet_id/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            List<SoldOffer> item = JsonSerializer.Deserialize<List<SoldOffer>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }

        public async Task AddSoldOffer(SoldOffer soldOffer)
        {
            using HttpClient client = new HttpClient();

            var offerAsJson = JsonSerializer.Serialize(soldOffer);

            HttpContent httpContent = new StringContent(offerAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/soldoffer/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
        }


    }
}
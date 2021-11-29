using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class OfferData : IOfferData
    {
        public async Task<IList<SaleOffer>> getAllOffers()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/saleoffer");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            IList<SaleOffer> items = JsonSerializer.Deserialize<IList<SaleOffer>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            Console.WriteLine(items);
            return items;
        }

        public async Task<SaleOffer> getOfferDataByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/saleoffer/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            SaleOffer item = JsonSerializer.Deserialize<SaleOffer>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
    }
}
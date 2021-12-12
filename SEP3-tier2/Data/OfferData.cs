using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
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
            
            return items;
        }

        public async Task<List<SaleOffer>> getOfferDataUserByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/saleoffer/user/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            List<SaleOffer> item = JsonSerializer.Deserialize<List<SaleOffer>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
        
        public async Task<SaleOffer> GetOfferDataBySaleOfferID(long id)
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
        
        public async void delete(long id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"http://localhost:8080/saleoffer/{id}");
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to delete data - Sold Offer Data");
            }
        }

        public async void AddSaleOffer(SaleOffer saleOffer)
        {
            using HttpClient client = new HttpClient();

            var SaleoffertAsJson = JsonSerializer.Serialize(saleOffer);

            HttpContent httpContent = new StringContent(SaleoffertAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/saleoffer/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data" + SaleoffertAsJson + httpResponseMessage);
            }
        }
        
        
        
        
        
        
        public async Task<long> UpdateSaleOfferToFalse(long id)
        {
            
            using HttpClient client = new HttpClient();
            

            var httpResponseMessage = await client.PutAsync($"http://localhost:8080/saleoffer/{id}",null);
            
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to saleOffer To false");
            }

            return id;

        }
    }
}
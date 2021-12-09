using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class OrderData : IOrderData
    {
        public async Task<IList<Order>> getAllOrders()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/order");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            IList<Order> items = JsonSerializer.Deserialize<IList<Order>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return items;
        }

        public async Task<Order> getOrderDataByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/order/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            Order item = JsonSerializer.Deserialize<Order>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
        
      
        public async Task<List<Order>> getOrderByWalletBuyerId(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/order/wallet_buyer_id/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            List<Order> item = JsonSerializer.Deserialize<List<Order>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }
        

        public async Task<Order> getOrderBySaleId(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/order/saleid/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            Order item = JsonSerializer.Deserialize<Order>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return item;
        }

        public async void AddOrder(Order order)
        {
            using HttpClient client = new HttpClient();

            var orderAsJson = JsonSerializer.Serialize(order);

            HttpContent httpContent = new StringContent(orderAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/order/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
        }
    }
}
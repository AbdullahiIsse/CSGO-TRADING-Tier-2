using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class ShoppingCartData : IShoppingCartData
    {
        public async Task<long> CountCartById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/cart/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();


            long countCart = JsonSerializer.Deserialize<long>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return countCart;
        }


        public async Task<IList<ShowShoppingCart>> ShowShoppingCartById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/cart/shop/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();


            IList<ShowShoppingCart> shoppingCarts = JsonSerializer.Deserialize<IList<ShowShoppingCart>>(
                readAsStringAsync, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return shoppingCarts;
        }

        public async void AddShoppingCart(ShopppingCart shopppingCart)
        {
            using HttpClient client = new HttpClient();

            var Shopping = JsonSerializer.Serialize(shopppingCart);

            HttpContent httpContent = new StringContent(Shopping, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/cart", httpContent);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
        }

        public async Task<long> GetTotalPriceById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/cart/price/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();


            long price = JsonSerializer.Deserialize<long>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            
            
            
            

            return price;
        }

        public async void DeleteShoppingCart(long user_id, long sale_offer_id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"http://localhost:8080/cart/{user_id}/{sale_offer_id}");
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to delete data - Shopping cart");
            }
        }
    }
}
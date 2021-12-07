using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class PaymentData : IPaymentData
    {
        public async void AddPayment(CreditCard creditCard)
        {
            using HttpClient client = new HttpClient();

            var paymentAsJson = JsonSerializer.Serialize(creditCard,new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            HttpContent httpContent = new StringContent(paymentAsJson, Encoding.UTF8, "application/json");
            
            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/payment", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
        }
        
        
        
        
        public async Task<CreditCard> GetPaymentById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/payment/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            CreditCard creditCard = JsonSerializer.Deserialize<CreditCard>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return creditCard;
        }

        public async Task<CreditCard> GetPaymentByName(string name)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/payment/name?name={name}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            CreditCard creditCard = JsonSerializer.Deserialize<CreditCard>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return creditCard;
        }
    }
}
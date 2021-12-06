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
        public async void AddPayment(Payment payment)
        {
            using HttpClient client = new HttpClient();

            var paymentAsJson = JsonSerializer.Serialize(payment,new JsonSerializerOptions
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
        
        
        
        
        public async Task<Payment> GetPaymentById(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/payment/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            Payment payment = JsonSerializer.Deserialize<Payment>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return payment;
        }
        
        
        
        
        
        
        
    }
}
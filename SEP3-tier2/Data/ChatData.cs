using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class ChatData : IChatData
    {
        
        public async Task<IList<Chat>>getAllChat()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/chat");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();
            
            IList<Chat> chat = JsonSerializer.Deserialize<IList<Chat>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return chat;
        }
        
        public async Task<Chat> getChatByID(long user_id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/chat/"+user_id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();
            
            Chat chat = JsonSerializer.Deserialize<Chat>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return chat;
        }
        
        public async void AddChat(Chat chat)
        {
            
            using HttpClient client = new HttpClient();

            var chatAsJson = JsonSerializer.Serialize(chat);

            HttpContent httpContent = new StringContent(chatAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/chat/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
            
        }

        
    }
}
using System.Collections.Generic;
using System.Net.Http;
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
        
        public async Task<Chat> getChatByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/chat/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();
            
            Chat chat = JsonSerializer.Deserialize<Chat>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return chat;
        }
        
    }
}
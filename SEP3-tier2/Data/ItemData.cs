using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class ItemData : IItemData
    {
        public async Task<IList<Items>> getAllItems()
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/items");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            IList<Items> items = JsonSerializer.Deserialize<IList<Items>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return items;
        }
    }
}
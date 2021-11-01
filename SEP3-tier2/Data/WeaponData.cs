using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class WeaponData : IWeaponData
    {
        public async Task<IList<userAccount>> getAllWeapons()
        {

            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/userAccounts/1");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            

            IList<userAccount> user = JsonSerializer.Deserialize<IList<userAccount>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            return user;
        }
    }
}
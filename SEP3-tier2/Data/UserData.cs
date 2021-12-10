using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public class UserData : IUserData
    {
        public async Task<IList<User>>getAllUsers()
        {

            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/user");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            IList<User> user = JsonSerializer.Deserialize<IList<User>>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });


            return user;
        }

        public async void AddUser(User user)
        {
            
            using HttpClient client = new HttpClient();

            var userAsJson = JsonSerializer.Serialize(user);

            HttpContent httpContent = new StringContent(userAsJson, Encoding.UTF8, "application/json");


            HttpResponseMessage httpResponseMessage = await client.PostAsync("http://localhost:8080/user/", httpContent);
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
            
        }
        
        
        public async void RemoveUser(long id)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage httpResponseMessage = await client.DeleteAsync($"http://localhost:8080/user/{id}");
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to add data");
            }
        }
        
        
        public async Task<User> ValidateUser(string userName, string Password)
        {
            using HttpClient httpClient = new HttpClient();

            var httpResponseMessage =
                await httpClient.GetAsync($"http://localhost:8080/user/validate/?username={userName}&password={Password}");
            
            if (httpResponseMessage.StatusCode != HttpStatusCode.Found)
            {
                throw new Exception("User not Found");
            }


            var readAsStringAsync = await httpResponseMessage.Content.ReadAsStringAsync();


            User user = JsonSerializer.Deserialize<User>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return user;
        }
        
        public async Task<User> getUserByID(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync("http://localhost:8080/user/"+id);

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            User user = JsonSerializer.Deserialize<User>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return user;
        }
        
        
        
        public async Task<User> UpdateUser(User user, long id)
        {
            
            using HttpClient client = new HttpClient();

            var userSerialize = JsonSerializer.Serialize(user);

            HttpContent httpContent = new StringContent(
                userSerialize, Encoding.UTF8, "application/json");

            var httpResponseMessage = await client.PatchAsync($"http://localhost:8080/user/{id}", httpContent);
            
            
            if (!httpResponseMessage.IsSuccessStatusCode)
            {
                throw new Exception("failed to update user");
            }

            return user;
            
        }

        public async Task<User> UserBySaleOfferId(long id)
        {
            using HttpClient client = new HttpClient();

            var responseMessage = await client.GetAsync($"http://localhost:8080/user/sale/{id}");

            var readAsStringAsync = await responseMessage.Content.ReadAsStringAsync();

            
            User user = JsonSerializer.Deserialize<User>(readAsStringAsync, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
            
            return user;
        }
    }
}
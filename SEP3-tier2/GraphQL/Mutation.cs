using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using SEP3_tier2.Data;
using SEP3_tier2.Models;

namespace SEP3_tier2.GraphQL
{
    public class Mutation
    {
        
        public async Task<User> AddUserAsync([Service]ITopicEventSender eventSender, [Service] IUserData context,string username,string password)
        {
            
            var user = new User
            {
                username = username,
                password = password
            };

           
            context.AddUser(user);

            await eventSender.SendAsync("UserCreated", user);

            
            return user;

        }
        
        public async Task<int> DeleteUserAsync([Service]ITopicEventSender eventSender, [Service] IUserData context,int id)
        {
            context.RemoveUser(id);
            
            await eventSender.SendAsync("RemoveTodo", id);

            return id;
            
        }
        
        
        public async Task<Payment> AddPaymentAsync([Service]ITopicEventSender eventSender, [Service] IPaymentData context,string name,string cardNumber, string expirationDate, string securityCode)
        {
            
            var payment = new Payment
            {
                name = name,
                cardNumber = cardNumber,
                expirationDate = expirationDate,
                securityCode = securityCode
                
            };
            
            context.AddPayment(payment);

            await eventSender.SendAsync("PaymentCreated", payment);
            
            return payment;

        }
        
        
        
    }
}
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
        
        public async Task<long> DeleteUserAsync([Service]ITopicEventSender eventSender, [Service] IUserData context,long id)
        {
            context.RemoveUser(id);
            
            await eventSender.SendAsync("RemoveTodo", id);

            return id;
            
        }
        
        
        public async Task<Payment> AddPaymentAsync([Service]ITopicEventSender eventSender, [Service] IPaymentData context,string name,string cardnumber, string expirationdate, string securitycode, string wallet)
        {
            
            var payment = new Payment
            {
                name = name,
                cardnumber = cardnumber,
                expirationdate = expirationdate,
                securitycode = securitycode,
                wallet = wallet
                
            };
            
            context.AddPayment(payment);

            await eventSender.SendAsync("PaymentCreated", payment);
            
            return payment;

        }
        
        
        public async Task<Chat> AddChatAsync([Service]ITopicEventSender eventSender, [Service] IChatData context,long user_id, string Chatlist)
        {
            
            var chat = new Chat
            {
                user_id = user_id,
                Chatlist = Chatlist
                
            };
            
            context.AddChat(chat);

            await eventSender.SendAsync("ChatCreated", chat);
            
            return chat;

        }
        
        public async Task<SaleOffer> AddSaleOfferAsync([Service]ITopicEventSender eventSender, [Service] IOfferData context,long id, long item_id, int sale_price, long wallet_id)
        {

            var saleOffer = new SaleOffer
            {
                id = id,
                item_id = item_id,
                sale_price = sale_price,
                wallet_id = wallet_id

            };
            
            context.AddSaleOffer(saleOffer);

            await eventSender.SendAsync("ChatCreated", saleOffer);
            
            return saleOffer;

        }
        
        
    }
}
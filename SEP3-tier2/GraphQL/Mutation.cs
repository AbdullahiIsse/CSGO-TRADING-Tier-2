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
        
        public async Task<ShopppingCart> AddShoppingCartAsync([Service]ITopicEventSender eventSender, [Service] IShoppingCartData context,long saleOfferId,long userId)
        {

            var shoppingCart = new ShopppingCart
            {
                saleOfferId = saleOfferId,
                userId = userId
            };


            context.AddShoppingCart(shoppingCart);

            await eventSender.SendAsync("ShoppingCartCreated", shoppingCart);

            
            return shoppingCart;

        }
        
        public async Task<long> DeleteUserAsync([Service]ITopicEventSender eventSender, [Service] IUserData context,long id)
        {
            context.RemoveUser(id);
            
            await eventSender.SendAsync("RemoveTodo", id);

            return id;
            
        }
        
        
        public async Task<CreditCard> AddPaymentAsync([Service]ITopicEventSender eventSender, [Service] IPaymentData context,string name,string cardnumber, string expirationdate, string securitycode )
        {
            
            var payment = new CreditCard
            {
                name = name,
                cardnumber = cardnumber,
                expirationdate = expirationdate,
                securitycode = securitycode,
             

            };
            
            context.AddPayment(payment);

            await eventSender.SendAsync("PaymentCreated", payment);
            
            return payment;

        }
        
        
        public async Task<Wallet> AddWalletAsync([Service]ITopicEventSender eventSender, [Service] IWalletData context,int balance,long user_id)
        {

            var wallet = new Wallet
            {
                balance = balance,
                user_id = user_id

            };


            context.AddWallet(wallet);

            await eventSender.SendAsync("WalletCreated", wallet);

            
            return wallet;

        }
        
        
        
        public async Task<Wallet> UpdatePriceAsync([Service]ITopicEventSender eventSender, [Service] IWalletData context,int balance,long id)
        {

            var wallet = new Wallet
            {
                balance = balance,
                

            };


            await context.UpdatePriceByPaymentId(wallet,id);

            await eventSender.SendAsync("UpdateWalletCreated", wallet);

            
            return wallet;

        }
        
        
        
    }
}
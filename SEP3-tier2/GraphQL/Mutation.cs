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
            
            await eventSender.SendAsync("RemoveUser", id);

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
        
        public async Task<Order> AddOrderAsync([Service]ITopicEventSender eventSender, [Service] IOrderData context,long buyerId,long sale_Id)
        {
            var order = new Order
            {
                wallet_buyer_id = buyerId,
                sale_id = sale_Id
            };
            context.AddOrder(order);
            await eventSender.SendAsync("OrderCreated", order);
            
            return order;
        }

        public async Task<SoldOffer> AddSoldOfferAsync([Service] ITopicEventSender eventSender,
            [Service] ISoldOfferData context, long item_id, long order_id, int sale_price, long seller_wallet_id)
        {
            var SoldOffer = new SoldOffer
            {
                item_id = item_id,
                order_id = order_id,
                sale_price = sale_price,
                seller_wallet_id = seller_wallet_id,
            };
            context.AddSoldOffer(SoldOffer);
            await eventSender.SendAsync("SoldOfferCreated", SoldOffer);
            
            return SoldOffer;
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
        
        public async Task<SaleOffer> AddSaleOffer([Service]ITopicEventSender eventSender, [Service] IOfferData context, long item_id ,int sale_price ,long wallet_id)
        {
            
            var saleOffer = new SaleOffer
            {
                item_id = item_id,
                sale_price = sale_price,
                wallet_id = wallet_id,
            };

           
            context.AddSaleOffer(saleOffer);

            await eventSender.SendAsync("SaleOfferCreated", saleOffer);

            
            return saleOffer;
            
        }
        
        
        
        public async Task<long> DeleteShoppingCartAsync([Service]ITopicEventSender eventSender, [Service] IShoppingCartData context,long user_id, long sale_offer_id)
        {
             context.DeleteShoppingCart(user_id,sale_offer_id);
            
            await eventSender.SendAsync("RemoveShoppingCart", user_id);

            return user_id;

        }
        
        public async Task<long> deleteSaleOffer([Service]ITopicEventSender eventSender, [Service] IOfferData context,long id)
        {
            context.delete(id);
            
            await eventSender.SendAsync("RemoveOfferData", id);

            return id;
        }
        
        public async Task<CreditCard> UpdatePaymentAsync([Service]ITopicEventSender eventSender, [Service] IPaymentData context,string name,string cardnumber,string expirationdate,string securitycode ,long id)
        {

            var payment = new CreditCard
            {
                name = name,
                cardnumber = cardnumber,
                expirationdate = expirationdate,
                securitycode = securitycode
            };

            await context.UpdatePayment(payment,id);

            await eventSender.SendAsync("UpdatePaymentCreated", payment);

            
            return payment;

        }
        
        
        
        public async Task<User> UpdateUserAsync([Service]ITopicEventSender eventSender, [Service] IUserData context,string username,string password,long securitylevel,long id)
        {

            var user = new User
            {
                username = username,
                password = password,
                securitylevel = securitylevel
            };
            
            await context.UpdateUser(user,id);

            await eventSender.SendAsync("UpdateUserCreated", user);

            
            return user;

        }
        
        
        
        
    }
}
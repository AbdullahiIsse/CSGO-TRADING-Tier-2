using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SEP3_tier2.Data;
using SEP3_tier2.Models;
using Microsoft.AspNetCore.Mvc;

namespace SEP3_tier2.GraphQL
{
    public class Mutation
    {
        public async Task<User> AddUserAsync([Service] ITopicEventSender eventSender,
            [Service] IUserData context,
            [Required(ErrorMessage = "username can not be empty")]
            [MinLength(4, ErrorMessage = "username must be more then 3 characters")]
            [MaxLength(14, ErrorMessage = "username can not be more then 14 characters")]
            string username,
            [Required(ErrorMessage = "password can not be empty")]
            [MinLength(8, ErrorMessage = "password must be more then 7 characters")]
            [MaxLength(14, ErrorMessage = "password can not be more then 14 characters")]
            string password)


        {
            try
            {
                var user = new User
                {
                    username = username,
                    password = password
                };


                var addUser = await context.AddUser(user);

                await eventSender.SendAsync("UserCreated", user);


                return addUser;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task<ShopppingCart> AddShoppingCartAsync([Service] ITopicEventSender eventSender,
            [Service] IShoppingCartData context, long saleOfferId, long userId)
        {
            var shoppingCart = new ShopppingCart
            {
                saleOfferId = saleOfferId,
                userId = userId
            };


            await context.AddShoppingCart(shoppingCart);

            await eventSender.SendAsync("ShoppingCartCreated", shoppingCart);


            return shoppingCart;
        }

        public async Task<long> DeleteUserAsync([Service] ITopicEventSender eventSender, [Service] IUserData context,
            long id)
        {
            await context.RemoveUser(id);

            await eventSender.SendAsync("RemoveUser", id);

            return id;
        }


        public async Task<CreditCard> AddPaymentAsync([Service] ITopicEventSender eventSender,
            [Service] IPaymentData context,
            [Required(ErrorMessage = "CardholderName cannot be empty")]
            [MinLength(4, ErrorMessage = "CardholderName cannot be less than 4")]
            [MaxLength(12, ErrorMessage = "CardholderName cannot be more than 12")]
            string name,
            [Required(ErrorMessage = "CardNumber cannot be empty")]
            [MinLength(16, ErrorMessage = "CardNumber must contain 16 characters")]
            [MaxLength(16, ErrorMessage = "CardNumber must contain 16 characters")]
            string cardnumber,
            [Required(ErrorMessage = "ExpirationDate cannot be empty")]
            string expirationdate,
            [Required(ErrorMessage = "CVV must contain more than 0 characters")]
            [MinLength(3, ErrorMessage = "CVV must contain  3 characters")]
            [MaxLength(3, ErrorMessage = "CVV must contain  3 characters")]
            string securitycode)
        {
            var payment = new CreditCard
            {
                name = name,
                cardnumber = cardnumber,
                expirationdate = expirationdate,
                securitycode = securitycode,
            };

            await context.AddPayment(payment);

            await eventSender.SendAsync("PaymentCreated", payment);

            return payment;
        }


        public async Task<Wallet> AddWalletAsync([Service] ITopicEventSender eventSender, [Service] IWalletData context,
            int balance, long user_id)
        {
            var wallet = new Wallet
            {
                balance = balance,
                user_id = user_id
            };


            await context.AddWallet(wallet);

            await eventSender.SendAsync("WalletCreated", wallet);


            return wallet;
        }

        public async Task<Order> AddOrderAsync([Service] ITopicEventSender eventSender, [Service] IOrderData context,
            long buyerId, long sale_Id)
        {
            var order = new Order
            {
                wallet_buyer_id = buyerId,
                sale_id = sale_Id
            };
            await context.AddOrder(order);
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

            await context.AddSoldOffer(SoldOffer);
            await eventSender.SendAsync("SoldOfferCreated", SoldOffer);

            return SoldOffer;
        }

        public async Task<Wallet> UpdatePriceAsync([Service] ITopicEventSender eventSender,
            [Service] IWalletData context, int balance, long id)
        {
            var wallet = new Wallet
            {
                balance = balance,
            };


            await context.UpdatePriceByPaymentId(wallet, id);

            await eventSender.SendAsync("UpdateWalletCreated", wallet);


            return wallet;
        }

        public async Task<SaleOffer> AddSaleOffer([Service] ITopicEventSender eventSender, [Service] IOfferData context,
            long item_id, int sale_price, long wallet_id)
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


        public async Task<long> DeleteShoppingCartAsync([Service] ITopicEventSender eventSender,
            [Service] IShoppingCartData context, long user_id, long sale_offer_id)
        {
            await context.DeleteShoppingCart(user_id, sale_offer_id);

            await eventSender.SendAsync("RemoveShoppingCart", user_id);

            return user_id;
        }

        public async Task<long> deleteSaleOffer([Service] ITopicEventSender eventSender, [Service] IOfferData context,
            long id)
        {
            context.delete(id);

            await eventSender.SendAsync("RemoveOfferData", id);

            return id;
        }

        public async Task<CreditCard> UpdatePaymentAsync([Service] ITopicEventSender eventSender,
            [Service] IPaymentData context, string name, string cardnumber, string expirationdate, string securitycode,
            long id)
        {
            var payment = new CreditCard
            {
                name = name,
                cardnumber = cardnumber,
                expirationdate = expirationdate,
                securitycode = securitycode
            };

            await context.UpdatePayment(payment, id);

            await eventSender.SendAsync("UpdatePaymentCreated", payment);


            return payment;
        }


        public async Task<User> UpdateUserAsync([Service] ITopicEventSender eventSender, [Service] IUserData context,
            string username, string password, long securitylevel, long id)
        {
            var user = new User
            {
                username = username,
                password = password,
                securitylevel = securitylevel
            };

            await context.UpdateUser(user, id);

            await eventSender.SendAsync("UpdateUserCreated", user);


            return user;
        }


        public async Task<long> UpdateSaleOfferToFalse([Service] ITopicEventSender eventSender,
            [Service] IOfferData context,
            long id)
        {
            await context.UpdateSaleOfferToFalse(id);

            return id;
        }
        
        public async Task<SaleOffer> UpdateSaleOffer([Service] ITopicEventSender eventSender,
            [Service] IOfferData context,int sale_price,bool available, long id)
        {

            var saleoffer = new SaleOffer
            {
                sale_price = sale_price,
                available = available
            };
            
            
            await context.UpdateSaleOffer(saleoffer,id);

            return saleoffer;
        }
        
        
        
        
        
        
    }
}
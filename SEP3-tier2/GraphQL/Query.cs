using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
using HotChocolate.Subscriptions;
using SEP3_tier2.Data;
using SEP3_tier2.Models;

namespace SEP3_tier2.GraphQL
{
    public class Query
    {
        
        
        [UseFiltering]
        [UseSorting]
        
        public  async Task<IList<User>> GetUsers([Service] IUserData context)
        {
            return  await context.getAllUsers();
        }
        
        [UseFiltering]
        [UseSorting]
        public  async Task<IList<Items>> GetItems([Service] IItemData context)
        {
            return  await context.getAllItems();
        }

        [UseFiltering]
        [UseSorting]
        public  async Task<IList<Order>> GetOrder([Service] IOrderData context)
        {
            return  await context.getAllOrders();
        }
        
        [UseFiltering]
        [UseSorting]
        public  async Task<IList<Chat>> GetChat([Service] IChatData context)
        {
            
            return  await context.getAllChat();
        }
        
        public async Task<Chat> GetChatById([Service] IChatData context,long id)
        {
            return  await context.getChatByID(id);
        }
        
        public async Task<Order> GetOrderById([Service] IOrderData context,long id)
        {
            return  await context.getOrderDataByID(id);
        }

        
        public async Task<Items> GetItemById([Service] IItemData context,long id)
        {
            return  await context.getItemByID(id);
        }

        public async Task<User> GetUserById([Service] IUserData context,long id)
        {
            return  await context.getUserByID(id);
        }
        
        
        public async Task<User> GetUserBySaleOfferId([Service] IUserData context,long id)
        {
            return await context.UserBySaleOfferId(id);
        }
        
        
        public async Task<User> ValidateUser([Service] IUserData context,string username,string password)
        {
            return await context.ValidateUser(username, password);
        }
        
        [UseFiltering]
        [UseSorting]
        public async Task<IList<SaleOffer>> GetOffers([Service] IOfferData context)
        {
            return await context.getAllOffers();
        }
        
        public async Task<List<SaleOffer>> GetOfferByUserId([Service] IOfferData context,long id)
        {
            return  await context.getOfferDataUserByID(id);
        }
        
        
        public async Task<SaleOffer> GetOfferBySaleOfferId([Service] IOfferData context,long id)
        {
            return  await context.GetOfferDataBySaleOfferID(id);
        }
        
        public async Task<long> GetCartCountById([Service] IShoppingCartData context,long id)
        {
            return await context.CountCartById(id);
        }
        
        
        public async Task<IList<ShowShoppingCart>> GetShoppingCartById([Service] IShoppingCartData context,long id)
        {
            return await context.ShowShoppingCartById(id);
        }
        
        
        public async Task<long> GetTotalPriceById([Service] IShoppingCartData context,long id)
        {
            return await context.GetTotalPriceById(id);
        }



        public async Task<CreditCard> GetPaymentByUserId([Service] IPaymentData context, long id)
        {
            return await context.GetPaymentById(id);
        }
        
        public async Task<long> GetSumOfPriceById([Service] IWalletData context,long id)
        {
            return await context.SumOfPrice(id);
        }


        public async Task<CreditCard> GetPaymentByName([Service] IPaymentData context, string name)
        {
            return await context.GetPaymentByName(name);
        }

        public async Task<IList<SoldOffer>> GetAllSoldOffer([Service] ISoldOfferData context)
        {
            return await context.getAllSoldOffers();

        }
        
        public async Task<Order> GetOrderBySaleId([Service] IOrderData context,long id)
        {
            return await context.getOrderBySaleId(id);
        }
        public async Task<SoldOffer> getSoldOfferById([Service] ISoldOfferData context,long id)
        {
            return  await context.getSoldOfferDataByID(id);
        }
        
        
        public async Task<IList<Order>> getOrderByWalletBuyerId([Service] IOrderData context,long id)
        {
            return await context.getOrderByWalletBuyerId(id);
        }
        
        
        public async Task<IList<OrderByBuyer>> GetBoughtItems([Service] IOrderData context,long id)
        {
            return await context.GetBoughtItems(id);
        }
        
        
        public async Task<IList<SoldOffer>> getSoldOfferByOrderId([Service] ISoldOfferData context,long id)
        {
            return await context.getSoldOfferByOrderId(id);
        }

        
        public async Task<IList<SoldOffer>> getSoldOfferBySellerWalletId([Service] ISoldOfferData context,long id)
        {
            return await context.getSoldOfferBySellerWalletId(id);
        }
        
        
        
        public async Task<IList<SoldOfferBySeller>> GetSoldItemsById([Service] ISoldOfferData context,long id)
        {
            return await context.GetSoldItemsById(id);
        }
        
        
        
        
        
        
        public async Task<IList<SaleOfferWallet>> GetItemsById([Service] IOfferData context,long id)
        {
            return await context.GetItemsById(id);
        }
        
        
        
        public Task<Wallet> GetWalletById([Service] IWalletData context,long id)
        {
            return  context.getWalletById(id);
        }





    }
}
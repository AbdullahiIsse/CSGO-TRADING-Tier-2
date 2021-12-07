using System.Collections.Generic;
using System.Threading.Tasks;
using HotChocolate;
using HotChocolate.Data;
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
        public  async Task<IList<Chat>> GetChat([Service] IChatData context)
        {
            
            return  await context.getAllChat();
        }
        
        public async Task<Chat> GetChatById([Service] IChatData context,long id)
        {
            return  await context.getChatByID(id);
        }

        
        public async Task<Items> GetItemById([Service] IItemData context,long id)
        {
            return  await context.getItemByID(id);
        }

        public async Task<User> GetUserById([Service] IUserData context,long id)
        {
            return  await context.getUserByID(id);
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
        
        public async Task<SaleOffer> GetOfferById([Service] IOfferData context,long id)
        {
            return  await context.getOfferDataByID(id);
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
        
        

        
        
        
        
        
    }
}
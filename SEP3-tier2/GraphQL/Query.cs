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
        
        public  Task<IList<User>> GetUsers([Service] IUserData context)
        {
            
            return  context.getAllUsers();
        }
        
        [UseFiltering]
        [UseSorting]
        public  Task<IList<Items>> GetItems([Service] IItemData context)
        {
            
            return  context.getAllItems();
        }
        
        public Task<Items> GetItemById([Service] IItemData context,long id)
        {
            return  context.getItemByID(id);
        }

        
        public Task<User> ValidateUser([Service] IUserData context,string username,string password)
        {
            return context.ValidateUser(username, password);
        }
        
        [UseFiltering]
        [UseSorting]
        public Task<IList<SaleOffer>> GetOffers([Service] IOfferData context)
        {
            return  context.getAllOffers();
        }
        
        public Task<SaleOffer> GetOfferById([Service] IOfferData context,long id)
        {
            return  context.getOfferDataByID(id);
        }
        
    }
}
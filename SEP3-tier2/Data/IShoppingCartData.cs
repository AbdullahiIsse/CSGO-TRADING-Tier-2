using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IShoppingCartData
    {
        
        Task<long> CountCartById(long id);

        Task<IList<ShowShoppingCart>> ShowShoppingCartById(long id);
        
        void AddShoppingCart(ShopppingCart shopppingCart);


        Task<long> GetTotalPriceById(long id);



    }
}
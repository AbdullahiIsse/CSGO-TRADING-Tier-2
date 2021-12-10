using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface ISoldOfferData
    {
        Task<IList<SoldOffer>> getAllSoldOffers();
        Task<SoldOffer> getSoldOfferDataByID(long id);
        
        Task<List<SoldOffer>> getSoldOfferByOrderId(long id);
        
        Task<List<SoldOffer>> getSoldOfferBySellerWalletId(long id);
        
        void AddSoldOffer(SoldOffer saleOffer);
    }
}
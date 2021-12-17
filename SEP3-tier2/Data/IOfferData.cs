using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> getAllOffers();
        Task<List<SaleOffer>> getOfferDataUserByID(long id);

        Task<SaleOffer> GetOfferDataBySaleOfferID(long id);

        Task<long> UpdateSaleOfferToFalse(long id);

        Task<IList<SaleOfferWallet>> GetItemsById(long id);

        void delete(long id);
        void AddSaleOffer(SaleOffer saleOffer);


        Task<SaleOffer> UpdateSaleOffer(SaleOffer saleOffer, long id);
    }
}
﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> getAllOffers();
        Task<List<SaleOffer>> getOfferDataUserByID(long id);

        Task<SaleOffer> GetOfferDataBySaleOfferID(long id);
        void AddSaleOffer(SaleOffer saleOffer);
    }
}
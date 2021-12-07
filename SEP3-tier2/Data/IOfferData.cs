﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IOfferData
    {
        Task<IList<SaleOffer>> getAllOffers();
        Task<SaleOffer> getOfferDataByID(long id);
        void AddSaleOffer(SaleOffer saleOffer);
    }
}
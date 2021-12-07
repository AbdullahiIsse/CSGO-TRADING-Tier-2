﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SEP3_tier2.Models;

namespace SEP3_tier2.Data
{
    public interface IOrderData
    {
        Task<IList<Order>> getAllOrders();
        Task<Order> getOrderDataByID(long id);
        
        void AddOrder(Order order);
    }
}
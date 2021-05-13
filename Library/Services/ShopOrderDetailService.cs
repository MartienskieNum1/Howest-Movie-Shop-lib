using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class ShopOrderDetailService
    {
        moviesContext context = new moviesContext();

        public void Add(int orderId, int movieId, decimal unitPrice)
        {
            ShopOrderDetail shopOrderDetail = new ShopOrderDetail();
            shopOrderDetail.OrderId = orderId;
            shopOrderDetail.MovieId = movieId;
            shopOrderDetail.UnitPrice = unitPrice;

            context.Add(shopOrderDetail);
            context.SaveChanges();
        }
    }
}
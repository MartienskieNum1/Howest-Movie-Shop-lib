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

        public List<int> GetMovieIdsForOrderId(int orderId)
        {
            return context.ShopOrderDetails
                .Where(o => o.OrderId == orderId)
                .Select(o => Convert.ToInt32(o.MovieId))
                .ToList();
        }

        public decimal GetPriceForMovieIdAndOrderId(int movieId, int orderId)
        {
            return context.ShopOrderDetails
                .Where(o => o.OrderId == orderId && o.MovieId == movieId)
                .Select(o => o.UnitPrice)
                .First();
        }
    }
}
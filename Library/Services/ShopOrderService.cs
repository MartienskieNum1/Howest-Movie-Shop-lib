using System;
using System.Linq;
using System.Collections.Generic;
using System.Globalization;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class ShopOrderService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<ShopOrder> All()
        {
            return context.ShopOrders
                .OrderBy(o => o.Id);
        }

        public int Add(int customerId, string street, string city, string postalCode, string country)
        {
            ShopOrder shopOrder = new ShopOrder();
            shopOrder.CustomerId = customerId;
            shopOrder.OrderDate = DateTime.Now;
            shopOrder.Street = street;
            shopOrder.City = city;
            shopOrder.PostalCode = postalCode;
            shopOrder.Country = country;

            context.Add(shopOrder);
            context.SaveChanges();

            return Convert.ToInt32(shopOrder.Id);
        }

    }
}
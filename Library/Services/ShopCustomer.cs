using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class ShopCustomerService
    {
        moviesContext context = new moviesContext();

        public int GetCustomerIdForUserId(string userId)
        {
            return Convert.ToInt32(context.ShopCustomers
                .Where(c => c.UserId == userId)
                .Select(c => c.Id)
                .First());
        }

        public bool CustomerExistsForUserId(string userId)
        {
            var results = context.ShopCustomers
                .Where(c => c.UserId == userId)
                .ToList();

            if (results.Count == 0)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public int Add(string userId, string name, string street, string city, string postalCode, string country)
        {
            ShopCustomer shopCustomer = new ShopCustomer();
            shopCustomer.UserId = userId;
            shopCustomer.Name = name;
            shopCustomer.Street = street;
            shopCustomer.City = city;
            shopCustomer.PostalCode = postalCode;
            shopCustomer.Country = country;

            context.Add(shopCustomer);
            context.SaveChanges();

            return Convert.ToInt32(shopCustomer.Id);
        }
    }
}
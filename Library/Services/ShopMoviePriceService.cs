using System;
using System.Linq;
using System.Collections.Generic;
using lib.Library.Models;

namespace lib.Library.Services
{
    public class ShopMoviePriceService
    {
        moviesContext context = new moviesContext();

        public IEnumerable<ShopMoviePrice> All()
        {
            return context.ShopMoviePrices
                .OrderBy(price => price.MovieId);
        }

        public ShopMoviePrice Add(long movieId, decimal unitPrice)
        {
            ShopMoviePrice shopMoviePrice = new ShopMoviePrice();
            shopMoviePrice.MovieId = movieId;
            shopMoviePrice.UnitPrice = unitPrice;

            context.Add(shopMoviePrice);
            context.SaveChanges();

            return shopMoviePrice;
        }

        public void DeleteAll()
        {
            var moviePrices = All();
            int count = moviePrices.Count();

            for (int i = 1; i <= count; i++)
            {
                ShopMoviePrice moviePrice = context.ShopMoviePrices.Where(price => price.MovieId == i).First();
                context.Remove(moviePrice);
            }
            context.SaveChanges();
        }
    }
}
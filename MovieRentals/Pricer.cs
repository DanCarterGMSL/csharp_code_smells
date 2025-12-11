using System.Text.Json;

namespace MovieRentals
{
    internal class Pricer
    {
        public static Movie Price(string imdbId)
        {
            var imdbMovie = ImdbMovieFetcher.FetchImdbMovie(imdbId);

            double price = 3.95;

            double rating = Double.Parse(imdbMovie.imdbRating);

            if (rating > 7.0)
                price += 1.0;

            if (rating < 4)
                price -= 1.0;

            return new Movie(imdbMovie.Title, price);
        }
    }
}

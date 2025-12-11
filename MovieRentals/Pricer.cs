using System.Text.Json;

namespace MovieRentals
{
    public class Pricer
    {
        public static Movie Price(string imdbId, IMovieFetcher imdbMovieFetcher)
        {
            var imdbMovie = imdbMovieFetcher.FetchImdbMovie(imdbId);

            double price = 3.95;

            double rating = Double.Parse(imdbMovie.imdbRating);

            if (rating >= 8.0)
                price += 1.0;

            if (rating > 7.0)
                price += 1.0;

            if (rating < 4)
                price -= 1.0;

            return new Movie(imdbMovie.Title, price);
        }
    }
}

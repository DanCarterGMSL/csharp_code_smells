namespace MovieRentals.Test;

using NUnit.Framework;

public static class PricerTests
{
    [TestCase("8.0", 5.95)]
    [TestCase("7.9", 4.95)]
    [TestCase("7.1", 4.95)]
    [TestCase("7.0", 3.95)]
    [TestCase("5", 3.95)]
    [TestCase("4.0", 3.95)]
    [TestCase("3.9", 2.95)]
    public static void MoviePriceDependsOnRating(string imdbRating, double expectedPrice)
    {
        var imdbMovie = new ImdbMovie { imdbRating = imdbRating };

        var movie = Pricer.Price("", new FakeMovieFetcher(imdbMovie));

        Assert.That(movie.Price, Is.EqualTo(expectedPrice));
    }

    private class FakeMovieFetcher : IMovieFetcher
    {
        private readonly ImdbMovie _imdbMovie;

        public FakeMovieFetcher(ImdbMovie imdbMovie)
        {
            _imdbMovie = imdbMovie;
        }

        public ImdbMovie FetchImdbMovie(string imdbId) => _imdbMovie;
    }
}
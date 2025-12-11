namespace MovieRentals;

public interface IMovieFetcher
{
    ImdbMovie FetchImdbMovie(string imdbId);
}
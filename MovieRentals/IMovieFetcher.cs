namespace MovieRentals;

internal interface IMovieFetcher
{
    ImdbMovie FetchImdbMovie(string imdbId);
}
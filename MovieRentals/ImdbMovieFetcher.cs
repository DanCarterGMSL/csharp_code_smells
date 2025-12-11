namespace MovieRentals;

using System.Text.Json;

internal class ImdbMovieFetcher : IMovieFetcher
{
    public ImdbMovie FetchImdbMovie(string imdbId)
    {
        async Task<ImdbMovie> Json()
        {
            HttpResponseMessage response =
                await new HttpClient().GetAsync("http://www.omdbapi.com/?i=" + imdbId + "&apikey=6487ec62");

            response.EnsureSuccessStatusCode();

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<ImdbMovie>(json);
        }


        ImdbMovie imdbMovie = Json().Result;
        return imdbMovie;
    }
}
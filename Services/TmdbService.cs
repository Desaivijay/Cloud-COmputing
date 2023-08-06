using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Cloud_COmputing.Models;

namespace Cloud_COmputing.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;

        public TmdbService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Movie>> GetPopularMovies()
        {
            var apiKey = "991eb3b11e660ab06861c195c6b4b9a0"; // Replace with your actual API key
            var response = await _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/popular?api_key={apiKey}");
            var result = JsonConvert.DeserializeObject<TmdbResponse>(response);
            return result.Results;
        }

        public async Task<Movie> GetMovieDetails(int movieId)
        {
            var apiKey = "991eb3b11e660ab06861c195c6b4b9a0"; // Replace with your actual API key
            var response = await _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key={apiKey}&append_to_response=images");
            var result = JsonConvert.DeserializeObject<Movie>(response);
            return result;
        }
    }

    public class TmdbResponse
    {
        public List<Movie> Results { get; set; }
    }
}

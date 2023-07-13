using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Cloud_COmputing.Models;

namespace Cloud_COmputing.Services
{
    public class TmdbService
    {
        private readonly HttpClient _httpClient;

        public TmdbService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Movie>> GetPopularMovies()
        {
            var response = await _httpClient.GetStringAsync("https://api.themoviedb.org/3/movie/popular?api_key=5f1cf8ab9bc249f701a7c4a96f1292f5");
            var result = JsonConvert.DeserializeObject<TmdbResponse>(response);
            return result.Results;
        }

        public async Task<Movie> GetMovieDetails(int movieId)
        {
            var response = await _httpClient.GetStringAsync($"https://api.themoviedb.org/3/movie/{movieId}?api_key=5f1cf8ab9bc249f701a7c4a96f1292f5");
            var result = JsonConvert.DeserializeObject<Movie>(response);
            return result;
        }
    }

    public class TmdbResponse
    {
        public List<Movie> Results { get; set; }
    }

  //  public class Movie
   // {
   //     public int Id { get; set; }
    //    public string Title { get; set; }
    //    public string Overview { get; set; }
        // Add other properties as needed
   // }
}


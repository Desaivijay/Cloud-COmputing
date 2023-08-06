using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Cloud_COmputing.Models;
using Cloud_COmputing.Services; // Corrected namespace

namespace Cloud_COmputing.Controllers
{
    public class HomeController : Controller
    {
        private readonly TmdbService _tmdbService;

        public HomeController()
        {
            // Instantiate the TmdbService manually (if required constructor arguments, provide them here)
            _tmdbService = new TmdbService();
        }

        public async Task<IActionResult> Index()
        {
            var movies = await _tmdbService.GetPopularMovies();
            return View(movies);
        }

        public async Task<IActionResult> Details(int id)
        {
            var movie = await _tmdbService.GetMovieDetails(id);
            return View(movie);
        }
    }
}

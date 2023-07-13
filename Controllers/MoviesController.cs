using Cloud_COmputing.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace Cloud_COmputing.Controllers
{
    public class MoviesController : Controller
    {
        private readonly TmdbService _tmdbService;

        public MoviesController(TmdbService tmdbService)
        {
            _tmdbService = tmdbService;
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

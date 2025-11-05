using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalAPI.Data;    
using MovieRentalAPI.Models;  

namespace MovieRentalAPI.Controllers  
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public MoviesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Movie>>> GetMovies()
        {
            return await _context.Movies
                .Where(m => !m.IsDeleted)
                .ToListAsync();
        }

        // GET: api/movies/rented
        [HttpGet("rented")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetRentedMovies()
        {
            return await _context.Movies
                .Where(m => m.IsRented && !m.IsDeleted)
                .ToListAsync();
        }

        // GET: api/movies/available
        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Movie>>> GetAvailableMovies()
        {
            return await _context.Movies
                .Where(m => !m.IsRented && !m.IsDeleted)
                .ToListAsync();
        }

        // GET: api/movies/n
        [HttpGet("{id}")]
        public async Task<ActionResult<Movie>> GetMovie(int id)
        {
            var movie = await _context.Movies
                .FirstOrDefaultAsync(m => m.MovieId == id && !m.IsDeleted);

            if (movie == null)
            {
                return NotFound();
            }

            return movie;
        }

        // POST: api/movies
        [HttpPost]
        public async Task<ActionResult<Movie>> PostMovie(Movie movie)
        {
            _context.Movies.Add(movie);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMovie), new { id = movie.MovieId }, movie);
        }

        // PUT: api/movies/n
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Movie movie)
        {
            if (id != movie.MovieId)
            {
                return BadRequest();
            }

            _context.Entry(movie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/movies/n
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }

            movie.IsDeleted = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/movies/n/rent
        [HttpPost("{id}/rent")]
        public async Task<IActionResult> RentMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null || movie.IsDeleted)
            {
                return NotFound();
            }

            if (movie.IsRented)
            {
                return BadRequest("Movie is already rented");
            }

            movie.IsRented = true;
            movie.RentalDate = DateTime.Now;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Movie rented successfully" });
        }

        // POST: api/movies/n/return
        [HttpPost("{id}/return")]
        public async Task<IActionResult> ReturnMovie(int id)
        {
            var movie = await _context.Movies.FindAsync(id);
            if (movie == null || movie.IsDeleted)
            {
                return NotFound();
            }

            if (!movie.IsRented)
            {
                return BadRequest("Movie is not currently rented");
            }

            movie.IsRented = false;
            movie.RentalDate = null;
            await _context.SaveChangesAsync();

            return Ok(new { message = "Movie returned successfully" });
        }

        private bool MovieExists(int id)
        {
            return _context.Movies.Any(e => e.MovieId == id);
        }
    }
}
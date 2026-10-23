
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;

namespace PawsConnect.Controllers
{
    [ApiController]
    [Route("api/dogs")]
    public class DogsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DogsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /api/dogs
        // Returns all available dogs as JSON.
        [HttpGet]
        public async Task<IActionResult> GetAvailableDogs()
        {
            var dogs = await _context.Dogs
                .AsNoTracking()
                .Include(d => d.Images)
                .Where(d => d.Status == "Available")
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();

            var result = dogs.Select(dog => new
            {
                dog.DogId,
                dog.Name,
                dog.Breed,
                dog.Age,
                dog.Gender,
                dog.Size,
                dog.Description,
                dog.Location,
                dog.Status,
                dog.CreatedAt,
                Images = dog.Images.Select(image => new
                {
                    image.ImageUrl,
                    image.IsPrimary
                }).ToList()
            });

            return Ok(result);
        }

        // GET: /api/dogs/2002
        // Returns one available dog by ID as JSON.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetDogById(int id)
        {
            var dog = await _context.Dogs
                .AsNoTracking()
                .Where(d => d.DogId == id && d.Status == "Available")
                .Select(d => new
                {
                    d.DogId,
                    d.Name,
                    d.Breed,
                    d.Age,
                    d.Gender,
                    d.Size,
                    d.Description,
                    d.Location,
                    d.Status,
                    d.CreatedAt,
                    Images = d.Images.Select(image => new
                    {
                        image.ImageUrl,
                        image.IsPrimary
                    }).ToList()
                })
                .FirstOrDefaultAsync();

            if (dog == null)
            {
                return NotFound(new
                {
                    message = "Available dog not found."
                });
            }

            return Ok(dog);
        }
    }
}

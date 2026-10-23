
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;

namespace PawsConnect.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/adoption-applications")]
    public class AdoptionApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AdoptionApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /api/adoption-applications
        // Admins can view all applications.
        // Adopters can view only their own applications.
        [HttpGet]
        public async Task<IActionResult> GetApplications()
        {
            var query = _context.AdoptionApplications
                .AsNoTracking()
                .AsQueryable();

            if (!User.IsInRole("Admin"))
            {
                var userIdClaim = User.FindFirstValue(
                    ClaimTypes.NameIdentifier
                );

                if (!int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized();
                }

                query = query.Where(a => a.UserId == userId);
            }

            var applications = await query
                .OrderByDescending(a => a.SubmittedAt)
                .Select(a => new
                {
                    a.AdoptionApplicationId,
                    a.DogId,
                    DogName = a.Dog != null ? a.Dog.Name : null,
                    a.UserId,
                    a.Address,
                    a.Phone,
                    a.ReasonForAdoption,
                    a.HasOtherPets,
                    a.Experience,
                    a.Status,
                    a.SubmittedAt,
                    a.ReviewedAt
                })
                .ToListAsync();

            return Ok(applications);
        }

        // GET: /api/adoption-applications/1
        // Admins can view any application.
        // Adopters can view only their own applications.
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetApplicationById(int id)
        {
            var query = _context.AdoptionApplications
                .AsNoTracking()
                .Where(a => a.AdoptionApplicationId == id);

            if (!User.IsInRole("Admin"))
            {
                var userIdClaim = User.FindFirstValue(
                    ClaimTypes.NameIdentifier
                );

                if (!int.TryParse(userIdClaim, out var userId))
                {
                    return Unauthorized();
                }

                query = query.Where(a => a.UserId == userId);
            }

            var application = await query
                .Select(a => new
                {
                    a.AdoptionApplicationId,
                    a.DogId,
                    DogName = a.Dog != null ? a.Dog.Name : null,
                    a.UserId,
                    a.Address,
                    a.Phone,
                    a.ReasonForAdoption,
                    a.HasOtherPets,
                    a.Experience,
                    a.Status,
                    a.SubmittedAt,
                    a.ReviewedAt
                })
                .FirstOrDefaultAsync();

            if (application == null)
            {
                return NotFound(new
                {
                    message = "Adoption application not found."
                });
            }

            return Ok(application);
        }
    }
}

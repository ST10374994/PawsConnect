using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;
using PawsConnect.Models;
using PawsConnect.ViewModels;

namespace PawsConnect.Controllers
{
    [Authorize]
    public class AdoptionController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdoptionController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Adoption/Create/5
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var dog = await _context.Dogs
                .FirstOrDefaultAsync(d =>
                    d.DogId == id &&
                    d.Status == "Available");

            if (dog == null)
            {
                return NotFound();
            }

            var model = new CreateAdoptionApplicationViewModel
            {
                DogId = dog.DogId
            };

            ViewBag.Dog = dog;

            ViewData["Title"] = "Apply to Adopt";

            return View(model);
        }

        // POST: /Adoption/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            CreateAdoptionApplicationViewModel model)
        {
            var dog = await _context.Dogs
                .FirstOrDefaultAsync(d =>
                    d.DogId == model.DogId &&
                    d.Status == "Available");

            if (dog == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Dog = dog;
                return View(model);
            }

            var userIdClaim = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            var application = new AdoptionApplication
            {
                DogId = model.DogId,
                UserId = userId,
                Address = model.Address,
                Phone = model.Phone,
                ReasonForAdoption = model.ReasonForAdoption,
                HasOtherPets = model.HasOtherPets,
                Experience = model.Experience,
                Status = "Pending",
                SubmittedAt = DateTime.UtcNow
            };

            _context.AdoptionApplications.Add(application);

            await _context.SaveChangesAsync();

            return RedirectToAction(
                nameof(Success),
                new { id = application.AdoptionApplicationId });
        }

        // GET: /Adoption/Success/5
        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            var application = await _context.AdoptionApplications
                .Include(a => a.Dog)
                .FirstOrDefaultAsync(a =>
                    a.AdoptionApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Application Submitted";

            return View(application);
        }
        [HttpGet]
        public async Task<IActionResult> MyApplications()
        {
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            var applications = await _context.AdoptionApplications
                .Include(a => a.Dog)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.SubmittedAt)
                .ToListAsync();

            var model = new AdoptionApplicationListViewModel
            {
                Applications = applications
            };

            ViewData["Title"] = "My Applications";

            return View(model);
        }
    }
}
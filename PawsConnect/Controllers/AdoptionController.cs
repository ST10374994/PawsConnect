
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PawsConnect.Models;
using PawsConnect.Services;
using PawsConnect.ViewModels;

namespace PawsConnect.Controllers
{
    [Authorize]
    public class AdoptionController : Controller
    {
        private readonly AdoptionService _adoptionService;

        public AdoptionController(AdoptionService adoptionService)
        {
            _adoptionService = adoptionService;
        }

        // GET: /Adoption/Create/5
        [HttpGet]
        public async Task<IActionResult> Create(int id)
        {
            var dog = await _adoptionService.GetAvailableDogAsync(id);

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
            var dog = await _adoptionService.GetAvailableDogAsync(model.DogId);

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

            try
            {
                var application =
                    await _adoptionService.SubmitApplicationAsync(model, userId);

                return RedirectToAction(
                    nameof(Success),
                    new { id = application.AdoptionApplicationId });
            }
            catch (InvalidOperationException)
            {
                ViewBag.Dog = null;
                ModelState.AddModelError(
                    string.Empty,
                    "This dog is no longer available for adoption. Please choose another dog.");

                return View(model);
            }
        }

        // GET: /Adoption/Success/5
        [HttpGet]
        public async Task<IActionResult> Success(int id)
        {
            var application =
                await _adoptionService.GetApplicationByIdAsync(id);

            if (application == null)
            {
                return NotFound();
            }

            var userIdClaim = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            if (application.UserId != userId &&
                !User.IsInRole("Admin"))
            {
                return Forbid();
            }

            ViewData["Title"] = "Application Submitted";

            return View(application);
        }

        // GET: /Adoption/MyApplications
        [HttpGet]
        public async Task<IActionResult> MyApplications()
        {
            var userIdClaim = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            var applications =
                await _adoptionService.GetUserApplicationsAsync(userId);

            var model = new AdoptionApplicationListViewModel
            {
                Applications = applications
            };

            ViewData["Title"] = "My Applications";

            return View(model);
        }
    }
}

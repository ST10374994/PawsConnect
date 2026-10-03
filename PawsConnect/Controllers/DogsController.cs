using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;
using PawsConnect.Models;
using PawsConnect.ViewModels;

namespace PawsConnect.Controllers
{
    public class DogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Dogs
        public async Task<IActionResult> Index()
        {
            var dogs = await _context.Dogs
                .Include(d => d.Images)
                .Where(d => d.Status == "Available")
                .OrderByDescending(d => d.CreatedAt)
                .ToListAsync();

            return View(dogs);
        }

        // GET: /Dogs/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["Title"] = "Add Dog";
            return View(new CreateDogViewModel());
        }

        // POST: /Dogs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateDogViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (model.Photo == null || model.Photo.Length == 0)
            {
                ModelState.AddModelError("Photo", "Please select a dog photo.");
                return View(model);
            }

            var allowedExtensions = new[]
            {
        ".jpg",
        ".jpeg",
        ".png",
        ".webp"
    };

            var extension = Path
                .GetExtension(model.Photo.FileName)
                .ToLowerInvariant();

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError(
                    "Photo",
                    "Only JPG, JPEG, PNG and WebP images are allowed."
                );

                return View(model);
            }

            if (model.Photo.Length > 5 * 1024 * 1024)
            {
                ModelState.AddModelError(
                    "Photo",
                    "The photo must be smaller than 5 MB."
                );

                return View(model);
            }

            var dog = new Dog
            {
                Name = model.Name,
                Breed = model.Breed,
                Age = model.Age,
                Gender = model.Gender,
                Size = model.Size,
                Description = model.Description,
                Location = model.Location,
                Status = "Available",
                CreatedAt = DateTime.UtcNow
            };

            _context.Dogs.Add(dog);

            await _context.SaveChangesAsync();

            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                "dogs"
            );

            Directory.CreateDirectory(uploadsFolder);

            var uniqueFileName = $"{Guid.NewGuid()}{extension}";

            var filePath = Path.Combine(
                uploadsFolder,
                uniqueFileName
            );

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await model.Photo.CopyToAsync(fileStream);
            }

            var dogImage = new DogImage
            {
                DogId = dog.DogId,
                ImageUrl = $"/uploads/dogs/{uniqueFileName}",
                IsPrimary = true,
                UploadedAt = DateTime.UtcNow
            };

            _context.DogImages.Add(dogImage);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        // GET: /Dogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dog = await _context.Dogs
                .Include(d => d.Images)
                .FirstOrDefaultAsync(d => d.DogId == id);

            if (dog == null)
            {
                return NotFound();
            }

            return View(dog);
        }
    }
}
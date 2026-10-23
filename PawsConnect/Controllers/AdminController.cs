
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;
using PawsConnect.Services;

namespace PawsConnect.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly AdoptionService _adoptionService;

        public AdminController(
            ApplicationDbContext context,
            AdoptionService adoptionService)
        {
            _context = context;
            _adoptionService = adoptionService;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Admin Dashboard";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Applications()
        {
            var applications = await _context.AdoptionApplications
                .Include(a => a.Dog)
                .Include(a => a.User)
                .OrderByDescending(a => a.SubmittedAt)
                .ToListAsync();

            ViewData["Title"] = "Adoption Applications";

            return View(applications);
        }

        [HttpGet]
        public async Task<IActionResult> Forum()
        {
            var posts = await _context.ForumPosts
                .Include(p => p.User)
                .Include(p => p.Replies)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            ViewData["Title"] = "Forum Management";

            return View(posts);
        }

        [HttpGet]
        public async Task<IActionResult> ApplicationDetails(int id)
        {
            var application = await _context.AdoptionApplications
                .Include(a => a.Dog)
                .Include(a => a.User)
                .FirstOrDefaultAsync(a =>
                    a.AdoptionApplicationId == id);

            if (application == null)
            {
                return NotFound();
            }

            ViewData["Title"] = "Application Details";

            return View(application);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveApplication(int id)
        {
            var succeeded =
                await _adoptionService.ApproveApplicationAsync(id);

            if (!succeeded)
            {
                return NotFound();
            }

            return RedirectToAction(
                nameof(ApplicationDetails),
                new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectApplication(int id)
        {
            var succeeded =
                await _adoptionService.RejectApplicationAsync(id);

            if (!succeeded)
            {
                return NotFound();
            }

            return RedirectToAction(
                nameof(ApplicationDetails),
                new { id });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteForumPost(int id)
        {
            var post = await _context.ForumPosts
                .Include(p => p.Replies)
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            _context.ForumPosts.Remove(post);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Forum));
        }
    }
}

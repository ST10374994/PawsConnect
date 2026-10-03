using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;
using PawsConnect.Models;
using PawsConnect.ViewModels;

namespace PawsConnect.Controllers
{
    public class ForumController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ForumController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var posts = await _context.ForumPosts
                .Include(p => p.User)
                .Include(p => p.Replies)
                .OrderByDescending(p => p.CreatedAt)
                .ToListAsync();

            var model = new ForumPostListViewModel
            {
                Posts = posts
            };

            ViewData["Title"] = "Community";

            return View(model);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Title"] = "Create Forum Post";

            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            CreateForumPostViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Create Forum Post";

                return View(model);
            }

            var userIdClaim = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            var post = new ForumPost
            {
                UserId = userId,
                Title = model.Title,
                Content = model.Content,
                Status = "Published",
                CreatedAt = DateTime.UtcNow
            };

            _context.ForumPosts.Add(post);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var post = await _context.ForumPosts
                .Include(p => p.User)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .FirstOrDefaultAsync(p => p.PostId == id);

            if (post == null)
            {
                return NotFound();
            }

            ViewData["Title"] = post.Title;

            return View(post);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReply(
    CreateForumReplyViewModel model)
        {
            var post = await _context.ForumPosts
                .FirstOrDefaultAsync(p => p.PostId == model.PostId);

            if (post == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return RedirectToAction(
                    nameof(Details),
                    new { id = model.PostId });
            }

            var userIdClaim = User.FindFirstValue(
                ClaimTypes.NameIdentifier);

            if (userIdClaim == null ||
                !int.TryParse(userIdClaim, out int userId))
            {
                return Challenge();
            }

            var reply = new ForumReply
            {
                PostId = model.PostId,
                UserId = userId,
                Content = model.Content,
                CreatedAt = DateTime.UtcNow
            };

            _context.ForumReplies.Add(reply);

            await _context.SaveChangesAsync();

            return RedirectToAction(
                nameof(Details),
                new { id = model.PostId });
        }
    }
}
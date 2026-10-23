using Microsoft.EntityFrameworkCore;
using PawsConnect.Data;
using PawsConnect.Models;

namespace PawsConnect.Repositories
{
    public class AdoptionRepository : IAdoptionRepository
    {
        private readonly ApplicationDbContext _context;

        public AdoptionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Dog?> GetAvailableDogAsync(int dogId)
        {
            return await _context.Dogs
                .FirstOrDefaultAsync(d =>
                    d.DogId == dogId &&
                    d.Status == "Available");
        }

        public Task AddApplicationAsync(AdoptionApplication application)
        {
            _context.AdoptionApplications.Add(application);

            return Task.CompletedTask;
        }

        public async Task<AdoptionApplication?> GetApplicationByIdAsync(
            int applicationId)
        {
            return await _context.AdoptionApplications
                .Include(a => a.Dog)
                .FirstOrDefaultAsync(a =>
                    a.AdoptionApplicationId == applicationId);
        }

        public async Task<List<AdoptionApplication>> GetUserApplicationsAsync(
            int userId)
        {
            return await _context.AdoptionApplications
                .Include(a => a.Dog)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.SubmittedAt)
                .ToListAsync();
        }

        public async Task<AdoptionApplication?> GetApplicationForReviewAsync(
            int applicationId)
        {
            return await _context.AdoptionApplications
                .Include(a => a.Dog)
                .FirstOrDefaultAsync(a =>
                    a.AdoptionApplicationId == applicationId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
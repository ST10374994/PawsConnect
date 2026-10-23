
using PawsConnect.Models;

namespace PawsConnect.Repositories
{
    public interface IAdoptionRepository
    {
        Task<Dog?> GetAvailableDogAsync(int dogId);

        Task AddApplicationAsync(AdoptionApplication application);

        Task<AdoptionApplication?> GetApplicationByIdAsync(
            int applicationId);

        Task<List<AdoptionApplication>> GetUserApplicationsAsync(
            int userId);

        Task<AdoptionApplication?> GetApplicationForReviewAsync(
            int applicationId);

        Task SaveChangesAsync();
    }
}


using PawsConnect.Models;
using PawsConnect.Repositories;
using PawsConnect.ViewModels;

namespace PawsConnect.Services
{
    public class AdoptionService
    {
        private readonly IAdoptionRepository _repository;

        public AdoptionService(IAdoptionRepository repository)
        {
            _repository = repository;
        }

        public async Task<Dog?> GetAvailableDogAsync(int dogId)
        {
            return await _repository.GetAvailableDogAsync(dogId);
        }

        public async Task<AdoptionApplication> SubmitApplicationAsync(
            CreateAdoptionApplicationViewModel model,
            int userId)
        {
            var dog = await GetAvailableDogAsync(model.DogId);

            if (dog == null)
            {
                throw new InvalidOperationException(
                    "This dog is no longer available for adoption.");
            }

            var application = new AdoptionApplication
            {
                DogId = dog.DogId,
                UserId = userId,
                Address = model.Address,
                Phone = model.Phone,
                ReasonForAdoption = model.ReasonForAdoption,
                HasOtherPets = model.HasOtherPets,
                Experience = model.Experience,
                Status = "Pending",
                SubmittedAt = DateTime.UtcNow
            };

            await _repository.AddApplicationAsync(application);
            await _repository.SaveChangesAsync();

            return application;
        }

        public async Task<AdoptionApplication?> GetApplicationByIdAsync(
            int applicationId)
        {
            return await _repository.GetApplicationByIdAsync(applicationId);
        }

        public async Task<List<AdoptionApplication>> GetUserApplicationsAsync(
            int userId)
        {
            return await _repository.GetUserApplicationsAsync(userId);
        }

        public async Task<bool> ApproveApplicationAsync(int applicationId)
        {
            var application =
                await _repository.GetApplicationForReviewAsync(applicationId);

            if (application == null ||
                application.Status != "Pending" ||
                application.Dog == null ||
                application.Dog.Status != "Available")
            {
                return false;
            }

            application.Status = "Approved";
            application.ReviewedAt = DateTime.UtcNow;
            application.Dog.Status = "Adopted";

            await _repository.SaveChangesAsync();

            return true;
        }

        public async Task<bool> RejectApplicationAsync(int applicationId)
        {
            var application =
                await _repository.GetApplicationForReviewAsync(applicationId);

            if (application == null ||
                application.Status != "Pending")
            {
                return false;
            }

            application.Status = "Rejected";
            application.ReviewedAt = DateTime.UtcNow;

            await _repository.SaveChangesAsync();

            return true;
        }
    }
}

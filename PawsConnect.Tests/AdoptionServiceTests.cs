using PawsConnect.Models;
using PawsConnect.Repositories;
using PawsConnect.Services;
using PawsConnect.ViewModels;
using Xunit;

namespace PawsConnect.Tests
{
    public class AdoptionServiceTests
    {
        [Fact]
        public async Task SubmitApplicationAsync_WhenDogIsUnavailable_ThrowsException()
        {
            var repository = new FakeAdoptionRepository();
            var service = new AdoptionService(repository);
            var model = CreateApplicationModel(dogId: 99);

            var exception = await Assert.ThrowsAsync<InvalidOperationException>(
                () => service.SubmitApplicationAsync(model, 1));

            Assert.Equal(
                "This dog is no longer available for adoption.",
                exception.Message);
            Assert.Null(repository.AddedApplication);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task SubmitApplicationAsync_WhenDogIsAvailable_CreatesPendingApplication()
        {
            var repository = new FakeAdoptionRepository
            {
                AvailableDog = CreateDog(2)
            };
            var service = new AdoptionService(repository);
            var model = CreateApplicationModel(dogId: 2);

            var application = await service.SubmitApplicationAsync(model, 7);

            Assert.NotNull(repository.AddedApplication);
            Assert.Equal(2, application.DogId);
            Assert.Equal(7, application.UserId);
            Assert.Equal("Pending", application.Status);
            Assert.Equal(model.Address, application.Address);
            Assert.Equal(model.Phone, application.Phone);
            Assert.Equal(model.ReasonForAdoption, application.ReasonForAdoption);
            Assert.False(application.HasOtherPets);
            Assert.Equal("I have cared for dogs before.", application.Experience);
            Assert.NotEqual(default, application.SubmittedAt);
            Assert.Equal(1, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task ApproveApplicationAsync_WhenApplicationExists_ApprovesApplicationAndDog()
        {
            var dog = CreateDog(2);
            var application = CreateApplication(dog);
            var repository = new FakeAdoptionRepository
            {
                ApplicationForReview = application
            };
            var service = new AdoptionService(repository);

            var result = await service.ApproveApplicationAsync(
                application.AdoptionApplicationId);

            Assert.True(result);
            Assert.Equal("Approved", application.Status);
            Assert.NotNull(application.ReviewedAt);
            Assert.Equal("Adopted", dog.Status);
            Assert.Equal(1, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task ApproveApplicationAsync_WhenApplicationIsNotPending_ReturnsFalse()
        {
            var dog = CreateDog(2);
            var application = CreateApplication(dog);
            application.Status = "Rejected";

            var repository = new FakeAdoptionRepository
            {
                ApplicationForReview = application
            };
            var service = new AdoptionService(repository);

            var result = await service.ApproveApplicationAsync(
                application.AdoptionApplicationId);

            Assert.False(result);
            Assert.Equal("Rejected", application.Status);
            Assert.Equal("Available", dog.Status);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task ApproveApplicationAsync_WhenDogIsNotAvailable_ReturnsFalse()
        {
            var dog = CreateDog(2);
            dog.Status = "Adopted";

            var application = CreateApplication(dog);
            var repository = new FakeAdoptionRepository
            {
                ApplicationForReview = application
            };
            var service = new AdoptionService(repository);

            var result = await service.ApproveApplicationAsync(
                application.AdoptionApplicationId);

            Assert.False(result);
            Assert.Equal("Pending", application.Status);
            Assert.Equal("Adopted", dog.Status);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task RejectApplicationAsync_WhenApplicationExists_RejectsApplication()
        {
            var dog = CreateDog(2);
            var application = CreateApplication(dog);
            var repository = new FakeAdoptionRepository
            {
                ApplicationForReview = application
            };
            var service = new AdoptionService(repository);

            var result = await service.RejectApplicationAsync(
                application.AdoptionApplicationId);

            Assert.True(result);
            Assert.Equal("Rejected", application.Status);
            Assert.NotNull(application.ReviewedAt);
            Assert.Equal("Available", dog.Status);
            Assert.Equal(1, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task RejectApplicationAsync_WhenApplicationIsNotPending_ReturnsFalse()
        {
            var dog = CreateDog(2);
            var application = CreateApplication(dog);
            application.Status = "Approved";

            var repository = new FakeAdoptionRepository
            {
                ApplicationForReview = application
            };
            var service = new AdoptionService(repository);

            var result = await service.RejectApplicationAsync(
                application.AdoptionApplicationId);

            Assert.False(result);
            Assert.Equal("Approved", application.Status);
            Assert.Equal("Available", dog.Status);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task ApproveApplicationAsync_WhenApplicationDoesNotExist_ReturnsFalse()
        {
            var repository = new FakeAdoptionRepository();
            var service = new AdoptionService(repository);

            var result = await service.ApproveApplicationAsync(999);

            Assert.False(result);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        [Fact]
        public async Task RejectApplicationAsync_WhenApplicationDoesNotExist_ReturnsFalse()
        {
            var repository = new FakeAdoptionRepository();
            var service = new AdoptionService(repository);

            var result = await service.RejectApplicationAsync(999);

            Assert.False(result);
            Assert.Equal(0, repository.SaveChangesCallCount);
        }

        private static CreateAdoptionApplicationViewModel CreateApplicationModel(
            int dogId)
        {
            return new CreateAdoptionApplicationViewModel
            {
                DogId = dogId,
                Address = "10 Test Street",
                Phone = "0123456789",
                ReasonForAdoption = "I can provide a caring home.",
                HasOtherPets = false,
                Experience = "I have cared for dogs before."
            };
        }

        private static Dog CreateDog(int dogId)
        {
            return new Dog
            {
                DogId = dogId,
                Name = "Buddy",
                Breed = "Mixed breed",
                Age = 3,
                Gender = "Male",
                Size = "Medium",
                Description = "A friendly dog looking for a home.",
                Location = "Cape Town",
                Status = "Available"
            };
        }

        private static AdoptionApplication CreateApplication(Dog dog)
        {
            return new AdoptionApplication
            {
                AdoptionApplicationId = 10,
                DogId = dog.DogId,
                UserId = 7,
                Address = "10 Test Street",
                Phone = "0123456789",
                ReasonForAdoption = "I can provide a caring home.",
                HasOtherPets = false,
                Experience = "I have cared for dogs before.",
                Status = "Pending",
                SubmittedAt = DateTime.UtcNow,
                Dog = dog
            };
        }

        private sealed class FakeAdoptionRepository : IAdoptionRepository
        {
            public Dog? AvailableDog { get; set; }

            public AdoptionApplication? AddedApplication { get; private set; }

            public AdoptionApplication? ApplicationForReview { get; set; }

            public int SaveChangesCallCount { get; private set; }

            public Task<Dog?> GetAvailableDogAsync(int dogId)
            {
                return Task.FromResult(
                    AvailableDog?.DogId == dogId &&
                    AvailableDog.Status == "Available"
                        ? AvailableDog
                        : null);
            }

            public Task AddApplicationAsync(AdoptionApplication application)
            {
                AddedApplication = application;
                return Task.CompletedTask;
            }

            public Task<AdoptionApplication?> GetApplicationByIdAsync(
                int applicationId)
            {
                return Task.FromResult<AdoptionApplication?>(null);
            }

            public Task<List<AdoptionApplication>> GetUserApplicationsAsync(
                int userId)
            {
                return Task.FromResult(new List<AdoptionApplication>());
            }

            public Task<AdoptionApplication?> GetApplicationForReviewAsync(
                int applicationId)
            {
                return Task.FromResult(
                    ApplicationForReview?.AdoptionApplicationId == applicationId
                        ? ApplicationForReview
                        : null);
            }

            public Task SaveChangesAsync()
            {
                SaveChangesCallCount++;
                return Task.CompletedTask;
            }
        }
    }
}
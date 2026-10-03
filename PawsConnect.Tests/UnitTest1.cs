using PawsConnect.ViewModels;
using System.ComponentModel.DataAnnotations;
using Xunit;

namespace PawsConnect.Tests
{
    public class BasicTests
    {
        [Fact]
        public void RegisterViewModel_ShouldRequireValidEmail()
        {
            // Arrange
            var model = new RegisterViewModel
            {
                FirstName = "Test",
                LastName = "User",
                Email = "invalid-email",
                Password = "password123",
                ConfirmPassword = "password123"
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            bool isValid = Validator.TryValidateObject(
                model,
                context,
                results,
                true);

            // Assert
            Assert.False(isValid);
        }
        [Fact]
        public void RegisterViewModel_ShouldRejectMismatchedPasswords()
        {
            // Arrange
            var model = new RegisterViewModel
            {
                FirstName = "Test",
                LastName = "User",
                Email = "test@example.com",
                Password = "password123",
                ConfirmPassword = "different123"
            };

            var context = new ValidationContext(model);
            var results = new List<ValidationResult>();

            // Act
            bool isValid = Validator.TryValidateObject(
                model,
                context,
                results,
                true);

            // Assert
            Assert.False(isValid);
        }
    }
}
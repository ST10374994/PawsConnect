using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class AdoptionApplication
    {
        public int AdoptionApplicationId { get; set; }

        public int DogId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(250)]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        [StringLength(30)]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string ReasonForAdoption { get; set; } = string.Empty;

        public bool HasOtherPets { get; set; }

        [StringLength(2000)]
        public string? Experience { get; set; }

        [Required]
        [StringLength(30)]
        public string Status { get; set; } = "Pending";

        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public DateTime? ReviewedAt { get; set; }

        public Dog? Dog { get; set; }

        public User? User { get; set; }
    }
}
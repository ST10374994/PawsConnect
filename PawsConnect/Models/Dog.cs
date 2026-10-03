using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class Dog
    {
        public int DogId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Breed { get; set; } = string.Empty;

        [Range(0, 30)]
        public int Age { get; set; }

        [Required]
        [StringLength(20)]
        public string Gender { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Size { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Description { get; set; } = string.Empty;

        [Required]
        [StringLength(150)]
        public string Location { get; set; } = string.Empty;

        [Required]
        [StringLength(30)]
        public string Status { get; set; } = "Available";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        public ICollection<DogImage> Images { get; set; }
            = new List<DogImage>();

        public ICollection<AdoptionApplication> AdoptionApplications { get; set; }
            = new List<AdoptionApplication>();
    }
}
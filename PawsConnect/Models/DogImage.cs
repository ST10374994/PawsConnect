using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class DogImage
    {
        [Key]
        public int ImageId { get; set; }

        public int DogId { get; set; }

        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.UtcNow;

        public Dog? Dog { get; set; }
    }
}
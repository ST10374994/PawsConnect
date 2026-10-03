using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PawsConnect.ViewModels
{
    public class CreateDogViewModel
    {
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

        public IFormFile? Photo { get; set; }
    }
}
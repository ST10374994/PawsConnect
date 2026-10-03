using System.ComponentModel.DataAnnotations;

namespace PawsConnect.ViewModels
{
    public class CreateAdoptionApplicationViewModel
    {
        public int DogId { get; set; }

        [Required]
        [StringLength(250)]
        [Display(Name = "Home Address")]
        public string Address { get; set; } = string.Empty;

        [Required]
        [Phone]
        [StringLength(30)]
        [Display(Name = "Phone Number")]
        public string Phone { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        [Display(Name = "Why would you like to adopt this dog?")]
        public string ReasonForAdoption { get; set; } = string.Empty;

        [Display(Name = "Do you currently have other pets?")]
        public bool HasOtherPets { get; set; }

        [StringLength(2000)]
        [Display(Name = "Tell us about your experience with pets")]
        public string? Experience { get; set; }
    }
}
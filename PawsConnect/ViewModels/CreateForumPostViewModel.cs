using System.ComponentModel.DataAnnotations;

namespace PawsConnect.ViewModels
{
    public class CreateForumPostViewModel
    {
        [Required]
        [StringLength(150)]
        [Display(Name = "Post Title")]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(3000)]
        [Display(Name = "Message")]
        public string Content { get; set; } = string.Empty;
    }
}
using System.ComponentModel.DataAnnotations;

namespace PawsConnect.ViewModels
{
    public class CreateForumReplyViewModel
    {
        public int PostId { get; set; }

        [Required]
        [StringLength(2000)]
        [Display(Name = "Your Reply")]
        public string Content { get; set; } = string.Empty;
    }
}
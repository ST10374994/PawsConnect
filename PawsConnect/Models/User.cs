using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required]
        [StringLength(20)]
        public string Role { get; set; } = "Adopter";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<AdoptionApplication> AdoptionApplications { get; set; }
            = new List<AdoptionApplication>();

        public ICollection<ForumPost> ForumPosts { get; set; }
            = new List<ForumPost>();

        public ICollection<ForumReply> ForumReplies { get; set; }
            = new List<ForumReply>();
    }
}
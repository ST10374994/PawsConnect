using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class ForumPost
    {
        [Key]
        public int PostId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(3000)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? UpdatedAt { get; set; }

        [StringLength(30)]
        public string Status { get; set; } = "Active";

        public User? User { get; set; }

        public ICollection<ForumReply> Replies { get; set; }
            = new List<ForumReply>();
    }
}
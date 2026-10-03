using System.ComponentModel.DataAnnotations;

namespace PawsConnect.Models
{
    public class ForumReply
    {
        [Key]
        public int ReplyId { get; set; }

        public int PostId { get; set; }

        public int UserId { get; set; }

        [Required]
        [StringLength(3000)]
        public string Content { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ForumPost? Post { get; set; }

        public User? User { get; set; }
    }
}
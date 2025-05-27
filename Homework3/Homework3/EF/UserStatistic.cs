using Homework3.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3.EF
{
    public class UserStatistic
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        public int GamesPlayed { get; set; } = 0;

        [Required]
        public int Wins { get; set; } = 0;

        [Required]
        public int MaxStreak { get; set; } = 0;

        [Required]
        public int CurrentStreak { get; set; } = 0;

        public virtual User User { get; set; }
    }
}

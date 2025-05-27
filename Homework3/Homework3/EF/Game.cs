using Homework3.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3.EF
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [ForeignKey("Word")]
        public int WordId { get; set; }

        [Required]
        public int AttemptsUsed { get; set; }

        [Required]
        public int Score { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
        public virtual Word Word { get; set; }
        public virtual ICollection<GameAttempt> GameAttempts { get; set; } = new List<GameAttempt>();
    }
}
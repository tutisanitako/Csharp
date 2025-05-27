using Homework3.EF;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework3.EF
{
    public class GameAttempt
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Game")]
        public int GameId { get; set; }

        [Required]
        public int AttemptNumber { get; set; }

        [Required]
        [StringLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string GuessedWord { get; set; }

        [Required]
        [StringLength(5)]
        [Column(TypeName = "nvarchar(5)")]
        public string Result { get; set; }

        public virtual Game Game { get; set; }
    }
}
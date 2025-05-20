namespace DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameAttempts
    {
        public int Id { get; set; }

        public int GameId { get; set; }

        public int AttemptNumber { get; set; }

        [Required]
        [StringLength(5)]
        public string GuessedWord { get; set; }

        [Required]
        [StringLength(5)]
        public string Result { get; set; }

        public virtual Games Games { get; set; }
    }
}

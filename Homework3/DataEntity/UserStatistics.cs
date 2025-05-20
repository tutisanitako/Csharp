namespace DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UserStatistics
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public int GamesPlayed { get; set; }

        public int Wins { get; set; }

        public int MaxStreak { get; set; }

        public int CurrentStreak { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public double? WinningPercentage { get; set; }

        public virtual Users Users { get; set; }
    }
}

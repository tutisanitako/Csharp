namespace DataEntity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Games
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Games()
        {
            GameAttempts = new HashSet<GameAttempts>();
        }

        public int Id { get; set; }

        public int UserId { get; set; }

        public int WordId { get; set; }

        public int AttemptsUsed { get; set; }

        public int Score { get; set; }

        public DateTime CreatedAt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GameAttempts> GameAttempts { get; set; }

        public virtual Users Users { get; set; }

        public virtual Words Words { get; set; }
    }
}

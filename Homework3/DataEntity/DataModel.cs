using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DataEntity
{
    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<GameAttempts> GameAttempts { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UserStatistics> UserStatistics { get; set; }
        public virtual DbSet<Words> Words { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Games>()
                .HasMany(e => e.GameAttempts)
                .WithRequired(e => e.Games)
                .HasForeignKey(e => e.GameId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UserStatistics)
                .WithRequired(e => e.Users)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Words>()
                .HasMany(e => e.Games)
                .WithRequired(e => e.Words)
                .HasForeignKey(e => e.WordId)
                .WillCascadeOnDelete(false);
        }
    }
}

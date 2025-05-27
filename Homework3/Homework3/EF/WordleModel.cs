using Microsoft.EntityFrameworkCore;
using Homework3.EF; // Reference the new namespace
using Microsoft.EntityFrameworkCore.Design;

public class WordleModel : DbContext
{
    public WordleModel(DbContextOptions<WordleModel> options) : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Word> Words { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<GameAttempt> GameAttempts { get; set; }
    public DbSet<UserStatistic> UserStatistics { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>()
            .HasIndex(e => e.Email)
            .IsUnique()
            .HasName("IX_User_Email");

        modelBuilder.Entity<Word>()
            .HasIndex(e => e.WordText)
            .IsUnique()
            .HasName("IX_Word_WordText");

        modelBuilder.Entity<Game>()
            .HasIndex(e => e.UserId)
            .HasName("IX_Game_UserId");

        modelBuilder.Entity<Game>()
            .HasIndex(e => e.WordId)
            .HasName("IX_Game_WordId");

        modelBuilder.Entity<Game>()
            .HasIndex(e => e.CreatedAt)
            .HasName("IX_Game_CreatedAt");

        modelBuilder.Entity<GameAttempt>()
            .HasIndex(e => e.GameId)
            .HasName("IX_GameAttempt_GameId");

        modelBuilder.Entity<UserStatistic>()
            .HasIndex(e => e.UserId)
            .IsUnique()
            .HasName("IX_UserStatistic_UserId");

        modelBuilder.Entity<Game>()
            .HasOne(g => g.User)
            .WithMany(u => u.Games)
            .HasForeignKey(g => g.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.Word)
            .WithMany(w => w.Games)
            .HasForeignKey(g => g.WordId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<GameAttempt>()
            .HasOne(ga => ga.Game)
            .WithMany(g => g.GameAttempts)
            .HasForeignKey(ga => ga.GameId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserStatistic>()
            .HasOne(us => us.User)
            .WithOne(u => u.UserStatistic)
            .HasForeignKey<UserStatistic>(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<User>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Word>()
            .Property(e => e.IsSelectable)
            .HasDefaultValue(true);

        modelBuilder.Entity<Game>()
            .Property(e => e.CreatedAt)
            .HasDefaultValueSql("GETDATE()");
    }

    public class WordleModelFactory : IDesignTimeDbContextFactory<WordleModel>
    {
        public WordleModel CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WordleModel>();
            // Configure your connection string here for design-time operations.
            // This connection string should match what your application uses,
            // or be a suitable placeholder for migrations.
            // Example: optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=WordleDb;Trusted_Connection=True;");
            // For this example, I'll use a placeholder. You should replace this with your actual connection string.
            optionsBuilder.UseSqlServer("Data Source=PHOENIX\\MSSQLSERVER01;Initial Catalog=WordleDbcs;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

            return new WordleModel(optionsBuilder.Options);
        }
    }
}
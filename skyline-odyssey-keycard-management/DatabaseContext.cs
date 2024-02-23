



using Microsoft.EntityFrameworkCore;
using skyline_odyssey_keycard_management.Models;


namespace skyline_odyssey_keycard_management
{
	public class DatabaseContext : DbContext
	{
        public DatabaseContext() : base()
        {
            
        }
        public DbSet<User> Users { get; set; }

		public DbSet<Keycard> Keycards { get; set; }

		public DbSet<Role> Roles { get; set; }

		public DbSet<UsageHistory> UsageHistories { get; set; }

		public DbSet<AccessPoint> AccessPoints { get; set; }

		public DbSet<KeycardRequests> KeycardRequests { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=SQL6031.site4now.net;Initial Catalog=db_aa5757_odyssey;User Id=db_aa5757_odyssey_admin;Password=odyssey123");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<UsageHistory>().ToTable("UsageHistory");

			modelBuilder.Entity<User>().ToTable("User")
				.HasMany(c => c.UsageHistories);
			modelBuilder.Entity<Keycard>().ToTable("Keycard")
				.HasMany(c => c.UsageHistories)
				.WithOne(c => c.Keycard);
			modelBuilder.Entity<Role>().ToTable("Role")
				.HasMany(c => c.Users)
				.WithOne(c => c.Role);
			modelBuilder.Entity<AccessPoint>().ToTable("AccessPoint");

			modelBuilder.Entity<KeycardRequests>().ToTable("KeycardRequests");


			base.OnModelCreating(modelBuilder);
		}

	}
}

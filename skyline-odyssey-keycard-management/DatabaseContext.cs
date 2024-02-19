



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


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Data Source=SQL6031.site4now.net;Initial Catalog=db_aa5757_odyssey;User Id=db_aa5757_odyssey_admin;Password=odyssey123");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<User>()
		.HasOne(u => u.Keycard)
		.WithOne(k => k.User)
		.HasForeignKey<Keycard>(k => k.UserId)
		.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<User>()
				.HasMany(u => u.UsageHistories)
				.WithOne(uh => uh.User)
				.HasForeignKey(uh => uh.UserId)
				.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<Keycard>()
				.HasMany(k => k.UsageHistories)
				.WithOne(uh => uh.Keycard)
				.HasForeignKey(uh => uh.CardId)
				.OnDelete(DeleteBehavior.Restrict);
			modelBuilder.Entity<User>()
				.HasOne(u => u.Role)
				.WithMany(r => r.Users)
				.HasForeignKey(u => u.RoleId)
				.OnDelete(DeleteBehavior.Restrict);



			base.OnModelCreating(modelBuilder);
		}

	}
}

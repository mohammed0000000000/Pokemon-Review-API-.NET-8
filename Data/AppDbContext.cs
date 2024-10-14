using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Data
{
	public class AppDbContext : DbContext
	{
		//private readonly IConfiguration configuration;

		//public AppDbContext(IConfiguration configuration){
		//	this.configuration = configuration;
		//}

		public DbSet<Pokemon> Pokemons { get; set; }	
		public DbSet<Owner> Owners { get; set; }	
		public DbSet<Review> Reviews { get; set; }	
		public DbSet<Reviewer> Reviewers { get; set; }	
		public DbSet<Category>Categories { get; set; }	
		public DbSet<Country>Countries { get; set; }	
		public DbSet<PokemonCategory> PokemonCategories { get; set; }
		public DbSet<PokemonOwner> PokemonOwners { get; set; }	

		public AppDbContext(){ }
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
		//	optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

		}
	}
}

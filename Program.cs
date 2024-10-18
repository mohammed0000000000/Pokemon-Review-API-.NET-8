
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.Helper;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;
using PokemonReviewAPI.Services.Implementation;

namespace PokemonReviewAPI
{
	public class Program
	{
		public static void Main(string[] args) {
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			builder.Services.AddDbContext<AppDbContext>( option => {
				option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});
			builder.Services.AddTransient<Seed>();
			builder.Services.AddScoped<DbContext, AppDbContext>();
			builder.Services.AddScoped(typeof(IRepository<,>), typeof(Repository<,>));
			builder.Services.AddAutoMapper(typeof(MappingProfiles).Assembly);
			builder.Services.AddScoped<IPokemonServices, PokemonServices>();
			builder.Services.AddScoped<ICategoryServices, CategoryServices>();
			builder.Services.AddScoped<ICountryServices, CountryServices>();
			builder.Services.AddScoped<IOwnerServices, OwnerServices>();
			builder.Services.AddScoped<IReviewServices, ReviewServices>();
			builder.Services.AddScoped<IReviewerServices, ReviewerServices>();

			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			if (args.Length == 1 && args[0].ToLower() == "seeddata"){
				SeedData(app);
			} 
			void SeedData(IHost app){
				var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
				using(var scope = scopedFactory.CreateScope()){
					var service = scope.ServiceProvider.GetService<Seed>();
					service.SeedDataContext(); 
				}
			}

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment()) {
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}

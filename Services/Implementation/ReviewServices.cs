using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class ReviewServices : IReviewServices
	{
		private readonly IRepository<Review, int> repository;
		private readonly AppDbContext context;
		private readonly IMapper mapper;

		public ReviewServices(IRepository<Review,int > repository, AppDbContext context, IMapper mapper) {
			this.repository = repository;
			this.context = context;
			this.mapper = mapper;
		}
		public async Task<ReviewDto> GetReview(int id) {
			var model = await repository.GetbyId(id);
			var review = mapper.Map<ReviewDto>(model);
			return review;
		}

		public async Task<ICollection<ReviewDto>> GetReviews() {
			var models = await repository.GetAll();
			var reviews = mapper.Map<List<ReviewDto>>(models);
			return reviews;
		}

		public async Task<ICollection<ReviewDto>> GetReviewsOfPokemon(int pokemonId) {
			var models = await context.Reviews.Where(x => x.PokemonId == pokemonId).ToListAsync();
			var reviews = mapper.Map<List<ReviewDto>>(models);
			return reviews;
		}

		public async Task<bool> ReviewExists(int reviewId) {
			return await context.Reviews.AnyAsync(x => x.Id == reviewId);
		}
	}
}

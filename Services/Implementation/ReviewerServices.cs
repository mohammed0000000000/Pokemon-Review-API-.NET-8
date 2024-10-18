using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class ReviewerServices : IReviewerServices
	{
		private readonly IRepository<Reviewer, int> repository;
		private readonly AppDbContext context;
		private readonly IMapper mapper;

		public ReviewerServices(IRepository<Reviewer,int> repository,AppDbContext context, IMapper mapper) {
			this.repository = repository;
			this.context = context;
			this.mapper = mapper;
		}

		public async Task<ReviewerDto> GetReviewer(int id) {
			var model = await repository.GetbyId(id);
			var reviewer = mapper.Map<ReviewerDto>(model);
			return reviewer;
		}

		public async Task<ICollection<ReviewerDto>> GetReviewers() {
			var models = await repository.GetAll();
			var reviewers = mapper.Map<List<ReviewerDto>>(models);
			return reviewers;
		}

		public async Task<ICollection<ReviewDto>> GetReviewsByReviewer(int id) {
			var models = await context.Reviews.Where(x => x.ReviewerId == id).ToListAsync();
			var reviews = mapper.Map<List<ReviewDto>>(models);
			return reviews;
		}

		public async Task<bool> ReviewerExists(int id) {
			return await context.Reviewers.AnyAsync(x => x.Id == id);
		}
		public async Task<bool> CreateReviewer(ReviewerDto reviewer) {
			var model = mapper.Map<Reviewer>(reviewer);
			var res = await repository.Create(model);
			return true;
		}
	}
}

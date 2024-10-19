using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class CategoryServices : ICategoryServices
	{
		private readonly IRepository<Category, int> repository;
		private readonly IMapper mapper;
		private readonly AppDbContext context;

		public CategoryServices(IRepository<Category, int> repository, IMapper mapper, AppDbContext context) {
			this.repository = repository;
			this.mapper = mapper;
			this.context = context;
		}

		public async Task<bool> CategoryExists(int id) {
			var exist = context.Categories.Any(x => x.Id == id);
			return exist;
		}

		public async Task<ICollection<CategoryDto>> GetCategories() {
			var models = await repository.GetAll();
			var categories = mapper.Map<List<CategoryDto>>(models);
			return categories;
		}

		public async Task<CategoryDto> GetCategoryById(int id) {
			var model = await repository.GetbyId(id);
			var category = mapper.Map<CategoryDto>(model);
			return category;
		}

		public async Task<CategoryDto> GetCategoryByName(string name) {
			var model = await context.Categories.FirstOrDefaultAsync(x => x.Name == name);
			var category = mapper.Map<CategoryDto>(model);
			return category;
		}

		public async Task<ICollection<PokemonDto>> GetPokemonsByCategory(int categoryId) {
			var models = await context.PokemonCategories.Where(x => x.CategoryId == categoryId).Select(x => x.Pokemon).ToListAsync();
			var pokemons = mapper.Map<List<PokemonDto>>(models);
			return pokemons;
		}
		public async Task<bool> CreateCategory(CreateCategoryDto category){
			var model = new Category(){ Name = category.Name };
			var res = await repository.Create(model);
			return res is not null;
		}
	}
}

using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface ICategoryServices
	{
		Task<ICollection<CategoryDto>> GetCategories();
		Task<CategoryDto> GetCategoryById(int id);
		Task<CategoryDto> GetCategoryByName(string name);	
		Task<ICollection<PokemonDto>>GetPokemonsByCategory(int categoryId);	
		Task<bool> CategoryExists(int id);
		Task<bool> CreateCategory(CreateCategoryDto model);
		Task<bool> UpdateCategory(int categoryId, CreateCategoryDto model);
		Task<bool> DeleteCategory(int id);
	}
}

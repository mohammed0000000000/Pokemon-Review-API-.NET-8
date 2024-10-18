using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.DTO
{
	public class CategoryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		//public ICollection<PokemonCategory> PokemonCategories { get; set; } = new List<PokemonCategory>();
	}
}

using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.DTO
{
	public class CountryDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<Owner> Owners { get; set; }
	}
}

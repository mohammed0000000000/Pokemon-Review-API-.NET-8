using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class CreateCountryDto
	{
		[Required]
		[MinLength(5)]
		public string Name { get; set; }
	}
}

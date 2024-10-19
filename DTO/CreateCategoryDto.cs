using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class CreateCategoryDto
	{
		[Required]
		[MinLength(5)]
		public string Name { get; set; }
	}
}

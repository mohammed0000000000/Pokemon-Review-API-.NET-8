using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class ReviewerDto
	{
		[Required]
		[MinLength(5)]
		public string FirstName { get; set; }
		[Required]
		[MinLength(5)]
		public string LastName { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class CreateOwnerDto
	{
		[Required]
		[MinLength(5)]
		public string FirstName { get; set; }
		[Required]
		[MinLength(5)]
		public string LastName { get; set; }
		[Required]
		[MinLength(3)]
		public string Gym { get; set; }
		[Required]
		public int CounteryId { get; set; }
	}
}

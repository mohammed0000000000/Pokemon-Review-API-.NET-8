using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class PokemonDto
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
	}
}

using System.ComponentModel.DataAnnotations;

namespace PokemonReviewAPI.DTO
{
	public class CreatePokemonDto
	{
		[Required]
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		[Required]
		public int OwnerId{  get; set; }
		[Required]
        public int CategoryId { get; set; }
    }
}

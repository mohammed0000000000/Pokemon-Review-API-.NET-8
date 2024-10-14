using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface IPokemonServices
	{
		Task<ICollection<PokemonDto>> GetPokemons();
		
	}
}

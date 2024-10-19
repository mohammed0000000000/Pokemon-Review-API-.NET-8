using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface IPokemonServices
	{
		Task<ICollection<PokemonDto>> GetPokemons();
		Task<PokemonDto> GetPokemon(int id);
		Task<PokemonDto> GetPokemon(string name);	
		Task<decimal> GetPokemonRating(int id);
		Task<bool> PokemonExists(int id);
		Task<bool> CreatePokemon(CreatePokemonDto pokemon);
		Task<bool> UpdatePokemon(int pokemonId, CreatePokemonDto pokemon);
		Task<bool> DeletePokemon(int id);
	}
}

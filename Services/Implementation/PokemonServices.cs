using AutoMapper;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class PokemonServices : IPokemonServices
	{
		private readonly IRepository<Pokemon, int> repository;
		private readonly IMapper mapper; 

		public PokemonServices(IRepository<Pokemon, int> repository, IMapper mapper) {
			this.repository = repository;
			this.mapper = mapper;
		}

		public async Task<ICollection<PokemonDto>> GetPokemons() {
			try{
				var models = await repository.GetAll();
				var pokemons = mapper.Map<List<PokemonDto>>(models);
				return pokemons;
			}
			catch(Exception ex){
				throw;
			}
			
		}
	}
}

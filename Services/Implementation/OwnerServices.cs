using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class OwnerServices : IOwnerServices
	{
		private readonly IRepository<Owner, int> repository;
		private readonly IMapper mapper;
		private readonly AppDbContext context;

		public OwnerServices(IRepository<Owner,int> repository, IMapper mapper, AppDbContext context) {
			this.repository = repository;
			this.mapper = mapper;
			this.context = context;
		}
		public async Task<OwnerDto> GetOwner(int id) {
			var model = await repository.GetbyId(id);
			if (model is null)
				return null;
			var owner = mapper.Map<OwnerDto>(model);
			return owner;
		}

		public async Task<ICollection<OwnerDto>> GetOwnerOfPokemon(int pokemonId) {
			var models = await context.PokemonOwners.Where( x=> x.PokemonId == pokemonId).Select(x => x.Owner).ToListAsync();
			var owners = mapper.Map<List<OwnerDto>>(models);
			return owners;
		}

		public async Task<ICollection<OwnerDto>> GetOwners() {
			var models = await repository.GetAll();
			var owners = mapper.Map<List<OwnerDto>>(models);
			return owners;
		}

		public async Task<ICollection<PokemonDto>> GetPokemonsByOwner(int ownerId) {
			var models = await context.PokemonOwners.Where(x => x.OwnerId == ownerId).Select(x => x.Pokemon).ToListAsync(); 
			var pokemons = mapper.Map<List<PokemonDto>>(models);
			return pokemons;
		}

		public async Task<bool> OwnerExists(int ownerId) {
			var exists = await context.Owners.AnyAsync(x => x.Id == ownerId);
			return exists;
		}
	}
}

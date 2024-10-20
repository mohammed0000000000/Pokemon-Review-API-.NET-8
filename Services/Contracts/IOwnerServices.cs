﻿using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface IOwnerServices
	{
		Task<ICollection<OwnerDto>> GetOwners();
		Task<OwnerDto> GetOwner(int id);
		Task<ICollection<OwnerDto>> GetOwnerOfPokemon(int pokemonId);
		Task<ICollection<PokemonDto>>GetPokemonsByOwner(int  ownerId);	
		Task<bool> OwnerExists(int ownerId);
		Task<bool> CreateOwner(CreateOwnerDto model);
		Task<bool> UpdateOwner(int ownerId, CreateOwnerDto model);
		Task<bool> DeleteOwner(int ownerId);
	}
}

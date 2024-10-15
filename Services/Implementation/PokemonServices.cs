﻿using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
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
		private readonly AppDbContext context;

		public PokemonServices(IRepository<Pokemon, int> repository, IMapper mapper, AppDbContext context) {
			this.repository = repository;
			this.mapper = mapper;
			this.context = context;
		}

		public async Task<PokemonDto> GetPokemon(int id) {
			var model = await repository.GetbyId(id);
			var res = mapper.Map<PokemonDto>(model);
			return res;
		}

		public async Task<PokemonDto> GetPokemon(string name) {
			var model = await context.Pokemons.FirstOrDefaultAsync(x => x.Name == name);
			var res = mapper.Map<PokemonDto>(model);
			return res;
		}

		public async Task<decimal> GetPokemonRating(int pokemonId) {
			var reviews = await context.Reviews.Where(review => review.PokemonId == pokemonId).ToListAsync();
			int count = reviews.Count();
			if ( count == 0){
				return 0;
			}
			return ((decimal)reviews.Sum(review => review.Rating) / count);
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

		public async Task<bool> PokemonExists(int id) {
			var exist = await context.Pokemons.AnyAsync(pokemon => pokemon.Id == id);
			return exist;
		}
	}
}

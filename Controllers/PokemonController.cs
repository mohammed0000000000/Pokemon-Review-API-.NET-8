using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : ControllerBase {
		private readonly IPokemonServices services;
		public PokemonController(IPokemonServices services) {
			this.services = services;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(ICollection<PokemonDto>))]
		public async Task<IActionResult> GetAll() {
			var response = await services.GetPokemons();
			return Ok(response);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type =typeof(PokemonDto))]
		[ProducesResponseType(statusCode: 400)]
		public async Task<IActionResult>GetPokemon(int id){
			var res = await services.GetPokemon(id);
			if (res is null)
				return NotFound();
			return Ok(res);
		}

		[HttpGet("{name:alpha}")]
		[ProducesResponseType(200, Type = typeof(PokemonDto))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetPokemon(string name) {
			var res = await services.GetPokemon(name);
			if (res is null)
				return NotFound();
			return Ok(res);
		}

		[HttpGet("{pokemonId:int}/rating")]
		[ProducesResponseType(200, Type = typeof(decimal))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetPokemonRating(int pokemonId) {
			var exist = await services.PokemonExists(pokemonId);
			if (!exist) return NotFound();
			var rating = await services.GetPokemonRating(pokemonId);
			return Ok(rating);
		}
	}
}

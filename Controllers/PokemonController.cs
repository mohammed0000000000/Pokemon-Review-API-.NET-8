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
		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		public async Task<IActionResult>CreatePokemon(CreatePokemonDto pokemon){
			if(!ModelState.IsValid){
				return BadRequest(ModelState);
			}
			pokemon.BirthDate = DateTime.Now;
			var res = await services.CreatePokemon(pokemon);
			return res ? Ok("Created Successfully") : StatusCode(500,ModelState);
		}

		[HttpPut("{pokemonId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdatePokemon(int pokemonId, CreatePokemonDto pokemon) {
			if (!ModelState.IsValid) BadRequest(ModelState);
			var check = await services.PokemonExists(pokemonId);
			if (check == false) return BadRequest("Invalid Category Id");
			var res = await services.UpdatePokemon(pokemonId, pokemon);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
		[HttpDelete("{pokemonId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeletePokemon(int pokemonId) {
			var check = await services.PokemonExists(pokemonId);
			if (!check) return BadRequest("Invalid Category Id");
			var res = await services.DeletePokemon(pokemonId);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
	} 
}

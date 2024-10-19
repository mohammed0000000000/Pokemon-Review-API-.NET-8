using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class OwnerController : ControllerBase
	{
		private readonly IOwnerServices services;

		public OwnerController(IOwnerServices services) {
			this.services = services;
		}
		[HttpGet]
		[ProducesResponseType(200,Type = typeof(IEnumerable<OwnerDto>))]
		public async Task<IActionResult> GetOwners(){
			var res = await services.GetOwners();
			return Ok(res);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type = typeof(OwnerDto))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetOwner(int id){
			var res = await services.GetOwner(id);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpGet("{pokemonId:int}/owners")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetOwnerPokemons(int pokemonId) {
			var res = await services.GetOwnerOfPokemon(pokemonId);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpGet("{ownerId:int}/pokemons")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<OwnerDto>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetPokemons(int ownerId) {
			var res = await services.GetPokemonsByOwner(ownerId);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreateOwner(CreateOwnerDto owner){
			if(!ModelState.IsValid)return BadRequest(ModelState);
			var res = await services.CreateOwner(owner);
			return res ? Ok("Created") : StatusCode(500, "Interal Server Error");
		}
	}
}

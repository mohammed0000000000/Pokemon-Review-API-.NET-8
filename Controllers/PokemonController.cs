using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PokemonController : ControllerBase
	{
		private readonly IPokemonServices services;	
		public PokemonController(IPokemonServices services) { 
			this.services = services;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(ICollection<PokemonDto>))]
		public async Task<IActionResult> GetAll(){
			var response = await services.GetPokemons();
			return Ok(response);	
		}
	}
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CategoryController : ControllerBase
	{
		private readonly ICategoryServices services;

		public CategoryController(ICategoryServices services) {
			this.services = services;
		}
		[HttpGet]
		[ProducesResponseType(200, Type = typeof(ICollection<CategoryDto>))]
		public async Task<IActionResult> GetAll(){
			var res = await services.GetCategories();
			return Ok(res);	
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type = typeof(CategoryDto))]
		[ProducesResponseType(statusCode: 400)]

		public async Task<IActionResult> GetCategory(int id){
			var res = await services.GetCategoryById(id);
			if (res is null)
				return BadRequest();
			return Ok(res);
		}

		[HttpGet("{name:alpha}")]
		[ProducesResponseType(200, Type = typeof(CategoryDto))]
		[ProducesResponseType(statusCode: 400)]
		public async Task<IActionResult> GetCategory(string name){
			var res = await services.GetCategoryByName(name);
			if (res is null)
				return BadRequest();
			return Ok(res);
		}
		[HttpGet("{categoryId:int}/pokemons")]
		[ProducesResponseType(200, Type = typeof(ICollection<PokemonDto>))]
		[ProducesResponseType(statusCode: 400)]
		public async Task<IActionResult> GetPokemons(int categoryId){
			var check = await services.CategoryExists(categoryId);
			if(check == false)return BadRequest();
			var res = await services.GetPokemonsByCategory(categoryId);
			return Ok(res);
		}
	}
}

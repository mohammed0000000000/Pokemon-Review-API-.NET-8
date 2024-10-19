using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CountryController : ControllerBase
	{
		private readonly ICountryServices services;

		public CountryController(ICountryServices services) {
			this.services = services;
		}

		[HttpGet]
		[ProducesResponseType(200, Type= typeof(ICollection<CountryDto>))]
		public async Task<IActionResult> GetAll() {
			var res = await services.GetCountries();
			return Ok(res);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200,Type = typeof(CountryDto))]
		[ProducesResponseType(400)]
		public async Task<IActionResult>GetCountry(int id){
			var res = await services.GetCountry(id);	
			return res is null ? BadRequest():Ok(res);
		}

		[HttpGet("{ownerId:int}/cournty")]
		[ProducesResponseType(200, Type = typeof(CountryDto))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetCountryByOwner(int ownerId) {
			var res = await services.GetCountryByOwnerId(ownerId);
			return res is null ? BadRequest() : Ok(res);
		}


		[HttpGet("{countryId:int}/owners")]
		[ProducesResponseType(200, Type = typeof(ICollection<OwnerDto>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetOwners(int id) {
			var res = await services.GetOwners(id);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreatCountry(CreateCountryDto country) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var res = await services.CreateCountry(country);
			return res ? Ok("Created") : StatusCode(500, "Enteral Server Error");
		}

		[HttpPut("{countryId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateCountry(int countryId, CreateCountryDto country) {
			if (!ModelState.IsValid) BadRequest(ModelState);
			var check = await services.CountryExists(countryId);
			if (check == false) return BadRequest("Invalid Category Id");
			var res = await services.UpdateCountry(countryId, country);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
		[HttpDelete("{countryId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteCountry(int countryId) {
			var check = await services.CountryExists(countryId);
			if (!check) return BadRequest("Invalid Category Id");
			var res = await services.DeleteCountry(countryId);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
	}
}

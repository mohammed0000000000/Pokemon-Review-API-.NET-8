using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewController : ControllerBase
	{
		private readonly IReviewServices services;

		public ReviewController(IReviewServices services) {
			this.services = services;
		}

		[HttpGet]
		[ProducesResponseType(200, Type= typeof(IEnumerable<ReviewDto>))]
		public async Task<IActionResult> GetReviews(){
			var res = await services.GetReviews();	
			return Ok(res);
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type = typeof(ReviewDto))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetReview(int id){
			var res = await services.GetReview(id);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpGet("{pokemonId:int}/reviews")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetPokemonReviews(int pokemonId) {
			var res = await services.GetReviewsOfPokemon(pokemonId);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreateReview(CreateReviewDto review){
			if(!ModelState.IsValid) return BadRequest();
			var res = await services.CreateReview(review);
			return res ? Ok("Created") : StatusCode(500, ModelState);
		}

		[HttpPut("{reviewId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> UpdateReview(int reviewId, CreateReviewDto review) {
			if (!ModelState.IsValid) BadRequest(ModelState);
			var check = await services.ReviewExists(reviewId);
			if (check == false) return BadRequest("Invalid review Id");
			var res = await services.UpdateReview(reviewId, review);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
		[HttpDelete("{reviewId:int}")]
		[ProducesResponseType(400)]
		[ProducesResponseType(204)]
		[ProducesResponseType(404)]
		public async Task<IActionResult> DeleteReview(int reviewId) {
			var check = await services.ReviewExists(reviewId);
			if (!check) return BadRequest("Invalid review Id");
			var res = await services.DeleteReview(reviewId);
			return res ? NoContent() : StatusCode(500, "Internal Server Error");
		}
	}
}

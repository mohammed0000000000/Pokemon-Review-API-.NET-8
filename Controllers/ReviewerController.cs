using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ReviewerController : ControllerBase
	{
		private readonly IReviewerServices services;

		public ReviewerController(IReviewerServices services) {
			this.services = services;
		}

		[HttpGet]
		[ProducesResponseType(200, Type = typeof(IEnumerable<ReviewerDto>))]
		public async Task<IActionResult>GetAllReviews(){
			var res = await services.GetReviewers();
			return Ok(res);	
		}

		[HttpGet("{id:int}")]
		[ProducesResponseType(200, Type = typeof(ReviewerDto))]
		public async Task<IActionResult> GetReviewer(int id) {
			var res = await services.GetReviewer(id);
			return res is null ?BadRequest():Ok(res);
		}

		[HttpGet("{reviewerId:int}/reviews")]
		[ProducesResponseType(200, Type = typeof(IEnumerable<ReviewDto>))]
		public async Task<IActionResult> GetReviewReviews(int reviewerId) {
			var res = await services.GetReviewsByReviewer(reviewerId);
			return res is null ? BadRequest() : Ok(res);
		}

		[HttpPost]
		[ProducesResponseType(204)]
		[ProducesResponseType(400)]
		[ProducesResponseType(500)]
		public async Task<IActionResult> CreatePokemon(ReviewerDto reviewer) {
			if (!ModelState.IsValid) {
				return BadRequest(ModelState);
			}
			var res = await services.CreateReviewer(reviewer);
			return res ? Ok("Created Successfully") : StatusCode(500, ModelState);
		}
	}
}

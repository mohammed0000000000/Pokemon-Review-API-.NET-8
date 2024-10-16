﻿using Microsoft.AspNetCore.Http;
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
	}
}

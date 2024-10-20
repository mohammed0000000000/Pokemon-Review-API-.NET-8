﻿using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface IReviewServices
	{
		Task<ICollection<ReviewDto>> GetReviews();
		Task<ReviewDto> GetReview(int id);	
		Task<ICollection<ReviewDto>>GetReviewsOfPokemon(int pokemonId);
		Task<bool> ReviewExists(int reviewId);
		Task<bool>CreateReview(CreateReviewDto review);
		Task<bool> UpdateReview(int reviewId, CreateReviewDto review);
		Task<bool> DeleteReview(int reviewId);
	}
}

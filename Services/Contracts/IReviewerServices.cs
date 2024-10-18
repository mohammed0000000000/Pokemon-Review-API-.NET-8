using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface IReviewerServices
	{
		Task<ICollection<ReviewerDto>> GetReviewers();
		Task<ReviewerDto> GetReviewer(int id);
		Task<ICollection<ReviewDto>> GetReviewsByReviewer(int id);
		Task<bool> ReviewerExists(int id);
		Task<bool> CreateReviewer(ReviewerDto reviewer);
	}
}

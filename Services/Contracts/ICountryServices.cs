using PokemonReviewAPI.DTO;

namespace PokemonReviewAPI.Services.Contracts
{
	public interface ICountryServices
	{
		Task<ICollection<CountryDto>> GetCountries();
		Task<CountryDto> GetCountry(int id);
		Task<CountryDto> GetCountryByOwnerId(int ownerId);
		Task<ICollection<OwnerDto>> GetOwners(int countryId);
		Task<bool> CountryExists(int id);
	}
}

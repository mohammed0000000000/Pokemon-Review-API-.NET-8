using AutoMapper;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Helper
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles() {
			CreateMap<Pokemon, PokemonDto>().ReverseMap();
			CreateMap<Category, CategoryDto>().ReverseMap();
			CreateMap<Country, CountryDto>().ReverseMap();
			CreateMap<Owner, OwnerDto>().ReverseMap();
			CreateMap<Review, ReviewDto>().ReverseMap();
			CreateMap<Reviewer, ReviewerDto>().ReverseMap();

			CreateMap<Pokemon, CreatePokemonDto>().ReverseMap();
			CreateMap<Category, CreateCategoryDto>().ReverseMap();
			CreateMap<Country, CreateCountryDto>().ReverseMap();
			CreateMap<Owner, CreateOwnerDto>().ReverseMap();
			CreateMap<Review, CreateReviewDto>().ReverseMap();
		}
	}
}

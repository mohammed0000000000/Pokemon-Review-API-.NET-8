using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PokemonReviewAPI.Data;
using PokemonReviewAPI.DTO;
using PokemonReviewAPI.Models;
using PokemonReviewAPI.Repository;
using PokemonReviewAPI.Services.Contracts;

namespace PokemonReviewAPI.Services.Implementation
{
	public class CountryServices : ICountryServices
	{
		private readonly IRepository<Country, int> repository;
		private readonly IMapper mapper;
		private readonly AppDbContext context;

		public CountryServices(IRepository<Country,int> repository,IMapper mapper, AppDbContext context) {
			this.repository = repository;
			this.mapper = mapper;
			this.context = context;
		}
		public async Task<bool> CountryExists(int id) {
			var exists = await context.Countries.AnyAsync(c => c.Id == id);	
			return exists;
		}

		public async Task<ICollection<CountryDto>> GetCountries() {
			var models = await repository.GetAll();
			var countries = mapper.Map<List<CountryDto>>(models);
			return countries;
		}

		public async Task<CountryDto> GetCountry(int id) {
			var model = await repository.GetbyId(id);
			var country = mapper.Map<CountryDto>(model);	
			return country;
		}

		public async Task<CountryDto> GetCountryByOwnerId(int ownerId) {
			var model = await context.Owners.Where(x => x.Id == ownerId).Select(x => x.Country).FirstOrDefaultAsync();
			var country = mapper.Map<CountryDto>(model);
			return country;
		}

		public async Task<ICollection<OwnerDto>> GetOwners(int countryId) {
			var models = await context.Countries.Where(x => x.Id == countryId).Select(x => x.Owners).ToListAsync();
			var owners = mapper.Map<List<OwnerDto>>(models);
			return owners;
		}

		public async Task<bool>CreateCountry(CreateCountryDto country){
			var model = mapper.Map<Country>(country);
			var res = await repository.Create(model);
			return res is not null;
		}

		public async Task<bool> UpdateCountry(int id, CreateCountryDto country) {
			var model = mapper.Map<Country>(country);
			model.Id = id;
			var res = await repository.Update(model);
			return res;
		}

		public async Task<bool> DeleteCountry(int id) {
			return await (repository.DeleteById(id));
		}
	}
}

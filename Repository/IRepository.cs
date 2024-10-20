﻿namespace PokemonReviewAPI.Repository
{
	public interface IRepository<T, K> where T: class
	{
		Task<T> Create(T entity);
		Task AddRange(List<T> entities);
		Task<bool> Update(T entity);
		Task<bool> DeleteById(int id);
		Task<bool> Delete(T entity);
		Task<T> GetbyId(int id);
		Task<IQueryable<T>> GetAll(bool includeSoftedDeleted = false);
	}
}

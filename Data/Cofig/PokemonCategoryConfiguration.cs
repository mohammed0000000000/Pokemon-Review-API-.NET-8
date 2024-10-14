using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Data.Cofig
{
	public class PokemonCategoryConfiguration : IEntityTypeConfiguration<PokemonCategory>
	{
		public void Configure(EntityTypeBuilder<PokemonCategory> builder) {
			builder.HasKey(x => new { x.PokemonId, x.CategoryId });
			builder.HasOne(x => x.Category).WithMany(x => x.PokemonCategories).HasForeignKey(x => x.CategoryId);
			builder.HasOne(x => x.Pokemon).WithMany(x => x.PokemonCategories).HasForeignKey(x => x.PokemonId);
		}
	}
}

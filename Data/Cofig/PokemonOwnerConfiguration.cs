using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PokemonReviewAPI.Models;

namespace PokemonReviewAPI.Data.Cofig
{
	public class PokemonOwnerConfiguration : IEntityTypeConfiguration<PokemonOwner>
	{
		public void Configure(EntityTypeBuilder<PokemonOwner> builder) {
			builder.HasKey(x => new {x.PokemonId, x.OwnerId});
			builder.HasOne(x => x.Owner).WithMany(x => x.PokemonOwners).HasForeignKey(x => x.OwnerId);
			builder.HasOne(x => x.Pokemon).WithMany(x => x.PokemonOwners).HasForeignKey(x => x.PokemonId);
		}
	}
}

namespace PokemonReviewAPI.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }

        public ICollection<Review> Reviews { get; set; } = new List<Review>();
        public ICollection<PokemonOwner> PokemonOwners { get; set; } = new List<PokemonOwner>();
        public ICollection<PokemonCategory> PokemonCategories { get; set; } = new List<PokemonCategory>();

    }
}

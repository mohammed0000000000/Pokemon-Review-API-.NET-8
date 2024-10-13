namespace PokemonReviewAPI.Models
{
	public class Pokemon
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime BirthDate { get; set; } 

        ICollection<Review> Reviews { get; set; }
        //ICollection<Owner> PokemonOwners { get; set; } 
        //ICollection<Category> PokemonCategories { get; set; }
    }
}

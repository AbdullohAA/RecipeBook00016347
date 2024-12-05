namespace RecipeBook00016347.Domain.Entities;

public class RecipeBook
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<Recipe> Recipes { get; set; }
}

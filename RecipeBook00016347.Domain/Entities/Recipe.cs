namespace RecipeBook00016347.Domain.Entities;

public class Recipe
{
    public long Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Steps { get; set; }
    public DateTime CreatedAt { get; set; }
    public long RecipeBookId { get; set; }
    public RecipeBook RecipeBook { get; set; }
}

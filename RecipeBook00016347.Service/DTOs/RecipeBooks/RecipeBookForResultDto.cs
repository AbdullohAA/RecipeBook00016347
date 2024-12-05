using RecipeBook00016347.Service.DTOs.Recipes;

namespace RecipeBook00016347.Service.DTOs.RecipeBooks;

public class RecipeBookForResultDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public DateTime CreatedAt { get; set; }
    public ICollection<RecipeForResultDto> Recipes { get; set; }
}

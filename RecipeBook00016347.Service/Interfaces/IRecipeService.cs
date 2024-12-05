using RecipeBook00016347.Service.DTOs.Recipes;

namespace RecipeBook00016347.Service.Interfaces;

public interface IRecipeService
{
    public Task<bool> RemoveByIdAsync(long id);
    public Task<bool> AddAsync(RecipeForCreationDto dto);
    public Task<RecipeForResultDto> RetrieveByIdAsync(long id);
    public Task<bool> ModifyAsync(long id, RecipeForUpdateDto dto);
    public Task<IEnumerable<RecipeForResultDto>> RetrieveAllAsync();

}

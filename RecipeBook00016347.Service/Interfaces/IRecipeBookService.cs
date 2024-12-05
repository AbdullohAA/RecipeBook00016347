using RecipeBook00016347.Service.DTOs.RecipeBooks;

namespace RecipeBook00016347.Service.Interfaces;

public interface IRecipeBookService
{
    public Task<bool> RemoveByIdAsync(long id);
    public Task<bool> AddAsync(RecipeBookForCreationDto dto);
    public Task<RecipeBookForResultDto> RetrieveByIdAsync(long id);
    public Task<bool> ModifyAsync(long id, RecipeBookForUpdateDto dto);
    public Task<IEnumerable<RecipeBookForResultDto>> RetrieveAllAsync();
}

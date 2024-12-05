using RecipeBook00016347.Domain.Entities;

namespace RecipeBook00016347.DAL.IRepositories;

public interface IRecipeRepository
{
    public Task<bool> UpdateAsync(Recipe recipe);
    public IQueryable<Recipe> SelectAll();
    public Task<bool> DeleteByIdAsync(long id);
    public Task<Recipe> SelectByIdAsync(long id);
    public Task<bool> InsertAsync(Recipe recipe);
}

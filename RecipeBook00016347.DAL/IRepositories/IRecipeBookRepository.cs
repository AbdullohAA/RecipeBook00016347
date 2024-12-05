using RecipeBook00016347.Domain.Entities;

namespace RecipeBook00016347.DAL.IRepositories;

public interface IRecipeBookRepository
{
    public Task<bool> UpdateAsync(RecipeBook recipeBook);
    public IQueryable<RecipeBook> SelectAll();
    public Task<bool> DeleteByIdAsync(long id);
    public Task<RecipeBook> SelectByIdAsync(long id);
    public Task<bool> InsertAsync(RecipeBook recipeBook);
}

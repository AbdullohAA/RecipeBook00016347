using Microsoft.EntityFrameworkCore;
using RecipeBook00016347.DAL.DbContexts;
using RecipeBook00016347.Domain.Entities;
using RecipeBook00016347.DAL.IRepositories;

namespace RecipeBook00016347.DAL.Repositories;

public class RecipeRepository : IRecipeRepository
{
    private readonly AppDbContext dbContext;

    public RecipeRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var recipe = await dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        dbContext.Recipes.Remove(recipe);
        return await dbContext.SaveChangesAsync()>0;
    }

    public async Task<bool> InsertAsync(Recipe recipe)
    {
        await dbContext.Recipes.AddAsync(recipe);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<Recipe> SelectAll()
    {
        var recipes = dbContext.Recipes;
        return recipes;
    }

    public async Task<Recipe> SelectByIdAsync(long id)
    {
        var recipe = await dbContext.Recipes.FirstOrDefaultAsync(r => r.Id == id);
        return recipe;
    }

    public async Task<bool> UpdateAsync(Recipe recipe)
    {
        dbContext.Recipes.Update(recipe);
        return await this.dbContext.SaveChangesAsync() > 0;
    }
}

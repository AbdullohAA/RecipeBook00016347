using Microsoft.EntityFrameworkCore;
using RecipeBook00016347.DAL.DbContexts;
using RecipeBook00016347.Domain.Entities;
using RecipeBook00016347.DAL.IRepositories;

namespace RecipeBook00016347.DAL.Repositories;

public class RecipeBookRepository : IRecipeBookRepository
{
    private readonly AppDbContext dbContext;

    public RecipeBookRepository(AppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<bool> DeleteByIdAsync(long id)
    {
        var recipeBook = await dbContext.RecipeBooks.FirstOrDefaultAsync(r => r.Id == id);
        dbContext.RecipeBooks.Remove(recipeBook);
        return await dbContext.SaveChangesAsync() > 0;
    }

    public async Task<bool> InsertAsync(RecipeBook recipeBook)
    {
        await this.dbContext.RecipeBooks.AddAsync(recipeBook);
        return await this.dbContext.SaveChangesAsync() > 0;
    }

    public IQueryable<RecipeBook> SelectAll()
    {
        var recipeBooks = dbContext.RecipeBooks;
        return recipeBooks;
    }

    public async Task<RecipeBook> SelectByIdAsync(long id)
    {
        var recipeBook = await dbContext.RecipeBooks.FirstOrDefaultAsync(r => r.Id == id);
        return recipeBook;
    }

    public async Task<bool> UpdateAsync(RecipeBook recipeBook)
    {
        dbContext.RecipeBooks.Update(recipeBook);
        return await dbContext.SaveChangesAsync() > 0;
    }
}

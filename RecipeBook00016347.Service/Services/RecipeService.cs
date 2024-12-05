using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBook00016347.Domain.Entities;
using RecipeBook00016347.DAL.IRepositories;
using RecipeBook00016347.Service.Interfaces;
using RecipeBook00016347.Service.DTOs.Recipes;
using RecipeBook00016347.Service.Exceptions;

namespace RecipeBook00016347.Service.Services;

public class RecipeService : IRecipeService
{
    private readonly IMapper mapper;
    private readonly IRecipeRepository recipeRepository;

    public RecipeService(IMapper mapper, IRecipeRepository recipeRepository)
    {
        this.mapper = mapper;
        this.recipeRepository = recipeRepository;
    }

    public async Task<bool> AddAsync(RecipeForCreationDto dto)
    {
        var recipe = mapper.Map<Recipe>(dto);
        recipe.CreatedAt = DateTime.UtcNow;

        return await this.recipeRepository.InsertAsync(recipe);
    }

    public async Task<bool> ModifyAsync(long id, RecipeForUpdateDto dto)
    {
        var recipe = await this.recipeRepository.SelectByIdAsync(id);
        if (recipe is null)
            throw new RecipeBookException(404, "Recipe not found");

        var mappedRecipe = this.mapper.Map(dto,recipe);
        mappedRecipe.Id = id;
        return await this.recipeRepository.UpdateAsync(mappedRecipe);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var recipe = await this.recipeRepository.SelectByIdAsync(id);
        if (recipe is null)
            throw new RecipeBookException(404, "Recipe not found");

        return await this.recipeRepository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<RecipeForResultDto>> RetrieveAllAsync()
    {
        var recipes = await this.recipeRepository.SelectAll().ToListAsync();
        return this.mapper.Map<IEnumerable<RecipeForResultDto>>(recipes);
    }

    public async Task<RecipeForResultDto> RetrieveByIdAsync(long id)
    {
        var recipe = await this.recipeRepository.SelectByIdAsync(id);
        if (recipe is null)
            throw new RecipeBookException(404, "Recipe not found");

        return this.mapper.Map<RecipeForResultDto>(recipe);
    }
}

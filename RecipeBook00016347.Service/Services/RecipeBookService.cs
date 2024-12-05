using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RecipeBook00016347.Domain.Entities;
using RecipeBook00016347.DAL.IRepositories;
using RecipeBook00016347.Service.Interfaces;
using RecipeBook00016347.Service.DTOs.RecipeBooks;
using RecipeBook00016347.Service.Exceptions;

namespace RecipeBook00016347.Service.Services;

public class RecipeBookService : IRecipeBookService
{
    private readonly IMapper mapper;
    private readonly IRecipeBookRepository recipeBookRepository;

    public RecipeBookService(IMapper mapper, IRecipeBookRepository recipeBookRepository)
    {
        this.mapper = mapper;
        this.recipeBookRepository = recipeBookRepository;
    }

    public async Task<bool> AddAsync(RecipeBookForCreationDto dto)
    {
        var recipeBook = await this.recipeBookRepository.SelectAll()
            .Where(rb => rb.Name.ToLower() == dto.Name.ToLower())
            .FirstOrDefaultAsync();
        if (recipeBook is not null)
            throw new RecipeBookException(409,"Recipe book already exists");

        var mappedRecipeBook = this.mapper.Map<RecipeBook>(dto);
        mappedRecipeBook.CreatedAt = DateTime.UtcNow;
        return await this.recipeBookRepository.InsertAsync(mappedRecipeBook);
    }

    public async Task<bool> ModifyAsync(long id, RecipeBookForUpdateDto dto)
    {
        var recipeBook = await this.recipeBookRepository.SelectByIdAsync(id);
        if (recipeBook is null)
            throw new RecipeBookException(404,"Recipe book not found");

        var mappedRecipeBook = this.mapper.Map(dto, recipeBook);
        return await this.recipeBookRepository.UpdateAsync(mappedRecipeBook);
    }

    public async Task<bool> RemoveByIdAsync(long id)
    {
        var recipeBook = await this.recipeBookRepository.SelectByIdAsync(id);
        if (recipeBook is null)
            throw new RecipeBookException(404, "Recipe book not found");


        return await this.recipeBookRepository.DeleteByIdAsync(id);
    }

    public async Task<IEnumerable<RecipeBookForResultDto>> RetrieveAllAsync()
    {
        var recipeBooks = await this.recipeBookRepository.SelectAll()
            .Include(rb => rb.Recipes)
            .ToListAsync();

        return this.mapper.Map<IEnumerable<RecipeBookForResultDto>>(recipeBooks);
    }

    public async Task<RecipeBookForResultDto> RetrieveByIdAsync(long id)
    {
        var recipeBook = await this.recipeBookRepository.SelectAll()
            .Include(rb => rb.Recipes)
            .Where(rb => rb.Id == id)
            .FirstOrDefaultAsync();
        if (recipeBook is null)
            throw new RecipeBookException(404,"Recipe book not found");

        return this.mapper.Map<RecipeBookForResultDto>(recipeBook);
    }
}

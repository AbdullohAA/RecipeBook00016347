using AutoMapper;
using RecipeBook00016347.Domain.Entities;
using RecipeBook00016347.Service.DTOs.RecipeBooks;
using RecipeBook00016347.Service.DTOs.Recipes;

namespace RecipeBook00016347.Service.Mappers;

public class MappingProfie : Profile
{
    public MappingProfie()
    {
        // Recipes
        CreateMap<Recipe, RecipeForResultDto>().ReverseMap();
        CreateMap<Recipe, RecipeForUpdateDto>().ReverseMap();
        CreateMap<Recipe, RecipeForCreationDto>().ReverseMap();

        // RecipeBooks
        CreateMap<RecipeBook,RecipeBookForUpdateDto>().ReverseMap();
        CreateMap<RecipeBook, RecipeBookForCreationDto>().ReverseMap();
        CreateMap<RecipeBook, RecipeBookForResultDto>().ReverseMap();
    }
}

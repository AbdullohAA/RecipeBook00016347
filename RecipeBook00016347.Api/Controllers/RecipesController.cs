using Microsoft.AspNetCore.Mvc;
using RecipeBook00016347.Api.Helpers;
using RecipeBook00016347.Service.Interfaces;
using RecipeBook00016347.Service.DTOs.Recipes;

namespace RecipeBook00016347.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        this.recipeService = recipeService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeService.RetrieveAllAsync()
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeService.RetrieveByIdAsync(id)
        });
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RecipeForCreationDto dto)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeService.AddAsync(dto)
        });
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] RecipeForUpdateDto dto)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeService.ModifyAsync(id, dto)
        });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeService.RemoveByIdAsync(id)
        });
    }
}

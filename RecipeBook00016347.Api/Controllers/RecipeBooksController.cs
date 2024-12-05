using Microsoft.AspNetCore.Mvc;
using RecipeBook00016347.Api.Helpers;
using RecipeBook00016347.Service.DTOs.RecipeBooks;
using RecipeBook00016347.Service.Interfaces;

namespace RecipeBook00016347.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RecipeBooksController : ControllerBase
{
    private readonly IRecipeBookService recipeBookService;

    public RecipeBooksController(IRecipeBookService recipeBookService)
    {
        this.recipeBookService = recipeBookService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeBookService.RetrieveAllAsync()
        });
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(long id)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeBookService.RetrieveByIdAsync(id)
        });
    }
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] RecipeBookForCreationDto dto)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeBookService.AddAsync(dto)
        });
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutAsync(long id, [FromBody] RecipeBookForUpdateDto dto)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeBookService.ModifyAsync(id, dto)
        });
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAsync(long id)
    {
        return Ok(new Response
        {
            Code = 200,
            Message = "Success",
            Data = await this.recipeBookService.RemoveByIdAsync(id)
        });
    }
}

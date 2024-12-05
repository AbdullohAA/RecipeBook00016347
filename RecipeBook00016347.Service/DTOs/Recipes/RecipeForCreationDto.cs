﻿namespace RecipeBook00016347.Service.DTOs.Recipes;

public class RecipeForCreationDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Ingredients { get; set; }
    public string Steps { get; set; }
    public long RecipeBookId { get; set; }
}
namespace RecipeBook00016347.Service.Exceptions;

public class RecipeBookException : Exception
{
    public int StatusCode { get; set; }
    public RecipeBookException(int statusCode, string message) : base(message)
    {
        this.StatusCode = statusCode;
    }
}

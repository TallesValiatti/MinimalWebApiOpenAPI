using Microsoft.OpenApi.Models;
using MinimalWebApiOpenAPI.Dtos;

namespace MinimalWebApiOpenAPI.Endpoints;

public static class GetAllUsers
{
    private const string Path = "/users";
    public static WebApplication UseGetAllUsersEndpoint(this WebApplication app)
    {
        app.MapGet(Path, (string? email) =>
            {
                // Fetch all users
                return Results.Ok();
            })
        .WithName("GetAllUsers")
        .WithOpenApi(GenerateOperation())
        .Produces<IList<UserDto>>(StatusCodes.Status200OK, "application/json")
        .Produces<ApiError>(StatusCodes.Status400BadRequest, "application/json");

        return app;
    }

    private static Func<OpenApiOperation, OpenApiOperation> GenerateOperation()
    {
        return operation =>
        {
            // Summary 
            operation.Summary = "Endpoint used to fetch users";
            
            // Parameters
            var parameter = operation.Parameters[0];
            parameter.Description = "The user e-mail. It will filter the users by using this value";
            parameter.Required = false;
            parameter.AllowEmptyValue = true;
            parameter.Examples = new Dictionary<string, OpenApiExample>
            {
                {"talles.valiatt@tallesvaliatti.com", new OpenApiExample
                {
                    Description = "It will filter users who have their email as 'talles.valatt@tallesvaliatti.com'"
                }},
                
                {"talles", new OpenApiExample
                {
                    Description = "It will filter users if their email contains the word 'talles'"
                }},
            };
            
            return operation;
        };   
    }
}


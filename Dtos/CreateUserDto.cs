using System.Reflection;
using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace MinimalWebApiOpenAPI.Dtos;

public record CreateUserDto(Guid Id, string Email) : IEndpointParameterMetadataProvider
{
    public static void PopulateMetadata(ParameterInfo parameter, EndpointBuilder builder)
    {
        builder.Metadata.Add(new ConsumesAttribute(typeof(CreateUserDto), "application/json"));
        builder.Metadata.Add(new Attr);
    }
};
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WPR.Web.Swagger;

public static class SwaggerConfiguration
{
    public static void SetUp(SwaggerGenOptions options)
    {
        var assemblyName = typeof(SwaggerConfiguration).Assembly.GetName();

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "WPR.Web",
            Description = "Веб платформа для размещения проектов, и их оценивания",
            Version = assemblyName.Version?.ToString(),
            Contact = new OpenApiContact
            {
                Name = "Nebytov Daniil, Vyacheslav Kryuchkovenko"
            }
        });

        var xmlFile = $"{assemblyName.Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
        options.IncludeXmlComments(xmlPath);
    }
}
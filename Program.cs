var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
    {
        options.AddDefaultPolicy(policy =>
            {
                policy
                    .AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            }
        );
    }
); // <-- Agregado punto y coma

var app = builder.Build();

app.UseCors(); // <-- Agregado punto y coma

app.MapGet("/", () =>
{
    return "API Polleria funcionando";
});

app.MapGet("/api/polleria", () =>
{
    return Results.Ok(new[]
    {
        new {
            id = 1,
            codigo = "P001",
            nombre = "Pollo a la brasa",
        },
        new {
            id = 2,
            codigo = "P002",
            nombre = "Pollo broaster",
        }
    });
});

// Corregida la variable y la sintaxis de la URL
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000"; 
app.Run($"http://0.0.0.0:{port}");

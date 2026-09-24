var builder = WebApplication.CreateBuilder(args);

// 1. Configuración correcta de CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
}); 

var app = builder.Build();

// 2. Uso de Middleware
app.UseCors();

// 3. Endpoints simplificados (sin llaves innecesarias para una sola línea)
app.MapGet("/", () => "API Polleria funcionando"); 

app.MapGet("/api/polleria", () =>
{
    // Usamos new object[] para evitar errores de compilación con tipos anónimos
    return Results.Ok(new object[]
    {
        new {
            id = 1,
            codigo = "P001",
            nombre = "Pollo a la brasa"
        },
        new {
            id = 2,
            codigo = "P002",
            nombre = "Pollo broaster"
        }
    });
});

// 4. Configuración del puerto para producción/despliegue
var port = Environment.GetEnvironmentVariable("PORT") ?? "10000";
app.Run($"http://0.0.0.0:{port}");

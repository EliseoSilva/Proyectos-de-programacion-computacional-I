using System.IO;
using Microsoft.AspNetCore.Authentication.Cookies;
using Comunidad_Conecta_Formularios_Web.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Controladores de la API
builder.Services.AddControllers();
builder.Services
    .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "ComunidadConecta.Auth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.SameSite = SameSiteMode.Lax;
        options.ExpireTimeSpan = TimeSpan.FromHours(2);
        options.SlidingExpiration = true;

        options.Events.OnRedirectToLogin = context =>
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            return Task.CompletedTask;
        };

        options.Events.OnRedirectToAccessDenied = context =>
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            return Task.CompletedTask;
        };
    });

// OpenAPI
builder.Services.AddOpenApi();

// Conexión con SQL Server
var connectionString = builder.Configuration
    .GetConnectionString("ComunidadConecta");

if (string.IsNullOrWhiteSpace(connectionString))
{
    throw new InvalidOperationException(
        "No se encontró la cadena de conexión 'ComunidadConecta' en appsettings.json.");
}

builder.Services.AddDbContext<ComunidadConectaContext>(options =>
    options.UseSqlServer(connectionString));


var app = builder.Build();

// Configuración de solicitudes HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

// Archivos estáticos de CSS, JavaScript e imágenes.
// Se excluyen las páginas HTML para evitar el acceso directo.
app.UseWhen(
    context => !context.Request.Path.StartsWithSegments("/paginas"),
    appBuilder =>
    {
        appBuilder.UseDefaultFiles();
        appBuilder.UseStaticFiles();
    });

// Controladores
app.MapControllers();

// Página pública de inicio de sesión
app.MapGet("/", (IWebHostEnvironment environment) =>
{
    var ruta = Path.Combine(environment.WebRootPath, "index.html");
    return Results.File(ruta, "text/html");
});

app.Run();


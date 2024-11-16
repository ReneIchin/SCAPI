using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Models.DB_SEGURIDAD;
using System.Threading.Tasks;

namespace SCAPI.Helpers
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-Api-Key";
        private const string UsuarioIdHeaderName = "user-id";
        private readonly IConfiguration _configuration;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        
        public Middleware(RequestDelegate next, IConfiguration configuration, IServiceScopeFactory serviceScopeFactory)
        {
            this._next = next;
            this._configuration = configuration;
            this._serviceScopeFactory = serviceScopeFactory;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                if (context.Request.Path.StartsWithSegments("/api/Login/LoginUser"))
                {
                    // Si el método es loginUsuario, puede continuar sin verificar la API Key (x)
                    await _next(context);
                    return;
                }

                using (var scope = _serviceScopeFactory.CreateScope())
                {

                    // Verificar si el encabezado contiene la API Key
                    if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
                    {
                        context.Response.StatusCode = 401; // No autorizado
                        await context.Response.WriteAsync("API Key is missing.");
                        return;
                    }

                    if (!context.Request.Headers.TryGetValue(UsuarioIdHeaderName, out var providedUsuarioId))
                    {
                        context.Response.StatusCode = 400; // Bad Request
                        await context.Response.WriteAsync("Usuario ID is missing.");
                        return;
                    }

                    if (!Guid.TryParse(providedUsuarioId.ToString(), out var usuarioIdGuid))
                    {
                        context.Response.StatusCode = 400; // Bad Request
                        await context.Response.WriteAsync("Invalid Usuario ID format.");
                        return;
                    }

                    //var dbContext = scope.ServiceProvider.GetRequiredService<DB_SEG>();
                    var usuarioKeyService = scope.ServiceProvider.GetRequiredService<IUsuarioKey>();
                    var response = await usuarioKeyService.GetUsuarioKey(usuarioIdGuid, true, extractedApiKey);

                    //var apiKeyExists = await dbContext.USUARIO_KEY.AnyAsync(x => x.API_KEY == extractedApiKey && x.STATUS == true && x.USUARIO_ID == usuarioIdGuid);

                    // Comparar la API Key extraída con la API Key almacenada
                    if (response == null)
                    {
                        context.Response.StatusCode = 401; // Unauthorized
                        await context.Response.WriteAsync("Invalid API Key or User ID.");
                        return;
                    }
                    // Continuar con el siguiente middleware si la API Key es válida
                    await _next(context);
                }
            }
            catch (Exception)
            {

                throw;
            }
             
              
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline. 9lUlDRPpOPZ
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<Middleware>();
        }
    }
}

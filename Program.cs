using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SCAPI.Helpers;
using SCAPI.Models.DB_SEGURIDAD;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SCAPI.Interfaz.ISEGURIDAD;
using SCAPI.Service.SEG_SERVICE;
using SCAPI.Models.DTO.DB_SEG_DTO;
using SCAPI.Models.RESTVELT;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
//builder.WebHost.UseUrls("https://localhost:7181/");
// Add services to the container.

builder.Services.AddSingleton(provider =>
{
    var config = new MapperConfiguration(cfg =>
    {
        cfg.AddProfile<MappingProfile>(); // Reemplaza MappingProfile con tu perfil de mapeo
    });
    return config.CreateMapper();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", builder =>
    {
        builder.WithOrigins("http://localhost:4200") // Cambia el puerto si es necesario
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddDbContext<DB_SEG>(X => X.UseSqlServer(builder.Configuration.GetConnectionString("DBSEGURIDAD")));
builder.Services.AddDbContext<DTO_CONTEXT>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DBSEGURIDAD")));
builder.Services.AddDbContext<DB_RESTVELT>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("RESTVELT")));

// Interfaz de DB_SEGURIDAD
builder.Services.AddScoped<IAcciones, AccionesService>();
builder.Services.AddScoped<IEmpresas, EmpresaService>();
builder.Services.AddScoped<IGruposModulos, GrupoModuloService>();
builder.Services.AddScoped<IModulos, ModuloService>();
builder.Services.AddScoped<IPermisosModulos, PermisoModuloService>();
builder.Services.AddScoped<IRol, RolService>();
builder.Services.AddScoped<ISistemas, SistemaService>();
builder.Services.AddScoped<ITiposEmpresas, TipoEmpresaService>();
builder.Services.AddScoped<ITiposPagos, TipoPagoService>();
builder.Services.AddScoped<IUsuario, UsuarioService>();
builder.Services.AddScoped<IGetSP, getSPService>();
builder.Services.AddScoped<ISelectList, SelectService>();
builder.Services.AddScoped<ITipoContrato, TipoContratoService>();
builder.Services.AddScoped<IUsuarioKey, UsuarioKeyService>();

builder.Services.AddControllers().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null).AddNewtonsoftJson(options => { options.SerializerSettings.ContractResolver = new DefaultContractResolver(); });
builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
builder.Services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(option =>
//{
//    option.Cookie.HttpOnly = true;
//    option.ExpireTimeSpan = TimeSpan.FromMinutes(30);
//    option.LoginPath = "/Login/LoginUser"; //establecer un Login
//    option.AccessDeniedPath = "/Home/Error";
//    option.SlidingExpiration = true;
//});

builder.Configuration.AddJsonFile("appsettings.json");

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<Middleware>();
app.MapGet("/", () => "API is working.");
app.UseCors("AllowAngularApp");
app.UseRouting();
//app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
app.UseAuthorization();
app.MapControllers();

app.Run();

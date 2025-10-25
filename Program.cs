using mayorista_el_brujo.Models;
using mayorista_el_brujo.Services;
using mayorista_el_brujo.Repositorios;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddControllersWithViews();

//AUTENTICACION: Verifica quién eres. Es el proceso de identificar a un usuario o cliente que quiere acceder a tu aplicación.
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>//el sitio web valida con cookie
    {
        options.LoginPath = "/Auth/Login";
        options.LogoutPath = "/Auth/Logout";
        options.AccessDeniedPath = "/Home/Restringido";
        //options.ExpireTimeSpan = TimeSpan.FromMinutes(5);//Tiempo de expiración
    })
    .AddJwtBearer(options =>//la api web valida con token
    {
        var secreto = configuration["TokenAuthentication:SecretKey"];
        if (string.IsNullOrEmpty(secreto))
            throw new Exception("Falta configurar TokenAuthentication:Secret");
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["TokenAuthentication:Issuer"],
            ValidAudience = configuration["TokenAuthentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.ASCII.GetBytes(secreto)),
        };
        // opción extra para usar el token en el hub y otras peticiones sin encabezado (enlaces, src de img, etc.)
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                // Leer el token desde el query string
                var accessToken = context.Request.Query["access_token"];
                // Si el request es para el Hub u otra ruta seleccionada...
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/chatsegurohub") ||
                    path.StartsWithSegments("/api/propietarios/reset") ||
                    path.StartsWithSegments("/api/propietarios/token")))
                {//reemplazar las urls por las necesarias ruta ⬆
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                // Este evento se activa cuando el token es validado correctamente
                Console.WriteLine("Token válido para el usuario: " + context?.Principal?.Identity?.Name);
                // Aquí puedes realizar otras validaciones o acciones si es necesario
                return Task.CompletedTask;
            },
            OnAuthenticationFailed = context =>
            {
                // Este evento se activa cuando la autenticación falla
                Console.WriteLine("Error en la autenticación del token: " + context.Exception.Message);
                return Task.CompletedTask;
            }
        };
    });

//AUTORIZACION: Verifica qué puedes hacer. Una vez que sabemos quién eres, la autorización decide a qué recursos o acciones tienes acceso.
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminOnly", policy => policy.RequireRole("admin"));
    options.AddPolicy("UserOrAdmin", policy => policy.RequireRole("empleado", "admin"));
    options.AddPolicy("RequireAuthentication", policy => policy.RequireAuthenticatedUser());
});

//DataContex para MySQL usando Pomelo EFCore
var connectionString = builder.Configuration.GetConnectionString("MySqlLocal");
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);

builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();

builder.Services.AddScoped<AuthService, AuthServiceImpl>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

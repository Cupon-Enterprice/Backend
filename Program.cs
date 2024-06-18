using Backend.Data;
using Backend.Services.Admins;
using Backend.Services.Cupones;
using Backend.Services.Redenciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Backend.Services.Mailsender;
using Backend.Services.Slack;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
//using Backend.Services.Midleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Configuration.AddJsonFile("appsettings.json");

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnetion"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddScoped<ICuponesRepository, CuponesRepository>();
builder.Services.AddScoped<IAdminsRepository, AdminsRepository>();
builder.Services.AddScoped<ICuponesRedencionRepository, CuponesRedencionRepository>();
builder.Services.AddScoped<CuponService>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IMailSenderServices, MailSenderServices>();
builder.Services.AddSingleton<ISlackService, SlackService>();

// Registrar ISlackNotificationService como Transient


builder.Services.AddHttpClient(); // Registra el servicio HttpClient en el contenedor de dependencias

builder.Services.AddCors(options =>
    options.AddPolicy("politica", service => { service.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

string key = "a!D3f7kL8Mn2Pq4R6tVzX9wB1GhJkZ2Y";
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var signInKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidIssuer = "https://localhost:5025",
        ValidAudience = "https://localhost:5025",
        IssuerSigningKey = signInKey,
    };
});




var app = builder.Build();




app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Agregar el middleware de manejo de excepciones personalizado
//app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("politica");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

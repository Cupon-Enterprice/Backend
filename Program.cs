using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();



builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("MySqlConnetion"),
    Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.20-mysql")));

builder.Services.AddScoped<ICuponesRepository, CuponesRepository>();
builder.Services.AddScoped<IAdminsRepository, AdminsRepository>();
builder.Services.AddScoped<ICuponesRedencionRepository, CuponesRedencionRepository>();
builder.Services.AddScoped<CuponService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddCors(options =>
    options.AddPolicy("politica", service => { service.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader(); }));

string key = "a!D3f7kL8Mn2Pq4R6tVzX9wB1GhJkZ2Y";
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer(opt =>
{
    var siginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = true,
        ValidateIssuer = true,
        ValidIssuer = "https://localhost:5025",
        ValidAudience = "https://localhost:5025",
        IssuerSigningKey = siginKey,
    };
});

var app = builder.Build();

app.UseHttpsRedirection();



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("politica");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();

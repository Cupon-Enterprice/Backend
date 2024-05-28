using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer();
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

builder.Services.AddCors(options => 
options.AddPolicy("politica", service =>{ service.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();}));
var app = builder.Build();






// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "pagina de inicio");
app.MapGet("/login", () => "acesso concedido").
RequireAuthorization();

app.UseHttpsRedirection();




app.UseCors("politica");
app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();

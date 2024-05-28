using Backend.Data;
using Backend.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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

builder.Services.AddCors(options => 
options.AddPolicy("politica", service =>{ service.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();}));
string key = "a!D3f7kL8Mn2Pq4R6tVzX9wB1GhJkZ2Y";

builder.Services.AddAuthorization();
builder.Services.AddAuthentication("Bearer").AddJwtBearer( opt =>{
var siginKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
var sigingcredentials =  new SigningCredentials(siginKey, SecurityAlgorithms.HmacSha256Signature);
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateAudience = false,
        ValidateIssuer = false,
        IssuerSigningKey = siginKey,
    };
});
var app = builder.Build();

app.MapGet("/auth/{user}/{pass}", (string user, string pass) =>
{
    if( user == "deklan" && pass == "123")
    {
        var tokenhandler = new JwtSecurityTokenHandler();
        var bytekey = Encoding.UTF8.GetBytes(key);
        var tokenDes = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user),
            }),
            Expires = DateTime.UtcNow.AddMonths(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(bytekey),
                                                                                    SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenhandler.CreateToken(tokenDes);
        return tokenhandler.WriteToken(token);
    }
    else
    {
        return "usuario invalido";
    }
});

app.MapGet("/", () => "pagina de inicio");
app.MapGet("/login", () => "acesso concedido").
RequireAuthorization();


app.UseHttpsRedirection();





// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("politica");
app.UseRouting();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();



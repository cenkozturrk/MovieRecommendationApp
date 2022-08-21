global using MovieRecommendationApp.DataAccess.Context;
global using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Api.Configuration;
using FluentValidation.AspNetCore;
using MovieRecommendationApp.Business.Validators;
using MovieRecommendationApp.Business.Filters;
using MovieRecommendationApp.Business;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.JwtBearer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddServices();
builder.Services.AddBusinessServices();

builder.Services.AddControllers(options => options.Filters.Add<ValidationFilter>())
    .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<MovieValidator>())
    //Bundan sonra mevzut olanýn dýþýnda benim kendi yazacaðým filterleri devreye sok.(Mevcut olan doðrulama filtrelerini devre dýþý býrak.)
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
// Bu uygulamaya token üzerinden bir istek geliyorsa bu tokený doðrularken jwt oldugunu bil.
// Bu jwt yi dogrularken asagýda ki configurationlar üzerinden dogrula
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // Olusturulucak token degerini kimlerin/hangi originlerin/sitelerin kullanacagýný belirledigimiz degerdir.
            ValidateIssuer = true, // Olusturulucak token degerini kimin dagýttýgýný ifade edecegimiz alandýr
            ValidateLifetime = true, // Tokenýn süresini kontrol eden doðrulama.
            ValidateIssuerSigningKey = true, // Üretilecek token deðerinin uygulamamýza ait bir deðer olduðunu ifade eden security key verisinin dogrulamasýdýr.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            NameClaimType = ClaimTypes.Name //JWT üzerinde Name claimne kar??l?k gelen de?eri User.Identity.Name propertysinden elde edebiliriz.
        };
    }
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

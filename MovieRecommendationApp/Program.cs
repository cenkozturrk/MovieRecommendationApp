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
    //Bundan sonra mevzut olan�n d���nda benim kendi yazaca��m filterleri devreye sok.(Mevcut olan do�rulama filtrelerini devre d��� b�rak.)
    .ConfigureApiBehaviorOptions(options => options.SuppressModelStateInvalidFilter = true);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

 
// Bu uygulamaya token �zerinden bir istek geliyorsa bu token� do�rularken jwt oldugunu bil.
// Bu jwt yi dogrularken asag�da ki configurationlar �zerinden dogrula
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer("Admin", options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateAudience = true, // Olusturulucak token degerini kimlerin/hangi originlerin/sitelerin kullanacag�n� belirledigimiz degerdir.
            ValidateIssuer = true, // Olusturulucak token degerini kimin dag�tt�g�n� ifade edecegimiz aland�r
            ValidateLifetime = true, // Token�n s�resini kontrol eden do�rulama.
            ValidateIssuerSigningKey = true, // �retilecek token de�erinin uygulamam�za ait bir de�er oldu�unu ifade eden security key verisinin dogrulamas�d�r.

            ValidAudience = builder.Configuration["Token:Audience"],
            ValidIssuer = builder.Configuration["Token:Issuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Token:SecurityKey"])),
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,

            NameClaimType = ClaimTypes.Name //JWT �zerinde Name claimne kar??l?k gelen de?eri User.Identity.Name propertysinden elde edebiliriz.
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

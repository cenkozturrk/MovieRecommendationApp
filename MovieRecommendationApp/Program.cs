global using MovieRecommendationApp.DataAccess.Context;
global using Microsoft.EntityFrameworkCore;
using MovieRecommendationApp.Api.Configuration;
using FluentValidation.AspNetCore;
using MovieRecommendationApp.Business.Validators;
using MovieRecommendationApp.Business.Filters;
using MovieRecommendationApp.Business;

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

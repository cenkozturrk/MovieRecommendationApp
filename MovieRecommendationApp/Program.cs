global using Microsoft.EntityFrameworkCore;
global using MovieRecommendationApp.DataAccess.Context;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.IdentityModel.Tokens;
using MovieRecommendationApp.Api.Configuration;
using MovieRecommendationApp.Business;
using MovieRecommendationApp.Business.Filters;
using MovieRecommendationApp.Business.Validators;
using Serilog;
using Serilog.Core;
using System.Security.Claims;
using System.Text;

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


Logger log = new LoggerConfiguration() // Instance olusturdum.
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
 //.WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("Mssql"), "logs", 
    //    needAutoCreateTable: true,
    //    columnOptions: new Dictionary<string, ColumnWriterBase>
    //    {
    //        {"message", new RenderedMessageColumnWriter(NpgsqlDbType.Text)},
    //        {"message_template", new MessageTemplateColumnWriter(NpgsqlDbType.Text)},
    //        {"level", new LevelColumnWriter(true , NpgsqlDbType.Varchar)},
    //        {"time_stamp", new TimestampColumnWriter(NpgsqlDbType.Timestamp)},
    //        {"exception", new ExceptionColumnWriter(NpgsqlDbType.Text)},
    //        {"log_event", new LogEventSerializedColumnWriter(NpgsqlDbType.Json)},
    //        {"user_name", new UsernameColumnWriter()}
    //    })
    .MinimumLevel.Information() // Information uzerýnden loglarý tut.


    .CreateLogger();         // Bu fonskyonu cagýrdýgým da arada verdigim configleri olusturucak 

builder.Host.UseSerilog(log); // Serilogu kullanacagýmý söyledim. Configuration olarakta log'a atanan yani referansý olan al kullan.

builder.Services.AddHttpLogging(logging => //Microsoftun sitesinde http logging makalesinden alýp kullandým. Geniþ çaplý bir log servisi.

{
    logging.LoggingFields = HttpLoggingFields.All;
    logging.RequestHeaders.Add("sec-ch-ua");
    logging.MediaTypeOptions.AddText("application/javascript");
    logging.RequestBodyLogLimit = 4096;
    logging.ResponseBodyLogLimit = 4096;

});

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
            LifetimeValidator = (notBefore, expires, securityToken, validationParameters) => expires != null ? expires > DateTime.UtcNow : false,//saniyesi saniyesine
            //jwt yi gecerli kýlýcak kýsým. 

           /* NameClaimType = ClaimTypes.Name*/ 
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

app.UseSerilogRequestLogging();  // kendisinden once ki middleware larý loglatmaz. Sonrakileri okur.

app.UseHttpLogging(); // yapýlan requestleri de log mekanizmasý sayesinde rahatlýkla yakalayabiliriz.

//app.UseCors(); belki bir gün kullanýrým.
app.UseHttpsRedirection();   

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

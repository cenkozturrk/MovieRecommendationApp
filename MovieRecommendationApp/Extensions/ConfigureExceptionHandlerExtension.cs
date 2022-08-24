using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Net.Mime;
using System.Text.Json;

namespace MovieRecommendationApp.Api.Extensions
{
    static public class ConfigureExceptionHandlerExtension
    {
        static public void ConfigureExpentionHandler<T>(this WebApplication application, ILogger<T> logger)
        {
            // Hataların meydana gelmesi neticesin de tetiklenecek olan middleware.
            application.UseExceptionHandler(builder =>
            {
                // Uygulamanın herhangi bir noktasın da hata meydana geldiğin de bu alan da gerekli çalışmaları yapabileceğim.
                builder.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = MediaTypeNames.Application.Json; // MediaTypnames hangi türe dönüştürmek istiyorsak basitçe verebiliyoruz.

                    // Meydana gelicek hata ile bilgilendirmeyi getirecek olan kısım.
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null)
                    {
                        logger.LogError(contextFeature.Error.Message);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(new
                        {
                            StatucCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message,
                            Title = " Error received "
                        })); ;
                    }


                });
            });
        }
    }
}

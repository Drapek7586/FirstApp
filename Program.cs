//
//  APLIKACJA  ZORTAX
//     REAL TIME NBP API READER 
//     FRONTEND : ANGULAR
//    BACKEND :  C# 
//

using RealTimeAPIReader.HubConfig;
using RealTimeAPIReader.TimerFeatures;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", builder => builder
        .WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials());
});


builder.Services.AddSignalR();
builder.Services.AddSingleton<TimerManager>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();
app.MapHub<ChartHub>("/chart");
app.MapHub<ApiHub>("/api");

app.Run();

using Gateway.API.BackgroundServices;
using Gateway.API.Extensions;
using Gateway.API.Hubs;
using Gateway.API.Services.Abstract;
using Gateway.API.Services.Concrete;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSingleton<IRedisService, RedisService>();

var multiplexer = ConnectionMultiplexer.Connect(builder.Configuration.GetConnectionString("RedisConnection"));
builder.Services.AddSingleton<IConnectionMultiplexer>(multiplexer);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Gateway", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                 {
                   new OpenApiSecurityScheme
                   {
                     Reference = new OpenApiReference
                     {
                       Type = ReferenceType.SecurityScheme,
                       Id = "Bearer"
                     }
                    },
                    new string[] { }
                  }
                });
});
builder.Services.AddSignalR();
builder.Services.AddHostedService<DeliveryTrackService>();
builder.Jwt();
builder.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapHub<TrackHub>("/trackhub");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.Run();

using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using OrderDelivery.Core.Interfaces.Repositories.BaseRepo;
using OrderDelivery.Data.AppDbContext;
using OrderDelivery.Data.Repositories.Base;
using OrderDeliveryService.API.Extensions;
using OrderDeliveryService.API.Middlewares;
using OrderDelivery.Core.Interfaces.Repositories;
using OrderDelivery.Data.Repositories;
using OrderDelivery.Core.Interfaces.UnitOfWork;
using OrderDelivery.Infrastructure.Responses;
using OrderDelivery.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ParcelDeliveryDb>(options =>
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);


builder.Services.AddAutoMapper(typeof(CreateOrderResponse).Assembly);
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderResponse).Assembly));

builder.Services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
builder.Services.AddScoped<IDeliveryRepo, DeliveryRepo>();
builder.Services.AddScoped<IOrderRepo, OrderRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateOrderResponse).Assembly));



builder.Services.AddControllers()
    .AddFluentValidation(options =>
    {
        
        options.ImplicitlyValidateChildProperties = true;
        options.ImplicitlyValidateRootCollectionElements = true;
        options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    });
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Jwt();
builder.AddCors();

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
app.UseMiddleware(typeof(ExceptionHandlerMiddleware));
app.UseCors("AllowAll");
app.MapControllers();

app.Run();

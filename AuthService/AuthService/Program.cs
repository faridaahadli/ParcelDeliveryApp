using Auth.API.Extensions;
using Auth.Data.AppDbContext;
using AutoMapper;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using FluentValidation.AspNetCore;
using Auth.Core.Interfaces.Repositories;
using Auth.Data.Repositories;
using Auth.Core.Interfaces.BaseRepo;
using Auth.Data.Repositories.BaseRepo;
using Auth.API.Middlewares;
using MediatR;
using Auth.Infrastructure.Commands;
using Microsoft.Extensions.DependencyInjection;
using Auth.Infrastructure;
using Auth.Core.Entities;
using Auth.Infrastructure.Responses;
using Auth.Core.Interfaces.Jwt;
using Auth.Infrastructure.Services;
using Auth.Core.Interfaces.UnitOfWork;
using Auth.Data.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DeliveryAuthDb>(options =>
    options
    .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);



builder.Services.AddAutoMapper(typeof(CreateUserResponse).Assembly);


builder.Services.AddScoped(typeof(IBaseRepo<>),typeof(BaseRepo<>));
builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IJwtManager, JwtManager>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserResponse).Assembly));

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

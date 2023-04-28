﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace OrderDeliveryService.API.Extensions
{
    public static class ProgramExtension
    {
        public static void Jwt(this WebApplicationBuilder builder)
        {
            var configuration = builder.Configuration;
            builder.Services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["Jwt:Key"]))
                };
            });
        }

        public static void AddCors(this WebApplicationBuilder builder)
        {
            builder.Services.AddCors(opt =>
               opt.AddPolicy("AllowAll",
               opt => {
                   opt.AllowAnyMethod();
                   opt.AllowAnyHeader();
                   opt.AllowAnyOrigin();
               }));
        }
    }
}

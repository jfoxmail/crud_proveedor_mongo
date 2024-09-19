using AutoMapper;
using EmpleosTemporales.Proveedores.Application.Configuration;
using EmpleosTemporales.Proveedores.Application.DataBase;
using EmpleosTemporales.Proveedores.Application.Interfaces;
using EmpleosTemporales.Proveedores.Application.Jwt;
using EmpleosTemporales.Proveedores.Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpleosTemporales.Proveedores.Application
{
    public static class DependencyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });
            services.AddSingleton (mapper.CreateMapper());
            services.AddSingleton<MongoDbService>();
            services.AddTransient<IProveedorService, ProveedoresService>();
            services.AddTransient<IGetTokenJwtService, GetTokenJwtService>();
            
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(option => {
                option.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"])),
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"]


                };
            });
            return services;
        }

    }
}


using AutoMapper;
using HotelReservation.API.Common;
using HotelReservation.API.Middleware;
using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.Contracts.Security;
using HotelReservation.Application.Contracts.Validation;
using HotelReservation.Application.UseCases.AppHotel;
using HotelReservation.Application.UseCases.AppUser;
using HotelReservation.Application.UseCases.AppUser.Mapping;
using HotelReservation.Application.UseCases.AppUserGroup;
using HotelReservation.Domain.Repository.DataManagement;
using HotelReservation.Infrastructure.Persistence.EFCore.Context;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;
using HotelReservation.Infrastructure.Security;
using HotelReservation.Infrastructure.Validation;
using Microsoft.AspNetCore.SignalR;

namespace HotelReservation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //DI Life Time Cycle 
            //Scoped, Transient, singleton

            builder.Services.AddControllers()
                .AddJsonOptions(opt => opt.JsonSerializerOptions.PropertyNamingPolicy = null);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HotelReservationAPIContext>();
            builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            builder.Services.AddScoped<IUserService,UserManager>();
            builder.Services.AddScoped<IHotelService,HotelManager>();
            builder.Services.AddScoped<IUserGroupService,UserGroupManager>();
            builder.Services.AddScoped<IGenericValidator,FluentValidator>();
            
            builder.Services.AddScoped<ITokenService,TokenService>();
            builder.Services.Configure<JWTExceptURLList>(builder.Configuration.GetSection(nameof(JWTExceptURLList)));

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            var app = builder.Build();
            app.UseGlobalExceptionHandlerMiddleware();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseApiAuthorizationMiddleware();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

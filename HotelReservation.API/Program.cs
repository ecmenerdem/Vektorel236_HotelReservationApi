
using AutoMapper;
using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.Contracts.Validation;
using HotelReservation.Application.UseCases.AppUser;
using HotelReservation.Application.UseCases.AppUser.Mapping;
using HotelReservation.Domain.Repository.DataManagement;
using HotelReservation.Infrastructure.Persistence.EFCore.Context;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;
using HotelReservation.Infrastructure.Validation;

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
            builder.Services.AddScoped<IGenericValidator,FluentValidator>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}


using HotelReservation.Application.Contracts.Persistence;
using HotelReservation.Application.UseCases.AppUser;
using HotelReservation.Domain.Repository.DataManagement;
using HotelReservation.Infrastructure.Persistence.EFCore.Context;
using HotelReservation.Infrastructure.Persistence.Repository.EntityFrameworkCore.DataManagement;

namespace HotelReservation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<HotelReservationAPIContext>();
            builder.Services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            builder.Services.AddScoped<IUserService,UserManager>();

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

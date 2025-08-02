using Web.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Web.Business.Mapping;
using Web.Business.Interfaces;
using Web.Business.Services;
using Web.Domain.Interfaces;
using Web.Infrastructure.Repositories;

namespace Web.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<BBDDContext>(options =>
                options.UseInMemoryDatabase("DataBase"));

            builder.Services.AddScoped<IContractRepository, ContractRepository>();
            builder.Services.AddScoped<IContractService, ContractService>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAutoMapper(options => {
                options.AddProfiles(MapperHelper.SettingUp());
            });

            var app = builder.Build();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseDefaultFiles();
            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.MapFallbackToFile("/index.html");

            app.Run();
        }
    }
}

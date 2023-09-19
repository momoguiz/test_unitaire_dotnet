using DemoTU.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace DemoTU
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<AnnuaireContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Cours")));
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "API Annuaire des élèves",
                    Description = "API permettant de récupérer les informations d'annuaire des élèves.",
                    Contact = new OpenApiContact
                    {
                        Name = "Christophe ASJEME",
                        Email = "contact@email.fr"
                    }
                });

                string xmlPath = Path.Combine(AppContext.BaseDirectory, "Swagger.xml");
                c.IncludeXmlComments(xmlPath);
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Démo API");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
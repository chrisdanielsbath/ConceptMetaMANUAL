/****************************
 * Program.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ConceptMeta.ConceptMetaDb.DomainWebApi
{
    /// <summary>
    /// Program class for the ConceptMeta Web Api
    /// </summary>
    public partial class Program
    {

        #region Static Methods

        /// <summary>
        /// Main Method - Entry Point to the Web Api
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                // Use the default property (Pascal) casing.
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
                options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // register the DomainUnitOfWork and its dependencies (BlueprintUnitOfWork, DbUnitOfWork and DbContext)
            builder.Services.AddDbContext<ConceptMetaDbContext>();
            builder.Services.AddScoped<IConceptMetaDbUnitOfWork, ConceptMetaDbUnitOfWork>();
            builder.Services.AddScoped<IConceptMetaDbBlueprintUnitOfWork, ConceptMetaDbBlueprintUnitOfWork>();
            builder.Services.AddScoped<IConceptMetaDbDomainUnitOfWork, ConceptMetaDbDomainUnitOfWork>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

        #endregion
    }
}

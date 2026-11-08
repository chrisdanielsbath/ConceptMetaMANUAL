/****************************
 * Program.Auto.cs
 ****************************/
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.OData;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.OData
{
    /// <summary>
    /// Program class for the ConceptMeta OData Web Api
    /// </summary>
    public partial class Program
    {

        #region Static Methods

        /// <summary>
        /// Main Method - Entry Point to the OData Web Api
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                    .AddOData(options => options
                            .Select()
                            .Filter()
                            .OrderBy())
                    .AddOData(options => options
                            .EnableQueryFeatures()
                            .AddRouteComponents("odata", GetEdmModel()))
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNamingPolicy = null; // to achieve PascalCasing in output
                    });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<ConceptMetaDbContext>();

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

        /// <summary>
        /// This method returns the Entity Data Model.
        /// We have chosen to create all Keys here rather than through annotations.
        /// </summary>
        /// <returns></returns>
        private static IEdmModel GetEdmModel()
        {
            var builder = new ODataConventionModelBuilder();

            // Concepts
            var conceptsEntitySet = builder.EntitySet<Concept>("Concepts");
            conceptsEntitySet.EntityType
                    .HasKey(concept => concept.ConceptId);

            // ConceptModels
            var conceptModelsEntitySet = builder.EntitySet<ConceptModel>("ConceptModels");
            conceptModelsEntitySet.EntityType
                    .HasKey(conceptModel => conceptModel.ConceptModelId);

            // ConceptPropertyFamilies
            var conceptPropertyFamiliesEntitySet = builder.EntitySet<ConceptPropertyFamily>("ConceptPropertyFamilies");
            conceptPropertyFamiliesEntitySet.EntityType
                    .HasKey(conceptPropertyFamily => conceptPropertyFamily.ConceptPropertyFamilyId);

            // ConceptRefs
            var conceptRefsEntitySet = builder.EntitySet<ConceptRef>("ConceptRefs");
            conceptRefsEntitySet.EntityType
                    .HasKey(conceptRef => conceptRef.ConceptRefId);

            // ConceptSubTypes
            var conceptSubTypesEntitySet = builder.EntitySet<ConceptSubType>("ConceptSubTypes");
            conceptSubTypesEntitySet.EntityType
                    .HasKey(conceptSubType => conceptSubType.ConceptSubTypeId);

            // ConceptSubTypePropertyFamilyRefs
            var conceptSubTypePropertyFamilyRefsEntitySet = builder.EntitySet<ConceptSubTypePropertyFamilyRef>("ConceptSubTypePropertyFamilyRefs");
            conceptSubTypePropertyFamilyRefsEntitySet.EntityType
                    .HasKey(conceptSubTypePropertyFamilyRef => conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId);

            // ConceptUniqueKeys
            var conceptUniqueKeysEntitySet = builder.EntitySet<ConceptUniqueKey>("ConceptUniqueKeys");
            conceptUniqueKeysEntitySet.EntityType
                    .HasKey(conceptUniqueKey => conceptUniqueKey.ConceptUniqueKeyId);

            // ConceptUniqueKeyPropertyFamilyRefs
            var conceptUniqueKeyPropertyFamilyRefsEntitySet = builder.EntitySet<ConceptUniqueKeyPropertyFamilyRef>("ConceptUniqueKeyPropertyFamilyRefs");
            conceptUniqueKeyPropertyFamilyRefsEntitySet.EntityType
                    .HasKey(conceptUniqueKeyPropertyFamilyRef => conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId);

            // DataTypes
            var dataTypesEntitySet = builder.EntitySet<DataType>("DataTypes");
            dataTypesEntitySet.EntityType
                    .HasKey(dataType => dataType.DataTypeId);

            // Enumerations
            var enumerationsEntitySet = builder.EntitySet<Enumeration>("Enumerations");
            enumerationsEntitySet.EntityType
                    .HasKey(enumeration => enumeration.EnumerationId);

            // EnumerationMembers
            var enumerationMembersEntitySet = builder.EntitySet<EnumerationMember>("EnumerationMembers");
            enumerationMembersEntitySet.EntityType
                    .HasKey(enumerationMember => enumerationMember.EnumerationMemberId);

            // Includes
            var includesEntitySet = builder.EntitySet<Include>("Includes");
            includesEntitySet.EntityType
                    .HasKey(include => include.IncludeId);

            // Qualifiers
            var qualifiersEntitySet = builder.EntitySet<Qualifier>("Qualifiers");
            qualifiersEntitySet.EntityType
                    .HasKey(qualifier => qualifier.QualifierId);

            return builder.GetEdmModel();
        }

        #endregion
    }
}

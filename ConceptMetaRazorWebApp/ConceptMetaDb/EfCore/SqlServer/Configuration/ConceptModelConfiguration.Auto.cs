/****************************
 * ConceptModelConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptModel>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptModel" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptModel> builder)
        {
            // configure ConceptModel class to map to ConceptModel table
            builder.ToTable("ConceptModel", "dbo");

            // configure primary key index PK_ConceptModel
            builder.HasKey(entity => entity.ConceptModelId)
                    .HasName("PK_ConceptModel");

            // configure ConceptModelId property (primary key field)
            builder.Property(entity => entity.ConceptModelId).IsRequired()
                    .HasColumnName("ConceptModelId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ModelName property
            builder.Property(entity => entity.ModelName).IsRequired(false)
                    .HasColumnName("ModelName")
                    .HasColumnType("nvarchar(200)");

            // configure DefaultStringLength property
            builder.Property(entity => entity.DefaultStringLength).IsRequired(false)
                    .HasColumnName("DefaultStringLength")
                    .HasColumnType("int");

            // configure alternate key index AK_ConceptModel_ModelName
            builder.HasIndex(entity => entity.ModelName)
                    .HasDatabaseName("AK_ConceptModel_ModelName")
                    .IsUnique();
        }

        #endregion
    }
}

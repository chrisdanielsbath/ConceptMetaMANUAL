/****************************
 * ConceptModelConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="DbEntities.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelConfiguration
        : IEntityTypeConfiguration<DbEntities.ConceptModel>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.ConceptModel" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.ConceptModel> builder)
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

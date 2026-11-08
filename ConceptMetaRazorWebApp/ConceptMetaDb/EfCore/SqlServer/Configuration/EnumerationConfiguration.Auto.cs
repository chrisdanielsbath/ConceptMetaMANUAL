/****************************
 * EnumerationConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.Enumeration" /> entity
    /// </summary>
    public partial class EnumerationConfiguration
        : IEntityTypeConfiguration<RazorModels.Enumeration>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.Enumeration" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.Enumeration> builder)
        {
            // configure Enumeration class to map to Enumeration table
            builder.ToTable("Enumeration", "dbo");

            // configure primary key index PK_Enumeration
            builder.HasKey(entity => entity.EnumerationId)
                    .HasName("PK_Enumeration");

            // configure EnumerationId property (primary key field)
            builder.Property(entity => entity.EnumerationId).IsRequired()
                    .HasColumnName("EnumerationId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptModelId property
            builder.Property(entity => entity.ConceptModelId).IsRequired()
                    .HasColumnName("ConceptModelId")
                    .HasColumnType("int");

            // configure EnumerationName property
            builder.Property(entity => entity.EnumerationName).IsRequired(false)
                    .HasColumnName("EnumerationName")
                    .HasColumnType("nvarchar(200)");

            // configure EnumerationDescription property
            builder.Property(entity => entity.EnumerationDescription).IsRequired(false)
                    .HasColumnName("EnumerationDescription")
                    .HasColumnType("nvarchar(500)");

            // configure DataTypeId property
            builder.Property(entity => entity.DataTypeId).IsRequired()
                    .HasColumnName("DataTypeId")
                    .HasColumnType("int");

            // configure relationship to ConceptModel (ConceptModel.Enumerations)
            builder.HasOne<RazorModels.ConceptModel>(entity => entity.ConceptModel)
                    .WithMany(referenced => referenced.Enumerations)
                    .HasForeignKey(entity => entity.ConceptModelId)
                    .HasConstraintName("FK_Enumeration_ConceptModelId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to DataType (Enumeration.DataType)
            builder.HasOne<RazorModels.DataType>(entity => entity.DataType)
                    .WithMany(referenced => referenced.Enumerations)
                    .HasForeignKey(entity => entity.DataTypeId)
                    .HasConstraintName("FK_Enumeration_DataTypeId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_Enumeration_ConceptModelId_EnumerationName
            builder.HasIndex(entity => new {entity.ConceptModelId, entity.EnumerationName})
                    .HasDatabaseName("AK_Enumeration_ConceptModelId_EnumerationName")
                    .IsUnique();
        }

        #endregion
    }
}

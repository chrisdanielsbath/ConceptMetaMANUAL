/****************************
 * ConceptSubTypeConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptSubType" /> entity
    /// </summary>
    public partial class ConceptSubTypeConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptSubType>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptSubType" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptSubType> builder)
        {
            // configure ConceptSubType class to map to ConceptSubType table
            builder.ToTable("ConceptSubType", "dbo");

            // configure primary key index PK_ConceptSubType
            builder.HasKey(entity => entity.ConceptSubTypeId)
                    .HasName("PK_ConceptSubType");

            // configure ConceptSubTypeId property (primary key field)
            builder.Property(entity => entity.ConceptSubTypeId).IsRequired()
                    .HasColumnName("ConceptSubTypeId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure SubTypeName property
            builder.Property(entity => entity.SubTypeName).IsRequired()
                    .HasColumnName("SubTypeName")
                    .HasColumnType("nvarchar(200)");

            // configure relationship to Concept (Concept.SubTypes)
            // linking to index PK4_ObjectConcept
            builder.HasOne<RazorModels.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.SubTypes)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptSubType_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptSubType_ConceptId_SubTypeName
            builder.HasIndex(entity => new {entity.ConceptId, entity.SubTypeName})
                    .HasDatabaseName("AK_ConceptSubType_ConceptId_SubTypeName")
                    .IsUnique();
        }

        #endregion
    }
}

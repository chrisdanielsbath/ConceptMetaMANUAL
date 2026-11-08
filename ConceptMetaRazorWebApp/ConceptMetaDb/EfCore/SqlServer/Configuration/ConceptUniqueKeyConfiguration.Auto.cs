/****************************
 * ConceptUniqueKeyConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptUniqueKey" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptUniqueKey>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptUniqueKey" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptUniqueKey> builder)
        {
            // configure ConceptUniqueKey class to map to ConceptUniqueKey table
            builder.ToTable("ConceptUniqueKey", "dbo");

            // configure primary key index PK_ConceptUniqueKey
            builder.HasKey(entity => entity.ConceptUniqueKeyId)
                    .HasName("PK_ConceptUniqueKey");

            // configure ConceptUniqueKeyId property (primary key field)
            builder.Property(entity => entity.ConceptUniqueKeyId).IsRequired()
                    .HasColumnName("ConceptUniqueKeyId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure UniqueKeyName property
            builder.Property(entity => entity.UniqueKeyName).IsRequired()
                    .HasColumnName("UniqueKeyName")
                    .HasColumnType("nvarchar(200)");

            // configure relationship to Concept (Concept.UniqueKeys)
            // linking to index PK4_ObjectConcept
            builder.HasOne<RazorModels.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.UniqueKeys)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptUniqueKey_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptUniqueKey_ConceptId_UniqueKeyName
            builder.HasIndex(entity => new {entity.ConceptId, entity.UniqueKeyName})
                    .HasDatabaseName("AK_ConceptUniqueKey_ConceptId_UniqueKeyName")
                    .IsUnique();
        }

        #endregion
    }
}

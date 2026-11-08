/****************************
 * IncludeConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="DbEntities.Include" /> entity
    /// </summary>
    public partial class IncludeConfiguration
        : IEntityTypeConfiguration<DbEntities.Include>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.Include" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.Include> builder)
        {
            // configure Include class to map to Include table
            builder.ToTable("Include", "dbo");

            // configure primary key index PK_Include
            builder.HasKey(entity => entity.IncludeId)
                    .HasName("PK_Include");

            // configure IncludeId property (primary key field)
            builder.Property(entity => entity.IncludeId).IsRequired()
                    .HasColumnName("IncludeId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure ItemValue property
            builder.Property(entity => entity.ItemValue).IsRequired(false)
                    .HasColumnName("ItemValue")
                    .HasColumnType("nvarchar(200)");

            // configure SeqNo property
            builder.Property(entity => entity.SeqNo).IsRequired()
                    .HasColumnName("SeqNo")
                    .HasColumnType("int");

            // configure relationship to Concept (Concept.Includes)
            // linking to index PK4_ObjectConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.Includes)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_Include_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_Include_ConceptId_ItemValue
            builder.HasIndex(entity => new {entity.ConceptId, entity.ItemValue})
                    .HasDatabaseName("AK_Include_ConceptId_ItemValue")
                    .IsUnique();
        }

        #endregion
    }
}

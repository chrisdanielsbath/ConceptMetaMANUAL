/****************************
 * ConceptPropertyFamilyConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptPropertyFamily" /> entity
    /// </summary>
    public partial class ConceptPropertyFamilyConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptPropertyFamily>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptPropertyFamily" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptPropertyFamily> builder)
        {
            // configure ConceptPropertyFamily class to map to ConceptPropertyFamily table
            builder.ToTable("ConceptPropertyFamily", "dbo");

            // configure primary key index PK_ConceptPropertyFamily
            builder.HasKey(entity => entity.ConceptPropertyFamilyId)
                    .HasName("PK_ConceptPropertyFamily");

            // configure ConceptPropertyFamilyId property (primary key field)
            builder.Property(entity => entity.ConceptPropertyFamilyId).IsRequired()
                    .HasColumnName("ConceptPropertyFamilyId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure PropertyFamilyName property
            builder.Property(entity => entity.PropertyFamilyName).IsRequired()
                    .HasColumnName("PropertyFamilyName")
                    .HasColumnType("nvarchar(200)");

            // configure SeqNo property
            builder.Property(entity => entity.SeqNo).IsRequired()
                    .HasColumnName("SeqNo")
                    .HasColumnType("int");

            // configure relationship to Concept (Concept.PropertyFamilies)
            // linking to index PK4_ObjectConcept
            builder.HasOne<RazorModels.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.PropertyFamilies)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptPropertyFamily_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptPropertyFamily_ConceptId_PropertyFamilyName
            builder.HasIndex(entity => new {entity.ConceptId, entity.PropertyFamilyName})
                    .HasDatabaseName("AK_ConceptPropertyFamily_ConceptId_PropertyFamilyName")
                    .IsUnique();
        }

        #endregion
    }
}

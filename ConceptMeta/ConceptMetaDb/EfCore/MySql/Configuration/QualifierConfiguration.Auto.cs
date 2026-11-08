/****************************
 * QualifierConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration
{
    /// <summary>
    /// EF Core MySql Configuration class for the <see cref="DbEntities.Qualifier" /> entity
    /// </summary>
    public partial class QualifierConfiguration
        : IEntityTypeConfiguration<DbEntities.Qualifier>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.Qualifier" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.Qualifier> builder)
        {
            // configure Qualifier class to map to Qualifier table
            builder.ToTable("Qualifier", "dbo");

            // configure primary key index PK_Qualifier
            builder.HasKey(entity => entity.QualifierId)
                    .HasName("PK_Qualifier");

            // configure QualifierId property (primary key field)
            builder.Property(entity => entity.QualifierId).IsRequired()
                    .HasColumnName("QualifierId")
                    .HasColumnType("int")
                    .UseMySQLAutoIncrementColumn("int");

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure ItemValue property
            builder.Property(entity => entity.ItemValue).IsRequired()
                    .HasColumnName("ItemValue")
                    .HasColumnType("varchar(200)");

            // configure SeqNo property
            builder.Property(entity => entity.SeqNo).IsRequired()
                    .HasColumnName("SeqNo")
                    .HasColumnType("int");

            // configure relationship to Concept (Concept.Qualifiers)
            // linking to index PK4_ObjectConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.Qualifiers)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_Qualifier_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_Qualifier_ConceptId_ItemValue
            builder.HasIndex(entity => new {entity.ConceptId, entity.ItemValue})
                    .HasDatabaseName("AK_Qualifier_ConceptId_ItemValue")
                    .IsUnique();
        }

        #endregion
    }
}

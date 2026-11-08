/****************************
 * ConceptConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration
{
    /// <summary>
    /// EF Core MySql Configuration class for the <see cref="DbEntities.Concept" /> entity
    /// </summary>
    public partial class ConceptConfiguration
        : IEntityTypeConfiguration<DbEntities.Concept>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.Concept" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.Concept> builder)
        {
            // configure Concept class to map to Concept table
            builder.ToTable("Concept", "dbo");

            // configure primary key index PK_Concept
            builder.HasKey(entity => entity.ConceptId)
                    .HasName("PK_Concept");

            // configure ConceptId property (primary key field)
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int")
                    .UseMySQLAutoIncrementColumn("int");

            // configure ConceptModelId property
            builder.Property(entity => entity.ConceptModelId).IsRequired()
                    .HasColumnName("ConceptModelId")
                    .HasColumnType("int");

            // configure ConceptName property
            builder.Property(entity => entity.ConceptName).IsRequired()
                    .HasColumnName("ConceptName")
                    .HasColumnType("varchar(200)");

            // configure ConceptDescription property
            builder.Property(entity => entity.ConceptDescription).IsRequired(false)
                    .HasColumnName("ConceptDescription")
                    .HasColumnType("varchar(500)");

            // configure ConceptType property
            builder.Property(entity => entity.ConceptType).IsRequired()
                    .HasColumnName("ConceptType")
                    .HasColumnType("varchar");

            // configure DataTypeId property
            builder.Property(entity => entity.DataTypeId).IsRequired(false)
                    .HasColumnName("DataTypeId")
                    .HasColumnType("int");

            // configure EnumerationId property
            builder.Property(entity => entity.EnumerationId).IsRequired(false)
                    .HasColumnName("EnumerationId")
                    .HasColumnType("int");

            // configure BasedOnConceptId property
            builder.Property(entity => entity.BasedOnConceptId).IsRequired(false)
                    .HasColumnName("BasedOnConceptId")
                    .HasColumnType("int");

            // configure ExampleValueAsString property
            builder.Property(entity => entity.ExampleValueAsString).IsRequired(false)
                    .HasColumnName("ExampleValueAsString")
                    .HasColumnType("varchar(200)");

            // configure MinLength property
            builder.Property(entity => entity.MinLength).IsRequired(false)
                    .HasColumnName("MinLength")
                    .HasColumnType("int");

            // configure MaxLength property
            builder.Property(entity => entity.MaxLength).IsRequired(false)
                    .HasColumnName("MaxLength")
                    .HasColumnType("int");

            // configure MinValue property
            builder.Property(entity => entity.MinValue).IsRequired(false)
                    .HasColumnName("MinValue")
                    .HasColumnType("decimal(18, 3)");

            // configure MaxValue property
            builder.Property(entity => entity.MaxValue).IsRequired(false)
                    .HasColumnName("MaxValue")
                    .HasColumnType("decimal(18, 3)");

            // configure TotalDigits property
            builder.Property(entity => entity.TotalDigits).IsRequired(false)
                    .HasColumnName("TotalDigits")
                    .HasColumnType("int");

            // configure DecimalPlaces property
            builder.Property(entity => entity.DecimalPlaces).IsRequired(false)
                    .HasColumnName("DecimalPlaces")
                    .HasColumnType("int");

            // configure DatePrecision property
            builder.Property(entity => entity.DatePrecision).IsRequired(false)
                    .HasColumnName("DatePrecision")
                    .HasColumnType("int");

            // configure DbSchemaName property
            builder.Property(entity => entity.DbSchemaName).IsRequired(false)
                    .HasColumnName("DbSchemaName")
                    .HasColumnType("varchar(200)");

            // configure DbTableName property
            builder.Property(entity => entity.DbTableName).IsRequired(false)
                    .HasColumnName("DbTableName")
                    .HasColumnType("varchar(200)");

            // configure IsCollectionItem property
            builder.Property(entity => entity.IsCollectionItem).IsRequired(false)
                    .HasColumnName("IsCollectionItem")
                    .HasColumnType("bool");

            // configure ToStringExpression property
            builder.Property(entity => entity.ToStringExpression).IsRequired(false)
                    .HasColumnName("ToStringExpression")
                    .HasColumnType("varchar(200)");

            // configure IsCreatable property
            builder.Property(entity => entity.IsCreatable).IsRequired(false)
                    .HasColumnName("IsCreatable")
                    .HasColumnType("bool");

            // configure IsUpdatable property
            builder.Property(entity => entity.IsUpdatable).IsRequired(false)
                    .HasColumnName("IsUpdatable")
                    .HasColumnType("bool");

            // configure IsDeletable property
            builder.Property(entity => entity.IsDeletable).IsRequired(false)
                    .HasColumnName("IsDeletable")
                    .HasColumnType("bool");

            // configure SurrogateKeyFieldName property
            builder.Property(entity => entity.SurrogateKeyFieldName).IsRequired(false)
                    .HasColumnName("SurrogateKeyFieldName")
                    .HasColumnType("varchar(200)");

            // configure PrimaryKeyName property
            builder.Property(entity => entity.PrimaryKeyName).IsRequired(false)
                    .HasColumnName("PrimaryKeyName")
                    .HasColumnType("varchar(200)");

            // configure AlternateKeyName property
            builder.Property(entity => entity.AlternateKeyName).IsRequired(false)
                    .HasColumnName("AlternateKeyName")
                    .HasColumnType("varchar(200)");

            // configure ReferencedConceptId property
            builder.Property(entity => entity.ReferencedConceptId).IsRequired(false)
                    .HasColumnName("ReferencedConceptId")
                    .HasColumnType("int");

            // configure ReferencedConceptUniqueKeyId property
            builder.Property(entity => entity.ReferencedConceptUniqueKeyId).IsRequired(false)
                    .HasColumnName("ReferencedConceptUniqueKeyId")
                    .HasColumnType("int");

            // configure SpecialisedConceptId property
            builder.Property(entity => entity.SpecialisedConceptId).IsRequired(false)
                    .HasColumnName("SpecialisedConceptId")
                    .HasColumnType("int");

            // configure SpecialisedConceptSubTypeId property
            builder.Property(entity => entity.SpecialisedConceptSubTypeId).IsRequired(false)
                    .HasColumnName("SpecialisedConceptSubTypeId")
                    .HasColumnType("int");

            // configure relationship to ConceptModel (ConceptModel.Concepts)
            builder.HasOne<DbEntities.ConceptModel>(entity => entity.ConceptModel)
                    .WithMany(referenced => referenced.Concepts)
                    .HasForeignKey(entity => entity.ConceptModelId)
                    .HasConstraintName("FK_Concept_ConceptModelId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to DataType (Concept.DataType)
            builder.HasOne<DbEntities.DataType>(entity => entity.DataType)
                    .WithMany(referenced => referenced.Concepts)
                    .HasForeignKey(entity => entity.DataTypeId)
                    .HasConstraintName("FK_Concept_DataTypeId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to Enumeration (Concept.Enumeration)
            builder.HasOne<DbEntities.Enumeration>(entity => entity.Enumeration)
                    .WithMany(referenced => referenced.Concepts)
                    .HasForeignKey(entity => entity.EnumerationId)
                    .HasConstraintName("FK_Concept_EnumerationId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to BasedOnConcept (Concept.BasedOnConcept)
            // linking to index PK3_ScalarConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.BasedOnConcept)
                    .WithMany(referenced => referenced.DerivedConcepts)
                    .HasForeignKey(entity => entity.BasedOnConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_Concept_BasedOnConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ReferencedConcept (Concept.ReferencedConcept)
            // linking to index PK5_UniqueKeyConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.ReferencedConcept)
                    .WithMany(referenced => referenced.ReferencedByConcepts)
                    .HasForeignKey(entity => entity.ReferencedConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_Concept_ReferencedConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ReferencedUniqueKey (Concept.ReferencedUniqueKey)
            builder.HasOne<DbEntities.ConceptUniqueKey>(entity => entity.ReferencedUniqueKey)
                    .WithMany(referenced => referenced.UniqueKeyRefs)
                    .HasForeignKey(entity => entity.ReferencedConceptUniqueKeyId)
                    .HasConstraintName("FK_Concept_ReferencedConceptUniqueKeyId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to SpecialisedConcept (Concept.SpecialisedConcept)
            // linking to index PK6_SubTypeConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.SpecialisedConcept)
                    .WithMany(referenced => referenced.SpecialisedByConcepts)
                    .HasForeignKey(entity => entity.SpecialisedConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_Concept_SpecialisedConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to SpecialisedSubType (Concept.SpecialisedSubType)
            builder.HasOne<DbEntities.ConceptSubType>(entity => entity.SpecialisedSubType)
                    .WithMany(referenced => referenced.SubTypeRefs)
                    .HasForeignKey(entity => entity.SpecialisedConceptSubTypeId)
                    .HasConstraintName("FK_Concept_SpecialisedConceptSubTypeId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_Concept_ConceptModelId_ConceptName
            builder.HasIndex(entity => new {entity.ConceptModelId, entity.ConceptName})
                    .HasDatabaseName("AK_Concept_ConceptModelId_ConceptName")
                    .IsUnique();

            // configure alternate key index PK2_CommonConcept
            builder.HasIndex(entity => entity.ConceptId)
                    .HasDatabaseName("PK2_CommonConcept")
                    .IsUnique();

            // configure alternate key index PK3_ScalarConcept
            builder.HasIndex(entity => entity.ConceptId)
                    .HasDatabaseName("PK3_ScalarConcept")
                    .IsUnique();

            // configure alternate key index PK4_ObjectConcept
            builder.HasIndex(entity => entity.ConceptId)
                    .HasDatabaseName("PK4_ObjectConcept")
                    .IsUnique();

            // configure alternate key index PK5_UniqueKeyConcept
            builder.HasIndex(entity => entity.ConceptId)
                    .HasDatabaseName("PK5_UniqueKeyConcept")
                    .IsUnique();

            // configure alternate key index PK6_SubTypeConcept
            builder.HasIndex(entity => entity.ConceptId)
                    .HasDatabaseName("PK6_SubTypeConcept")
                    .IsUnique();
        }

        #endregion
    }
}

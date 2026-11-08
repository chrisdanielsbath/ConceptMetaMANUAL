/****************************
 * ConceptRefConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration
{
    /// <summary>
    /// EF Core MySql Configuration class for the <see cref="DbEntities.ConceptRef" /> entity
    /// </summary>
    public partial class ConceptRefConfiguration
        : IEntityTypeConfiguration<DbEntities.ConceptRef>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.ConceptRef" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.ConceptRef> builder)
        {
            // configure ConceptRef class to map to ConceptRef table
            builder.ToTable("ConceptRef", "dbo");

            // configure primary key index PK_ConceptRef
            builder.HasKey(entity => entity.ConceptRefId)
                    .HasName("PK_ConceptRef");

            // configure ConceptRefId property (primary key field)
            builder.Property(entity => entity.ConceptRefId).IsRequired()
                    .HasColumnName("ConceptRefId")
                    .HasColumnType("int")
                    .UseMySQLAutoIncrementColumn("int");

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure PropertyName property
            builder.Property(entity => entity.PropertyName).IsRequired(false)
                    .HasColumnName("PropertyName")
                    .HasColumnType("varchar(200)");

            // configure PropertyDescription property
            builder.Property(entity => entity.PropertyDescription).IsRequired(false)
                    .HasColumnName("PropertyDescription")
                    .HasColumnType("varchar(200)");

            // configure ReferencedConceptId property
            builder.Property(entity => entity.ReferencedConceptId).IsRequired()
                    .HasColumnName("ReferencedConceptId")
                    .HasColumnType("int");

            // configure ConceptRefType property
            builder.Property(entity => entity.ConceptRefType).IsRequired()
                    .HasColumnName("ConceptRefType")
                    .HasColumnType("varchar(200)");

            // configure ConceptPropertyFamilyId property
            builder.Property(entity => entity.ConceptPropertyFamilyId).IsRequired(false)
                    .HasColumnName("ConceptPropertyFamilyId")
                    .HasColumnType("int");

            // configure IsPropagating property
            builder.Property(entity => entity.IsPropagating).IsRequired(false)
                    .HasColumnName("IsPropagating")
                    .HasColumnType("bool");

            // configure DbColumnName property
            builder.Property(entity => entity.DbColumnName).IsRequired(false)
                    .HasColumnName("DbColumnName")
                    .HasColumnType("varchar(200)");

            // configure IsIdentity property
            builder.Property(entity => entity.IsIdentity).IsRequired(false)
                    .HasColumnName("IsIdentity")
                    .HasColumnType("bool");

            // configure IsCoreField property
            builder.Property(entity => entity.IsCoreField).IsRequired(false)
                    .HasColumnName("IsCoreField")
                    .HasColumnType("bool");

            // configure FieldFamilyName property
            builder.Property(entity => entity.FieldFamilyName).IsRequired(false)
                    .HasColumnName("FieldFamilyName")
                    .HasColumnType("varchar(200)");

            // configure IsUpdatable property
            builder.Property(entity => entity.IsUpdatable).IsRequired(false)
                    .HasColumnName("IsUpdatable")
                    .HasColumnType("bool");

            // configure FieldLabel property
            builder.Property(entity => entity.FieldLabel).IsRequired(false)
                    .HasColumnName("FieldLabel")
                    .HasColumnType("varchar(200)");

            // configure IsScalarFieldToSerialiseInPersistenceModel property
            builder.Property(entity => entity.IsScalarFieldToSerialiseInPersistenceModel).IsRequired(false)
                    .HasColumnName("IsScalarFieldToSerialiseInPersistenceModel")
                    .HasColumnType("bool");

            // configure IsScalarFieldToSerialiseInDomainModel property
            builder.Property(entity => entity.IsScalarFieldToSerialiseInDomainModel).IsRequired(false)
                    .HasColumnName("IsScalarFieldToSerialiseInDomainModel")
                    .HasColumnType("bool");

            // configure IsSeqNoField property
            builder.Property(entity => entity.IsSeqNoField).IsRequired(false)
                    .HasColumnName("IsSeqNoField")
                    .HasColumnType("bool");

            // configure IsDiscriminatorField property
            builder.Property(entity => entity.IsDiscriminatorField).IsRequired(false)
                    .HasColumnName("IsDiscriminatorField")
                    .HasColumnType("bool");

            // configure IsXmlAttribute property
            builder.Property(entity => entity.IsXmlAttribute).IsRequired(false)
                    .HasColumnName("IsXmlAttribute")
                    .HasColumnType("bool");

            // configure IsReferenceToChildEntity property
            builder.Property(entity => entity.IsReferenceToChildEntity).IsRequired(false)
                    .HasColumnName("IsReferenceToChildEntity")
                    .HasColumnType("bool");

            // configure ParentQualifier property
            builder.Property(entity => entity.ParentQualifier).IsRequired(false)
                    .HasColumnName("ParentQualifier")
                    .HasColumnType("varchar(200)");

            // configure ChildQualifier property
            builder.Property(entity => entity.ChildQualifier).IsRequired(false)
                    .HasColumnName("ChildQualifier")
                    .HasColumnType("varchar(200)");

            // configure MinChildOccurrences property
            builder.Property(entity => entity.MinChildOccurrences).IsRequired(false)
                    .HasColumnName("MinChildOccurrences")
                    .HasColumnType("int");

            // configure MaxChildOccurrences property
            builder.Property(entity => entity.MaxChildOccurrences).IsRequired(false)
                    .HasColumnName("MaxChildOccurrences")
                    .HasColumnType("int");

            // configure ChildVerbPhrase property
            builder.Property(entity => entity.ChildVerbPhrase).IsRequired(false)
                    .HasColumnName("ChildVerbPhrase")
                    .HasColumnType("varchar(200)");

            // configure ParentVerbPhrase property
            builder.Property(entity => entity.ParentVerbPhrase).IsRequired(false)
                    .HasColumnName("ParentVerbPhrase")
                    .HasColumnType("varchar(200)");

            // configure ChildPropertySeq property
            builder.Property(entity => entity.ChildPropertySeq).IsRequired(false)
                    .HasColumnName("ChildPropertySeq")
                    .HasColumnType("int");

            // configure ChildCollectionName property
            builder.Property(entity => entity.ChildCollectionName).IsRequired(false)
                    .HasColumnName("ChildCollectionName")
                    .HasColumnType("varchar(200)");

            // configure ChildItemName property
            builder.Property(entity => entity.ChildItemName).IsRequired(false)
                    .HasColumnName("ChildItemName")
                    .HasColumnType("varchar(200)");

            // configure ChildPropertyDescription property
            builder.Property(entity => entity.ChildPropertyDescription).IsRequired(false)
                    .HasColumnName("ChildPropertyDescription")
                    .HasColumnType("varchar(200)");

            // configure SelectorType property
            builder.Property(entity => entity.SelectorType).IsRequired(false)
                    .HasColumnName("SelectorType")
                    .HasColumnType("varchar(200)");

            // configure RelationshipType property
            builder.Property(entity => entity.RelationshipType).IsRequired(false)
                    .HasColumnName("RelationshipType")
                    .HasColumnType("varchar(200)");

            // configure OutputExplicitXmlCollection property
            builder.Property(entity => entity.OutputExplicitXmlCollection).IsRequired(false)
                    .HasColumnName("OutputExplicitXmlCollection")
                    .HasColumnType("bool");

            // configure IsSerialisedUsingScalarFieldInDomainModel property
            builder.Property(entity => entity.IsSerialisedUsingScalarFieldInDomainModel).IsRequired(false)
                    .HasColumnName("IsSerialisedUsingScalarFieldInDomainModel")
                    .HasColumnType("bool");

            // configure ScalarFieldNameInDomainModel property
            builder.Property(entity => entity.ScalarFieldNameInDomainModel).IsRequired(false)
                    .HasColumnName("ScalarFieldNameInDomainModel")
                    .HasColumnType("varchar(200)");

            // configure ExampleValueAsString property
            builder.Property(entity => entity.ExampleValueAsString).IsRequired(false)
                    .HasColumnName("ExampleValueAsString")
                    .HasColumnType("varchar(200)");

            // configure RelationshipName property
            builder.Property(entity => entity.RelationshipName).IsRequired(false)
                    .HasColumnName("RelationshipName")
                    .HasColumnType("varchar(200)");

            // configure DbForeignKeyName property
            builder.Property(entity => entity.DbForeignKeyName).IsRequired(false)
                    .HasColumnName("DbForeignKeyName")
                    .HasColumnType("varchar(200)");

            // configure ParentIndexName property
            builder.Property(entity => entity.ParentIndexName).IsRequired(false)
                    .HasColumnName("ParentIndexName")
                    .HasColumnType("varchar(200)");

            // configure ForeignKeySurrogateKeyFieldName property
            builder.Property(entity => entity.ForeignKeySurrogateKeyFieldName).IsRequired(false)
                    .HasColumnName("ForeignKeySurrogateKeyFieldName")
                    .HasColumnType("varchar(200)");

            // configure ChildPropertyName property
            builder.Property(entity => entity.ChildPropertyName).IsRequired(false)
                    .HasColumnName("ChildPropertyName")
                    .HasColumnType("varchar(200)");

            // configure IsNullable property
            builder.Property(entity => entity.IsNullable).IsRequired(false)
                    .HasColumnName("IsNullable")
                    .HasColumnType("bool");

            // configure PropertySeq property
            builder.Property(entity => entity.PropertySeq).IsRequired(false)
                    .HasColumnName("PropertySeq")
                    .HasColumnType("int");

            // configure relationship to Concept (Concept.Properties)
            // linking to index PK4_ObjectConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.Properties)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptRef_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ReferencedConcept (ConceptRef.ReferencedConcept)
            // linking to index PK2_CommonConcept
            builder.HasOne<DbEntities.Concept>(entity => entity.ReferencedConcept)
                    .WithMany(referenced => referenced.ReferencedByProperties)
                    .HasForeignKey(entity => entity.ReferencedConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptRef_ReferencedConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to PropertyFamily (ConceptRef.PropertyFamily)
            builder.HasOne<DbEntities.ConceptPropertyFamily>(entity => entity.PropertyFamily)
                    .WithMany(referenced => referenced.Properties)
                    .HasForeignKey(entity => entity.ConceptPropertyFamilyId)
                    .HasConstraintName("FK_ConceptRef_ConceptPropertyFamilyId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptRef_ConceptId_PropertyName
            builder.HasIndex(entity => new {entity.ConceptId, entity.PropertyName})
                    .HasDatabaseName("AK_ConceptRef_ConceptId_PropertyName")
                    .IsUnique();
        }

        #endregion
    }
}

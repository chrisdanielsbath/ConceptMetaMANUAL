/****************************
 * ConceptRefConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptRef" /> entity
    /// </summary>
    public partial class ConceptRefConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptRef>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptRef" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptRef> builder)
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
                    .UseIdentityColumn();

            // configure ConceptId property
            builder.Property(entity => entity.ConceptId).IsRequired()
                    .HasColumnName("ConceptId")
                    .HasColumnType("int");

            // configure PropertyName property
            builder.Property(entity => entity.PropertyName).IsRequired(false)
                    .HasColumnName("PropertyName")
                    .HasColumnType("nvarchar(200)");

            // configure PropertyDescription property
            builder.Property(entity => entity.PropertyDescription).IsRequired(false)
                    .HasColumnName("PropertyDescription")
                    .HasColumnType("nvarchar(200)");

            // configure ReferencedConceptId property
            builder.Property(entity => entity.ReferencedConceptId).IsRequired()
                    .HasColumnName("ReferencedConceptId")
                    .HasColumnType("int");

            // configure ConceptRefType property
            builder.Property(entity => entity.ConceptRefType).IsRequired()
                    .HasColumnName("ConceptRefType")
                    .HasColumnType("nvarchar(200)");

            // configure ConceptPropertyFamilyId property
            builder.Property(entity => entity.ConceptPropertyFamilyId).IsRequired(false)
                    .HasColumnName("ConceptPropertyFamilyId")
                    .HasColumnType("int");

            // configure IsPropagating property
            builder.Property(entity => entity.IsPropagating).IsRequired(false)
                    .HasColumnName("IsPropagating")
                    .HasColumnType("bit");

            // configure DbColumnName property
            builder.Property(entity => entity.DbColumnName).IsRequired(false)
                    .HasColumnName("DbColumnName")
                    .HasColumnType("nvarchar(200)");

            // configure IsIdentity property
            builder.Property(entity => entity.IsIdentity).IsRequired(false)
                    .HasColumnName("IsIdentity")
                    .HasColumnType("bit");

            // configure IsCoreField property
            builder.Property(entity => entity.IsCoreField).IsRequired(false)
                    .HasColumnName("IsCoreField")
                    .HasColumnType("bit");

            // configure FieldFamilyName property
            builder.Property(entity => entity.FieldFamilyName).IsRequired(false)
                    .HasColumnName("FieldFamilyName")
                    .HasColumnType("nvarchar(200)");

            // configure IsUpdatable property
            builder.Property(entity => entity.IsUpdatable).IsRequired(false)
                    .HasColumnName("IsUpdatable")
                    .HasColumnType("bit");

            // configure FieldLabel property
            builder.Property(entity => entity.FieldLabel).IsRequired(false)
                    .HasColumnName("FieldLabel")
                    .HasColumnType("nvarchar(200)");

            // configure IsScalarFieldToSerialiseInPersistenceModel property
            builder.Property(entity => entity.IsScalarFieldToSerialiseInPersistenceModel).IsRequired(false)
                    .HasColumnName("IsScalarFieldToSerialiseInPersistenceModel")
                    .HasColumnType("bit");

            // configure IsScalarFieldToSerialiseInDomainModel property
            builder.Property(entity => entity.IsScalarFieldToSerialiseInDomainModel).IsRequired(false)
                    .HasColumnName("IsScalarFieldToSerialiseInDomainModel")
                    .HasColumnType("bit");

            // configure IsSeqNoField property
            builder.Property(entity => entity.IsSeqNoField).IsRequired(false)
                    .HasColumnName("IsSeqNoField")
                    .HasColumnType("bit");

            // configure IsDiscriminatorField property
            builder.Property(entity => entity.IsDiscriminatorField).IsRequired(false)
                    .HasColumnName("IsDiscriminatorField")
                    .HasColumnType("bit");

            // configure IsXmlAttribute property
            builder.Property(entity => entity.IsXmlAttribute).IsRequired(false)
                    .HasColumnName("IsXmlAttribute")
                    .HasColumnType("bit");

            // configure IsReferenceToChildEntity property
            builder.Property(entity => entity.IsReferenceToChildEntity).IsRequired(false)
                    .HasColumnName("IsReferenceToChildEntity")
                    .HasColumnType("bit");

            // configure ParentQualifier property
            builder.Property(entity => entity.ParentQualifier).IsRequired(false)
                    .HasColumnName("ParentQualifier")
                    .HasColumnType("nvarchar(200)");

            // configure ChildQualifier property
            builder.Property(entity => entity.ChildQualifier).IsRequired(false)
                    .HasColumnName("ChildQualifier")
                    .HasColumnType("nvarchar(200)");

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
                    .HasColumnType("nvarchar(200)");

            // configure ParentVerbPhrase property
            builder.Property(entity => entity.ParentVerbPhrase).IsRequired(false)
                    .HasColumnName("ParentVerbPhrase")
                    .HasColumnType("nvarchar(200)");

            // configure ChildPropertySeq property
            builder.Property(entity => entity.ChildPropertySeq).IsRequired(false)
                    .HasColumnName("ChildPropertySeq")
                    .HasColumnType("int");

            // configure ChildCollectionName property
            builder.Property(entity => entity.ChildCollectionName).IsRequired(false)
                    .HasColumnName("ChildCollectionName")
                    .HasColumnType("nvarchar(200)");

            // configure ChildItemName property
            builder.Property(entity => entity.ChildItemName).IsRequired(false)
                    .HasColumnName("ChildItemName")
                    .HasColumnType("nvarchar(200)");

            // configure ChildPropertyDescription property
            builder.Property(entity => entity.ChildPropertyDescription).IsRequired(false)
                    .HasColumnName("ChildPropertyDescription")
                    .HasColumnType("nvarchar(200)");

            // configure SelectorType property
            builder.Property(entity => entity.SelectorType).IsRequired(false)
                    .HasColumnName("SelectorType")
                    .HasColumnType("nvarchar(200)");

            // configure RelationshipType property
            builder.Property(entity => entity.RelationshipType).IsRequired(false)
                    .HasColumnName("RelationshipType")
                    .HasColumnType("nvarchar(200)");

            // configure OutputExplicitXmlCollection property
            builder.Property(entity => entity.OutputExplicitXmlCollection).IsRequired(false)
                    .HasColumnName("OutputExplicitXmlCollection")
                    .HasColumnType("bit");

            // configure IsSerialisedUsingScalarFieldInDomainModel property
            builder.Property(entity => entity.IsSerialisedUsingScalarFieldInDomainModel).IsRequired(false)
                    .HasColumnName("IsSerialisedUsingScalarFieldInDomainModel")
                    .HasColumnType("bit");

            // configure ScalarFieldNameInDomainModel property
            builder.Property(entity => entity.ScalarFieldNameInDomainModel).IsRequired(false)
                    .HasColumnName("ScalarFieldNameInDomainModel")
                    .HasColumnType("nvarchar(200)");

            // configure ExampleValueAsString property
            builder.Property(entity => entity.ExampleValueAsString).IsRequired(false)
                    .HasColumnName("ExampleValueAsString")
                    .HasColumnType("nvarchar(200)");

            // configure RelationshipName property
            builder.Property(entity => entity.RelationshipName).IsRequired(false)
                    .HasColumnName("RelationshipName")
                    .HasColumnType("nvarchar(200)");

            // configure DbForeignKeyName property
            builder.Property(entity => entity.DbForeignKeyName).IsRequired(false)
                    .HasColumnName("DbForeignKeyName")
                    .HasColumnType("nvarchar(200)");

            // configure ParentIndexName property
            builder.Property(entity => entity.ParentIndexName).IsRequired(false)
                    .HasColumnName("ParentIndexName")
                    .HasColumnType("nvarchar(200)");

            // configure ForeignKeySurrogateKeyFieldName property
            builder.Property(entity => entity.ForeignKeySurrogateKeyFieldName).IsRequired(false)
                    .HasColumnName("ForeignKeySurrogateKeyFieldName")
                    .HasColumnType("nvarchar(200)");

            // configure ChildPropertyName property
            builder.Property(entity => entity.ChildPropertyName).IsRequired(false)
                    .HasColumnName("ChildPropertyName")
                    .HasColumnType("nvarchar(200)");

            // configure IsNullable property
            builder.Property(entity => entity.IsNullable).IsRequired(false)
                    .HasColumnName("IsNullable")
                    .HasColumnType("bit");

            // configure PropertySeq property
            builder.Property(entity => entity.PropertySeq).IsRequired(false)
                    .HasColumnName("PropertySeq")
                    .HasColumnType("int");

            // configure relationship to Concept (Concept.Properties)
            // linking to index PK4_ObjectConcept
            builder.HasOne<RazorModels.Concept>(entity => entity.Concept)
                    .WithMany(referenced => referenced.Properties)
                    .HasForeignKey(entity => entity.ConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptRef_ConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ReferencedConcept (ConceptRef.ReferencedConcept)
            // linking to index PK2_CommonConcept
            builder.HasOne<RazorModels.Concept>(entity => entity.ReferencedConcept)
                    .WithMany(referenced => referenced.ReferencedByProperties)
                    .HasForeignKey(entity => entity.ReferencedConceptId)
                    .HasPrincipalKey(entity => entity.ConceptId)
                    .HasConstraintName("FK_ConceptRef_ReferencedConceptId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to PropertyFamily (ConceptRef.PropertyFamily)
            builder.HasOne<RazorModels.ConceptPropertyFamily>(entity => entity.PropertyFamily)
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

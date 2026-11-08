/****************************
 * ConceptSubTypePropertyFamilyRefConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefConfiguration
        : IEntityTypeConfiguration<RazorModels.ConceptSubTypePropertyFamilyRef>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.ConceptSubTypePropertyFamilyRef" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.ConceptSubTypePropertyFamilyRef> builder)
        {
            // configure ConceptSubTypePropertyFamilyRef class to map to ConceptSubTypePropertyFamilyRef table
            builder.ToTable("ConceptSubTypePropertyFamilyRef", "dbo");

            // configure primary key index PK_ConceptSubTypePropertyFamilyRef
            builder.HasKey(entity => entity.ConceptSubTypePropertyFamilyRefId)
                    .HasName("PK_ConceptSubTypePropertyFamilyRef");

            // configure ConceptSubTypePropertyFamilyRefId property (primary key field)
            builder.Property(entity => entity.ConceptSubTypePropertyFamilyRefId).IsRequired()
                    .HasColumnName("ConceptSubTypePropertyFamilyRefId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptSubTypeId property
            builder.Property(entity => entity.ConceptSubTypeId).IsRequired()
                    .HasColumnName("ConceptSubTypeId")
                    .HasColumnType("int");

            // configure ConceptPropertyFamilyId property
            builder.Property(entity => entity.ConceptPropertyFamilyId).IsRequired()
                    .HasColumnName("ConceptPropertyFamilyId")
                    .HasColumnType("int");

            // configure SeqNo property
            builder.Property(entity => entity.SeqNo).IsRequired()
                    .HasColumnName("SeqNo")
                    .HasColumnType("int");

            // configure relationship to ConceptSubType (ConceptSubType.PropertyFamilyRefs)
            builder.HasOne<RazorModels.ConceptSubType>(entity => entity.ConceptSubType)
                    .WithMany(referenced => referenced.PropertyFamilyRefs)
                    .HasForeignKey(entity => entity.ConceptSubTypeId)
                    .HasConstraintName("FK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ConceptPropertyFamily (ConceptSubTypePropertyFamilyRef.ConceptPropertyFamily)
            builder.HasOne<RazorModels.ConceptPropertyFamily>(entity => entity.ConceptPropertyFamily)
                    .WithMany(referenced => referenced.PropertyFamilyRefs)
                    .HasForeignKey(entity => entity.ConceptPropertyFamilyId)
                    .HasConstraintName("FK_ConceptSubTypePropertyFamilyRef_ConceptPropertyFamilyId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId_ConceptPropertyFamilyId
            builder.HasIndex(entity => new {entity.ConceptSubTypeId, entity.ConceptPropertyFamilyId})
                    .HasDatabaseName("AK_ConceptSubTypePropertyFamilyRef_ConceptSubTypeId_ConceptPropertyFamilyId")
                    .IsUnique();
        }

        #endregion
    }
}

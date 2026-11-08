/****************************
 * ConceptUniqueKeyPropertyFamilyRefConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration
{
    /// <summary>
    /// EF Core MySql Configuration class for the <see cref="DbEntities.ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefConfiguration
        : IEntityTypeConfiguration<DbEntities.ConceptUniqueKeyPropertyFamilyRef>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.ConceptUniqueKeyPropertyFamilyRef" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.ConceptUniqueKeyPropertyFamilyRef> builder)
        {
            // configure ConceptUniqueKeyPropertyFamilyRef class to map to ConceptUniqueKeyPropertyFamilyRef table
            builder.ToTable("ConceptUniqueKeyPropertyFamilyRef", "dbo");

            // configure primary key index PK_ConceptUniqueKeyPropertyFamilyRef
            builder.HasKey(entity => entity.ConceptUniqueKeyPropertyFamilyRefId)
                    .HasName("PK_ConceptUniqueKeyPropertyFamilyRef");

            // configure ConceptUniqueKeyPropertyFamilyRefId property (primary key field)
            builder.Property(entity => entity.ConceptUniqueKeyPropertyFamilyRefId).IsRequired()
                    .HasColumnName("ConceptUniqueKeyPropertyFamilyRefId")
                    .HasColumnType("int")
                    .UseMySQLAutoIncrementColumn("int");

            // configure ConceptUniqueKeyId property
            builder.Property(entity => entity.ConceptUniqueKeyId).IsRequired()
                    .HasColumnName("ConceptUniqueKeyId")
                    .HasColumnType("int");

            // configure ConceptPropertyFamilyId property
            builder.Property(entity => entity.ConceptPropertyFamilyId).IsRequired()
                    .HasColumnName("ConceptPropertyFamilyId")
                    .HasColumnType("int");

            // configure SeqNo property
            builder.Property(entity => entity.SeqNo).IsRequired()
                    .HasColumnName("SeqNo")
                    .HasColumnType("int");

            // configure relationship to ConceptUniqueKey (ConceptUniqueKey.PropertyFamilyRefs)
            builder.HasOne<DbEntities.ConceptUniqueKey>(entity => entity.ConceptUniqueKey)
                    .WithMany(referenced => referenced.PropertyFamilyRefs)
                    .HasForeignKey(entity => entity.ConceptUniqueKeyId)
                    .HasConstraintName("FK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure relationship to ConceptPropertyFamily (ConceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily)
            builder.HasOne<DbEntities.ConceptPropertyFamily>(entity => entity.ConceptPropertyFamily)
                    .WithMany(referenced => referenced.UniqueKeyPropertyFamilyRefs)
                    .HasForeignKey(entity => entity.ConceptPropertyFamilyId)
                    .HasConstraintName("FK_ConceptUniqueKeyPropertyFamilyRef_ConceptPropertyFamilyId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId_ConceptPropertyFamilyId
            builder.HasIndex(entity => new {entity.ConceptUniqueKeyId, entity.ConceptPropertyFamilyId})
                    .HasDatabaseName("AK_ConceptUniqueKeyPropertyFamilyRef_ConceptUniqueKeyId_ConceptPropertyFamilyId")
                    .IsUnique();
        }

        #endregion
    }
}

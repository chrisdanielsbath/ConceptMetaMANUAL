/****************************
 * EnumerationMemberConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MySql.Data.EntityFrameworkCore.Extensions;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration
{
    /// <summary>
    /// EF Core MySql Configuration class for the <see cref="DbEntities.EnumerationMember" /> entity
    /// </summary>
    public partial class EnumerationMemberConfiguration
        : IEntityTypeConfiguration<DbEntities.EnumerationMember>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.EnumerationMember" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.EnumerationMember> builder)
        {
            // configure EnumerationMember class to map to EnumerationMember table
            builder.ToTable("EnumerationMember", "dbo");

            // configure primary key index PK_EnumerationMember
            builder.HasKey(entity => entity.EnumerationMemberId)
                    .HasName("PK_EnumerationMember");

            // configure EnumerationMemberId property (primary key field)
            builder.Property(entity => entity.EnumerationMemberId).IsRequired()
                    .HasColumnName("EnumerationMemberId")
                    .HasColumnType("int")
                    .UseMySQLAutoIncrementColumn("int");

            // configure EnumerationId property
            builder.Property(entity => entity.EnumerationId).IsRequired()
                    .HasColumnName("EnumerationId")
                    .HasColumnType("int");

            // configure EnumeratedValue property
            builder.Property(entity => entity.EnumeratedValue).IsRequired()
                    .HasColumnName("EnumeratedValue")
                    .HasColumnType("varchar(200)");

            // configure EnumeratedValueDescription property
            builder.Property(entity => entity.EnumeratedValueDescription).IsRequired(false)
                    .HasColumnName("EnumeratedValueDescription")
                    .HasColumnType("varchar(500)");

            // configure relationship to Enumeration (Enumeration.EnumeratedValues)
            builder.HasOne<DbEntities.Enumeration>(entity => entity.Enumeration)
                    .WithMany(referenced => referenced.EnumeratedValues)
                    .HasForeignKey(entity => entity.EnumerationId)
                    .HasConstraintName("FK_EnumerationMember_EnumerationId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_EnumerationMember_EnumerationId_EnumeratedValue
            builder.HasIndex(entity => new {entity.EnumerationId, entity.EnumeratedValue})
                    .HasDatabaseName("AK_EnumerationMember_EnumerationId_EnumeratedValue")
                    .IsUnique();
        }

        #endregion
    }
}

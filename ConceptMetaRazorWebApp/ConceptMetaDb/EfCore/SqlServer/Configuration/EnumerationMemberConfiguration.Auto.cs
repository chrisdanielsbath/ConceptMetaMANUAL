/****************************
 * EnumerationMemberConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="RazorModels.EnumerationMember" /> entity
    /// </summary>
    public partial class EnumerationMemberConfiguration
        : IEntityTypeConfiguration<RazorModels.EnumerationMember>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="RazorModels.EnumerationMember" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<RazorModels.EnumerationMember> builder)
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
                    .UseIdentityColumn();

            // configure EnumerationId property
            builder.Property(entity => entity.EnumerationId).IsRequired()
                    .HasColumnName("EnumerationId")
                    .HasColumnType("int");

            // configure EnumeratedValue property
            builder.Property(entity => entity.EnumeratedValue).IsRequired()
                    .HasColumnName("EnumeratedValue")
                    .HasColumnType("nvarchar(200)");

            // configure EnumeratedValueDescription property
            builder.Property(entity => entity.EnumeratedValueDescription).IsRequired(false)
                    .HasColumnName("EnumeratedValueDescription")
                    .HasColumnType("nvarchar(500)");

            // configure relationship to Enumeration (Enumeration.EnumeratedValues)
            builder.HasOne<RazorModels.Enumeration>(entity => entity.Enumeration)
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

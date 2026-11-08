/****************************
 * DataTypeConfiguration.Auto.cs
 ****************************/
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.SqlServer.Configuration
{
    /// <summary>
    /// EF Core SqlServer Configuration class for the <see cref="DbEntities.DataType" /> entity
    /// </summary>
    public partial class DataTypeConfiguration
        : IEntityTypeConfiguration<DbEntities.DataType>
    {

        #region Instance Methods

        /// <summary>
        /// Configures the <see cref="DbEntities.DataType" /> class
        /// </summary>
        /// <param name="builder">The EntityTypeBuilder to be configured</param>
        public void Configure(EntityTypeBuilder<DbEntities.DataType> builder)
        {
            // configure DataType class to map to DataType table
            builder.ToTable("DataType", "dbo");

            // configure primary key index PK_DataType
            builder.HasKey(entity => entity.DataTypeId)
                    .HasName("PK_DataType");

            // configure DataTypeId property (primary key field)
            builder.Property(entity => entity.DataTypeId).IsRequired()
                    .HasColumnName("DataTypeId")
                    .HasColumnType("int")
                    .UseIdentityColumn();

            // configure ConceptModelId property
            builder.Property(entity => entity.ConceptModelId).IsRequired()
                    .HasColumnName("ConceptModelId")
                    .HasColumnType("int");

            // configure DataTypeName property
            builder.Property(entity => entity.DataTypeName).IsRequired()
                    .HasColumnName("DataTypeName")
                    .HasColumnType("nvarchar(200)");

            // configure SqlServerDataType property
            builder.Property(entity => entity.SqlServerDataType).IsRequired(false)
                    .HasColumnName("SqlServerDataType")
                    .HasColumnType("nvarchar(200)");

            // configure OracleDataType property
            builder.Property(entity => entity.OracleDataType).IsRequired(false)
                    .HasColumnName("OracleDataType")
                    .HasColumnType("nvarchar(200)");

            // configure MySqlDataType property
            builder.Property(entity => entity.MySqlDataType).IsRequired(false)
                    .HasColumnName("MySqlDataType")
                    .HasColumnType("nvarchar(200)");

            // configure MongoDbDataType property
            builder.Property(entity => entity.MongoDbDataType).IsRequired(false)
                    .HasColumnName("MongoDbDataType")
                    .HasColumnType("nvarchar(200)");

            // configure DotNetDataType property
            builder.Property(entity => entity.DotNetDataType).IsRequired(false)
                    .HasColumnName("DotNetDataType")
                    .HasColumnType("nvarchar(200)");

            // configure JavaDataType property
            builder.Property(entity => entity.JavaDataType).IsRequired(false)
                    .HasColumnName("JavaDataType")
                    .HasColumnType("nvarchar(200)");

            // configure XmlDataType property
            builder.Property(entity => entity.XmlDataType).IsRequired(false)
                    .HasColumnName("XmlDataType")
                    .HasColumnType("nvarchar(200)");

            // configure ExampleValueAsString property
            builder.Property(entity => entity.ExampleValueAsString).IsRequired(false)
                    .HasColumnName("ExampleValueAsString")
                    .HasColumnType("nvarchar(200)");

            // configure JsonDataType property
            builder.Property(entity => entity.JsonDataType).IsRequired(false)
                    .HasColumnName("JsonDataType")
                    .HasColumnType("nvarchar(200)");

            // configure JsonFormat property
            builder.Property(entity => entity.JsonFormat).IsRequired(false)
                    .HasColumnName("JsonFormat")
                    .HasColumnType("nvarchar(200)");

            // configure OpenApiDataType property
            builder.Property(entity => entity.OpenApiDataType).IsRequired(false)
                    .HasColumnName("OpenApiDataType")
                    .HasColumnType("nvarchar(200)");

            // configure OpenApiFormat property
            builder.Property(entity => entity.OpenApiFormat).IsRequired(false)
                    .HasColumnName("OpenApiFormat")
                    .HasColumnType("nvarchar(200)");

            // configure ErsDataType property
            builder.Property(entity => entity.ErsDataType).IsRequired(false)
                    .HasColumnName("ErsDataType")
                    .HasColumnType("nvarchar(200)");

            // configure BasicDataType property
            builder.Property(entity => entity.BasicDataType).IsRequired(false)
                    .HasColumnName("BasicDataType")
                    .HasColumnType("nvarchar(200)");

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

            // configure HasLength property
            builder.Property(entity => entity.HasLength).IsRequired(false)
                    .HasColumnName("HasLength")
                    .HasColumnType("bit");

            // configure HasTotalDigits property
            builder.Property(entity => entity.HasTotalDigits).IsRequired(false)
                    .HasColumnName("HasTotalDigits")
                    .HasColumnType("bit");

            // configure HasDecimalPlaces property
            builder.Property(entity => entity.HasDecimalPlaces).IsRequired(false)
                    .HasColumnName("HasDecimalPlaces")
                    .HasColumnType("bit");

            // configure HasIdentity property
            builder.Property(entity => entity.HasIdentity).IsRequired(false)
                    .HasColumnName("HasIdentity")
                    .HasColumnType("bit");

            // configure HasDatePrecision property
            builder.Property(entity => entity.HasDatePrecision).IsRequired(false)
                    .HasColumnName("HasDatePrecision")
                    .HasColumnType("bit");

            // configure relationship to ConceptModel (ConceptModel.DataTypes)
            builder.HasOne<DbEntities.ConceptModel>(entity => entity.ConceptModel)
                    .WithMany(referenced => referenced.DataTypes)
                    .HasForeignKey(entity => entity.ConceptModelId)
                    .HasConstraintName("FK_DataType_ConceptModelId")
                    .OnDelete(DeleteBehavior.ClientNoAction);

            // configure alternate key index AK_DataType_ConceptModelId_DataTypeName
            builder.HasIndex(entity => new {entity.ConceptModelId, entity.DataTypeName})
                    .HasDatabaseName("AK_DataType_ConceptModelId_DataTypeName")
                    .IsUnique();
        }

        #endregion
    }
}

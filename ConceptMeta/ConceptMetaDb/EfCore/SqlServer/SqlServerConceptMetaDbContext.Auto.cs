/****************************
 * SqlServerConceptMetaDbContext.Auto.cs
 ****************************/
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.EfCore.SqlServer.Configuration;
using ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.SqlServer
{
    /// <summary>
    /// EF Core SqlServer Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// </summary>
    public partial class SqlServerConceptMetaDbContext
        : DbContext
    {

        #region Instance Properties
        public DbSet<Concept> Concepts { get; set; }
        public DbSet<ConceptModel> ConceptModels { get; set; }
        public DbSet<ConceptPropertyFamily> ConceptPropertyFamilies { get; set; }
        public DbSet<ConceptRef> ConceptRefs { get; set; }
        public DbSet<ConceptSubType> ConceptSubTypes { get; set; }
        public DbSet<ConceptSubTypePropertyFamilyRef> ConceptSubTypePropertyFamilyRefs { get; set; }
        public DbSet<ConceptUniqueKey> ConceptUniqueKeys { get; set; }
        public DbSet<ConceptUniqueKeyPropertyFamilyRef> ConceptUniqueKeyPropertyFamilyRefs { get; set; }
        public DbSet<DataType> DataTypes { get; set; }
        public DbSet<Enumeration> Enumerations { get; set; }
        public DbSet<EnumerationMember> EnumerationMembers { get; set; }
        public DbSet<Include> Includes { get; set; }
        public DbSet<Qualifier> Qualifiers { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Configures the database tables that store entity details
        /// </summary>
        /// <param name="modelBuilder">the ModelBuilder to be used</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new ConceptConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptModelConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptPropertyFamilyConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptRefConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptSubTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptSubTypePropertyFamilyRefConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptUniqueKeyConfiguration());
            modelBuilder.ApplyConfiguration(new ConceptUniqueKeyPropertyFamilyRefConfiguration());
            modelBuilder.ApplyConfiguration(new DataTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EnumerationConfiguration());
            modelBuilder.ApplyConfiguration(new EnumerationMemberConfiguration());
            modelBuilder.ApplyConfiguration(new IncludeConfiguration());
            modelBuilder.ApplyConfiguration(new QualifierConfiguration());
        }

        #endregion
    }
}

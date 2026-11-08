/****************************
 * SqlServerConceptMetaDbModelsContext.Auto.cs
 ****************************/
using Microsoft.EntityFrameworkCore;
using ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer.Configuration;
using RazorModels = ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore.SqlServer
{
    /// <summary>
    /// EF Core SqlServer Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// </summary>
    public partial class SqlServerConceptMetaDbModelsContext
        : DbContext
    {

        #region Instance Properties
        public DbSet<RazorModels.Concept> Concepts { get; set; }
        public DbSet<RazorModels.ConceptModel> ConceptModels { get; set; }
        public DbSet<RazorModels.ConceptPropertyFamily> ConceptPropertyFamilies { get; set; }
        public DbSet<RazorModels.ConceptRef> ConceptRefs { get; set; }
        public DbSet<RazorModels.ConceptSubType> ConceptSubTypes { get; set; }
        public DbSet<RazorModels.ConceptSubTypePropertyFamilyRef> ConceptSubTypePropertyFamilyRefs { get; set; }
        public DbSet<RazorModels.ConceptUniqueKey> ConceptUniqueKeys { get; set; }
        public DbSet<RazorModels.ConceptUniqueKeyPropertyFamilyRef> ConceptUniqueKeyPropertyFamilyRefs { get; set; }
        public DbSet<RazorModels.DataType> DataTypes { get; set; }
        public DbSet<RazorModels.Enumeration> Enumerations { get; set; }
        public DbSet<RazorModels.EnumerationMember> EnumerationMembers { get; set; }
        public DbSet<RazorModels.Include> Includes { get; set; }
        public DbSet<RazorModels.Qualifier> Qualifiers { get; set; }

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

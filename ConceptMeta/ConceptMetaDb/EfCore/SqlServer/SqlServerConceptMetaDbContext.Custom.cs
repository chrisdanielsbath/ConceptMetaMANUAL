/****************************
 * SqlServerConceptMetaDbContext.Custom.cs
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

        #region Constructors

        /// <summary>
        /// Creates a new SqlServerConceptMetaDbContext
        /// </summary>
        public SqlServerConceptMetaDbContext()
            : base ()
        {
        }

        /// <summary>
        /// Creates a new SqlServerConceptMetaDbContext
        /// </summary>
        /// <param name="options">options</param>
        public SqlServerConceptMetaDbContext(DbContextOptions options)
            : base (options)
        {
        }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Configures the database connection to be used when persisting and retrieving entities
        /// </summary>
        /// <param name="optionsBuilder">the DbContextOptionsBuilder to be used</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                    "Server=localhost; Database=ConceptMeta_EXAMPLE; Trusted_Connection=True; TrustServerCertificate=True;"
            );
        }

        #endregion
    }
}

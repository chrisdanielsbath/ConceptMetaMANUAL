/****************************
 * MySqlConceptMetaDbContext.Custom.cs
 ****************************/
using Microsoft.EntityFrameworkCore;
using MySql.Data.EntityFrameworkCore.Extensions;
using ConceptMeta.ConceptMetaDb.EfCore.MySql.Configuration;
using ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql
{
    /// <summary>
    /// EF Core MySql Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// </summary>
    public partial class MySqlConceptMetaDbContext
        : DbContext
    {

        #region Constructors

        /// <summary>
        /// Creates a new MySqlConceptMetaDbContext
        /// </summary>
        public MySqlConceptMetaDbContext()
            : base ()
        {
        }

        /// <summary>
        /// Creates a new MySqlConceptMetaDbContext
        /// </summary>
        /// <param name="options">options</param>
        public MySqlConceptMetaDbContext(DbContextOptions options)
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
            optionsBuilder.UseMySQL(
                    "Server=localhost; Database=ConceptMeta_EXAMPLE; Trusted_Connection=True; TrustServerCertificate=True;"
            );
        }

        #endregion
    }
}

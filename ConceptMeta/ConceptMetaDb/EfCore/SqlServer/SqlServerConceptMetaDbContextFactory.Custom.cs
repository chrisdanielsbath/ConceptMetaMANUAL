/****************************
 * SqlServerConceptMetaDbContextFactory.Custom.cs
 ****************************/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConceptMeta.ConceptMetaDb.EfCore.SqlServer
{
    /// <summary>
    /// EF Core SqlServer Design Time Database Context Factory for the ConceptMeta model
    /// </summary>
    public partial class SqlServerConceptMetaDbContextFactory
        : IDesignTimeDbContextFactory<SqlServerConceptMetaDbContext>
    {

        #region Instance Methods
        public SqlServerConceptMetaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SqlServerConceptMetaDbContext>();
            optionsBuilder.UseSqlServer("Server=localhost; Database=ConceptMeta_EXAMPLE; Trusted_Connection=True; TrustServerCertificate=True;");

            return new SqlServerConceptMetaDbContext(optionsBuilder.Options);
        }

        #endregion
    }
}

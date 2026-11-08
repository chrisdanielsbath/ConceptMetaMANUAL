/****************************
 * MySqlConceptMetaDbContextFactory.Custom.cs
 ****************************/
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ConceptMeta.ConceptMetaDb.EfCore.MySql
{
    /// <summary>
    /// EF Core MySql Design Time Database Context Factory for the ConceptMeta model
    /// </summary>
    public partial class MySqlConceptMetaDbContextFactory
        : IDesignTimeDbContextFactory<MySqlConceptMetaDbContext>
    {

        #region Instance Methods
        public MySqlConceptMetaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MySqlConceptMetaDbContext>();
            optionsBuilder.UseMySQL("Server=localhost; Database=ConceptMeta_EXAMPLE; Trusted_Connection=True; TrustServerCertificate=True;");

            return new MySqlConceptMetaDbContext(optionsBuilder.Options);
        }

        #endregion
    }
}

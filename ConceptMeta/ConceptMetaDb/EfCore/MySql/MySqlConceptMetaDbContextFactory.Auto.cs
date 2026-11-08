/****************************
 * MySqlConceptMetaDbContextFactory.Auto.cs
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
    }
}

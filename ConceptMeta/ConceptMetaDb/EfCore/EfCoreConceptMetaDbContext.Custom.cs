/****************************
 * EfCoreConceptMetaDbContext.Custom.cs
 ****************************/
namespace ConceptMeta.ConceptMetaDb.EfCore
{
    /// <summary>
    /// EF Core Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the DbContext class that is appropriate to the particular Dbms that is in use
    /// </summary>
    public partial class EfCoreConceptMetaDbContext
        : EfCore.SqlServer.SqlServerConceptMetaDbContext
    {

        #region Constructors
        public EfCoreConceptMetaDbContext()
            : base ()
        {
        }

        #endregion
    }
}

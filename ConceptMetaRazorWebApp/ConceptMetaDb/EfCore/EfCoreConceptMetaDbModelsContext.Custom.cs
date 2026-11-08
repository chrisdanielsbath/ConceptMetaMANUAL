/****************************
 * EfCoreConceptMetaDbModelsContext.Custom.cs
 ****************************/
namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb.EfCore
{
    /// <summary>
    /// EF Core Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the DbContext class that is appropriate to the particular Dbms that is in use
    /// </summary>
    public partial class EfCoreConceptMetaDbModelsContext
        : EfCore.SqlServer.SqlServerConceptMetaDbModelsContext
    {

        #region Constructors
        public EfCoreConceptMetaDbModelsContext()
            : base ()
        {
        }

        #endregion
    }
}

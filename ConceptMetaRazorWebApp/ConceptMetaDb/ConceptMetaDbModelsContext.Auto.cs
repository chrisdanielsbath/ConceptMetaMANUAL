/****************************
 * ConceptMetaDbModelsContext.Auto.cs
 ****************************/
namespace ConceptMeta.ConceptMetaDb.RazorWebApp.ConceptMetaDb
{
    /// <summary>
    /// Database Context for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the DbContext class that is appropriate to the particular Orm and Dbms that are in use
    /// </summary>
    public partial class ConceptMetaDbModelsContext
        : EfCore.EfCoreConceptMetaDbModelsContext
    {

        #region Constructors
        public ConceptMetaDbModelsContext()
            : base ()
        {
        }

        #endregion
    }
}

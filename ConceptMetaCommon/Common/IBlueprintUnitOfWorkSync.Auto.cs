/****************************
 * IBlueprintUnitOfWorkSync.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Blueprint Unit Of Work interface
    /// </summary>
    public partial interface IBlueprintUnitOfWorkSync
        : IBlueprintUnitOfWorkBase,
        ITransactionalUnitOfWorkSync
    {
    }
}

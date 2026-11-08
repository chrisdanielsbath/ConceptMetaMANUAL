/****************************
 * IBlueprintUnitOfWorkSync_TDbUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Blueprint Unit Of Work interface with specific TDbUnitOfWork
    /// </summary>
    public partial interface IBlueprintUnitOfWorkSync<TDbUnitOfWork>
        : IBlueprintUnitOfWorkBase<TDbUnitOfWork>,
        IBlueprintUnitOfWorkSync
        where TDbUnitOfWork : class, ITransactionalUnitOfWorkSync
    {
    }
}

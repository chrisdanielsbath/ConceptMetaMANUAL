/****************************
 * IDomainUnitOfWorkSync_TBlueprintUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Domain Unit Of Work interface with specified BlueprintUnitOfWork
    /// </summary>
    public partial interface IDomainUnitOfWorkSync<TBlueprintUnitOfWork>
        : IDomainUnitOfWorkBase<TBlueprintUnitOfWork>,
        IDomainUnitOfWorkSync
        where TBlueprintUnitOfWork : class, ITransactionalUnitOfWorkSync
    {
    }
}

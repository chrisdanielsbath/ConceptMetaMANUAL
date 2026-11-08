/****************************
 * IDomainUnitOfWorkAsync_TBlueprintUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Domain Unit Of Work interface with specified BlueprintUnitOfWork
    /// </summary>
    public partial interface IDomainUnitOfWorkAsync<TBlueprintUnitOfWork>
        : IDomainUnitOfWorkBase<TBlueprintUnitOfWork>,
        IDomainUnitOfWorkAsync
        where TBlueprintUnitOfWork : class, ITransactionalUnitOfWorkAsync
    {
    }
}

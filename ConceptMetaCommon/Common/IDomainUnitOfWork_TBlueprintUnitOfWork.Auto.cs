/****************************
 * IDomainUnitOfWork_TBlueprintUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Domain Unit Of Work interface with specified BlueprintUnitOfWork
    /// </summary>
    public partial interface IDomainUnitOfWork<TBlueprintUnitOfWork>
        : IDomainUnitOfWork,
        IDomainUnitOfWorkSync<TBlueprintUnitOfWork>,
        IDomainUnitOfWorkAsync<TBlueprintUnitOfWork>
        where TBlueprintUnitOfWork : class, ITransactionalUnitOfWork
    {
    }
}

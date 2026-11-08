/****************************
 * IBlueprintUnitOfWorkAsync_TDbUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Blueprint Unit Of Work interface with specific TDbUnitOfWork
    /// </summary>
    public partial interface IBlueprintUnitOfWorkAsync<TDbUnitOfWork>
        : IBlueprintUnitOfWorkBase<TDbUnitOfWork>,
        IBlueprintUnitOfWorkAsync
        where TDbUnitOfWork : class, ITransactionalUnitOfWorkAsync
    {
    }
}

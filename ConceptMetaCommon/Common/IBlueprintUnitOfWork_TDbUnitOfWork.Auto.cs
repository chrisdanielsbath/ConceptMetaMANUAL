/****************************
 * IBlueprintUnitOfWork_TDbUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Blueprint Unit Of Work interface with specific TDbUnitOfWork
    /// </summary>
    public partial interface IBlueprintUnitOfWork<TDbUnitOfWork>
        : IBlueprintUnitOfWork,
        IBlueprintUnitOfWorkSync<TDbUnitOfWork>,
        IBlueprintUnitOfWorkAsync<TDbUnitOfWork>
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
    {
    }
}

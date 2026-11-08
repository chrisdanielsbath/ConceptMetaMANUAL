/****************************
 * IBlueprintUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Blueprint Unit Of Work interface
    /// </summary>
    public partial interface IBlueprintUnitOfWork
        : ITransactionalUnitOfWork,
        IBlueprintUnitOfWorkSync,
        IBlueprintUnitOfWorkAsync
    {
    }
}

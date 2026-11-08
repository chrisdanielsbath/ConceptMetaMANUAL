/****************************
 * IBlueprintUnitOfWorkAsync.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Blueprint Unit Of Work interface
    /// </summary>
    public partial interface IBlueprintUnitOfWorkAsync
        : IBlueprintUnitOfWorkBase,
        ITransactionalUnitOfWorkAsync
    {
    }
}

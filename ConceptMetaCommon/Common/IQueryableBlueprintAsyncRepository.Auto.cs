/****************************
 * IQueryableBlueprintAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Blueprint Repository interface
    /// </summary>
    public partial interface IQueryableBlueprintAsyncRepository<TBlueprintObj>
        : IReadableBlueprintAsyncRepository<TBlueprintObj>,
        IQueryableAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

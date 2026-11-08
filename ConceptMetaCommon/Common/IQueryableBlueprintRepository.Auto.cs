/****************************
 * IQueryableBlueprintRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository interface for a relational data store
    /// </summary>
    public partial interface IQueryableBlueprintRepository<TBlueprintObj>
        : IReadableBlueprintRepository<TBlueprintObj>,
        IQueryableBlueprintSyncRepository<TBlueprintObj>,
        IQueryableBlueprintAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

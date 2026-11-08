/****************************
 * IQueryableBlueprintSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Blueprint Repository interface
    /// </summary>
    public partial interface IQueryableBlueprintSyncRepository<TBlueprintObj>
        : IReadableBlueprintSyncRepository<TBlueprintObj>,
        IQueryableSyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

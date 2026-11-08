/****************************
 * IReadWriteBlueprintRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// ReadWrite Repository interface for a relational data store
    /// </summary>
    public partial interface IReadWriteBlueprintRepository<TBlueprintObj>
        : IReadableBlueprintRepository<TBlueprintObj>,
        IReadWriteBlueprintSyncRepository<TBlueprintObj>,
        IReadWriteBlueprintAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

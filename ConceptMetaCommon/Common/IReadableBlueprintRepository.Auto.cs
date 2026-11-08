/****************************
 * IReadableBlueprintRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Blueprint Repository Interface
    /// </summary>
    public partial interface IReadableBlueprintRepository<TBlueprintObj>
        : IReadableRepository<TBlueprintObj>,
        IReadableBlueprintSyncRepository<TBlueprintObj>,
        IReadableBlueprintAsyncRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

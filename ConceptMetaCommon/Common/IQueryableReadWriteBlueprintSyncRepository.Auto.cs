/****************************
 * IQueryableReadWriteBlueprintSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Blueprint Repository interface
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintSyncRepository<TBlueprint>
        : IReadWriteBlueprintSyncRepository<TBlueprint>,
        IQueryableBlueprintSyncRepository<TBlueprint>
        where TBlueprint : class
    {
    }
}

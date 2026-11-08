/****************************
 * IQueryableReadWriteBlueprintRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Blueprint Repository interface
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintRepository<TBlueprint>
        : IReadWriteBlueprintRepository<TBlueprint>,
        IQueryableBlueprintRepository<TBlueprint>,
        IQueryableReadWriteBlueprintSyncRepository<TBlueprint>,
        IQueryableReadWriteBlueprintAsyncRepository<TBlueprint>
        where TBlueprint : class
    {
    }
}

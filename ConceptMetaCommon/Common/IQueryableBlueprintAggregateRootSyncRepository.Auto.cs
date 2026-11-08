/****************************
 * IQueryableBlueprintAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableBlueprintAggregateRootSyncRepository<TAggregateRoot>
        : IQueryableBlueprintSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}

/****************************
 * IQueryableBlueprintAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableBlueprintAggregateRootRepository<TAggregateRoot>
        : IQueryableBlueprintRepository<TAggregateRoot>,
        IQueryableBlueprintAggregateRootSyncRepository<TAggregateRoot>,
        IQueryableBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}

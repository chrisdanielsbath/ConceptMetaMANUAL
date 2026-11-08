/****************************
 * IQueryableBlueprintAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Repository Interface for Blueprint Aggregate Roots
    /// </summary>
    public partial interface IQueryableBlueprintAggregateRootAsyncRepository<TAggregateRoot>
        : IQueryableBlueprintAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}

/****************************
 * IReadWriteBlueprintAggregateAsyncRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadWriteBlueprintAggregateAsyncRepository<TAggregate>
        : IReadableBlueprintAggregateAsyncRepository<TAggregate>,
        IReadWriteAsyncRepository<TAggregate>
        where TAggregate : class
    {
    }
}

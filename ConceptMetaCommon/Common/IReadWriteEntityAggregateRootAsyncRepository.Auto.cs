/****************************
 * IReadWriteEntityAggregateRootAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadWriteEntityAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableEntityAggregateRootAsyncRepository<TAggregateRoot>,
        IReadWriteEntityAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}

/****************************
 * IReadableBlueprintAggregateAsyncRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadableBlueprintAggregateAsyncRepository<TAggregate>
        : IReadableAsyncRepository<TAggregate>
        where TAggregate : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TAggregate> GetByBusinessKeyAsync(params object[] keyValues);

        #endregion
    }
}

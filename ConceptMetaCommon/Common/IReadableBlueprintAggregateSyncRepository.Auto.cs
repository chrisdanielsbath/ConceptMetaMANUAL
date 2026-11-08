/****************************
 * IReadableBlueprintAggregateSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Repository Interface for Blueprint Aggregates
    /// </summary>
    public partial interface IReadableBlueprintAggregateSyncRepository<TAggregate>
        : IReadableSyncRepository<TAggregate>
        where TAggregate : class
    {

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TAggregate GetByBusinessKey(params object[] keyValues);

        #endregion
    }
}

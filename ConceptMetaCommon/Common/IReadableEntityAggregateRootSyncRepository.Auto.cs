/****************************
 * IReadableEntityAggregateRootSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadableEntityAggregateRootSyncRepository<TAggregateRoot>
        : IReadableAggregateRootSyncRepository<TAggregateRoot>,
        IReadableEntitySyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        TAggregateRoot GetAggregateByBusinessKey(params object[] keyValues);

        #endregion
    }
}

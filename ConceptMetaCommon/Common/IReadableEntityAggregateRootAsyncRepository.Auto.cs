/****************************
 * IReadableEntityAggregateRootAsyncRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Repository Interface for Aggregate Root Entities
    /// </summary>
    public partial interface IReadableEntityAggregateRootAsyncRepository<TAggregateRoot>
        : IReadableAggregateRootAsyncRepository<TAggregateRoot>,
        IReadableEntityAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        Task<TAggregateRoot> GetAggregateByBusinessKeyAsync(params object[] keyValues);

        #endregion
    }
}

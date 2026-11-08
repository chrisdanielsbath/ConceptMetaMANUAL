/****************************
 * ReadableEntityAggregateSyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Common
{
    /// <summary>
    /// A synchronous repository that is used to retrieve aggregates from a relational store
    /// </summary>
    public partial class ReadableEntityAggregateSyncRepository<TAggregateRoot>
        : IReadableSyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ReadableEntityAggregateSyncRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="entityRepository"></param>
        public ReadableEntityAggregateSyncRepository(IReadableAggregateRootSyncRepository<TAggregateRoot> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The entity repository for the aggregate root
        /// </summary>
        protected IReadableAggregateRootSyncRepository<TAggregateRoot> EntityRepository { get; }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TAggregateRoot Get(params object[] keyValues)
        {
            return EntityRepository.GetAggregate(keyValues);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll()
        {
            return EntityRepository.GetAllAggregates();
        }

        #endregion
    }
}

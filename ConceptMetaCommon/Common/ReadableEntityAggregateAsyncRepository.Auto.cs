/****************************
 * ReadableEntityAggregateAsyncRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// An asynchronous repository that is used to retrieve aggregates from a relational store
    /// </summary>
    public partial class ReadableEntityAggregateAsyncRepository<TAggregateRoot>
        : IReadableAsyncRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ReadableEntityAggregateAsyncRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="entityRepository"></param>
        public ReadableEntityAggregateAsyncRepository(IReadableAggregateRootAsyncRepository<TAggregateRoot> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The entity repository for the aggregate root
        /// </summary>
        protected IReadableAggregateRootAsyncRepository<TAggregateRoot> EntityRepository { get; }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TAggregateRoot> GetAsync(params object[] keyValues)
        {
            return await EntityRepository.GetAggregateAsync(keyValues);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync()
        {
            return await EntityRepository.GetAllAggregatesAsync();
        }

        #endregion
    }
}

/****************************
 * ReadableEntityAggregateRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// A repository that is used to retrieve aggregates from a relational store
    /// </summary>
    public partial class ReadableEntityAggregateRepository<TAggregateRoot>
        : IReadableRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ReadableEntityAggregateRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="entityRepository"></param>
        public ReadableEntityAggregateRepository(IReadableAggregateRootRepository<TAggregateRoot> entityRepository)
        {
            EntityRepository = entityRepository;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The entity repository for the aggregate root
        /// </summary>
        protected IReadableAggregateRootRepository<TAggregateRoot> EntityRepository { get; }

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
        public IEnumerable<TAggregateRoot> GetAll()
        {
            return EntityRepository.GetAllAggregates();
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

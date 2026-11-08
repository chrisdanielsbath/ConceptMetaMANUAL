/****************************
 * BlueprintAggregateRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// A repository that is used to persist blueprint aggregates
    /// </summary>
    public abstract partial class BlueprintAggregateRepository<TAggregateRoot>
        : IReadWriteBlueprintAggregateRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BlueprintAggregateRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="blueprintRepository"></param>
        public BlueprintAggregateRepository(IReadWriteBlueprintAggregateRootRepository<TAggregateRoot> blueprintRepository)
        {
            BlueprintRepository = blueprintRepository;
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The blueprint repository for the aggregate root
        /// </summary>
        protected IReadWriteBlueprintAggregateRootRepository<TAggregateRoot> BlueprintRepository { get; }

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract TAggregateRoot GetByBusinessKey(params object[] keyValues);

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract Task<TAggregateRoot> GetByBusinessKeyAsync(params object[] keyValues);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TAggregateRoot Get(params object[] keyValues)
        {
            return BlueprintRepository.GetAggregate(keyValues);
        }

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TAggregateRoot> GetAsync(params object[] keyValues)
        {
            return await BlueprintRepository.GetAggregateAsync(keyValues);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAll()
        {
            return BlueprintRepository.GetAllAggregates();
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> GetAllAsync()
        {
            return await BlueprintRepository.GetAllAggregatesAsync();
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Add(TAggregateRoot blueprintObj)
        {
            BlueprintRepository.AddAggregate(blueprintObj);
        }

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddAsync(TAggregateRoot blueprintObj)
        {
            await BlueprintRepository.AddAggregateAsync(blueprintObj);
        }

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            BlueprintRepository.AddAggregateRange(blueprintObjects);
        }

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            await BlueprintRepository.AddAggregateRangeAsync(blueprintObjects);
        }

        /// <summary>
        /// Adds an aggregate to the data store where no existing item has the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddIfNotExists(TAggregateRoot blueprintObj)
        {
            BlueprintRepository.AddAggregateIfNotExists(blueprintObj);
        }

        /// <summary>
        /// Adds an aggregate to the data store where no existing item has the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddIfNotExistsAsync(TAggregateRoot blueprintObj)
        {
            await BlueprintRepository.AddAggregateIfNotExistsAsync(blueprintObj);
        }

        /// <summary>
        /// Adds a set of aggregates in the data store where no existing object has the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddRangeIfNotExists(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            BlueprintRepository.AddAggregateRangeIfNotExists(blueprintObjects);
        }

        /// <summary>
        /// Adds a set of aggregates in the data store where no existing object has the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddRangeIfNotExistsAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            await BlueprintRepository.AddAggregateRangeIfNotExistsAsync(blueprintObjects);
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Update(TAggregateRoot blueprintObj)
        {
            BlueprintRepository.UpdateAggregate(blueprintObj);
        }

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TAggregateRoot blueprintObj)
        {
            await BlueprintRepository.UpdateAggregateAsync(blueprintObj);
        }

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void UpdateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            BlueprintRepository.UpdateAggregateRange(blueprintObjects);
        }

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            await BlueprintRepository.UpdateAggregateRangeAsync(blueprintObjects);
        }

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddOrUpdate(TAggregateRoot blueprintObj)
        {
            BlueprintRepository.AddOrUpdateAggregate(blueprintObj);
        }

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(TAggregateRoot blueprintObj)
        {
            await BlueprintRepository.AddOrUpdateAggregateAsync(blueprintObj);
        }

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddOrUpdateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            BlueprintRepository.AddOrUpdateAggregateRange(blueprintObjects);
        }

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddOrUpdateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            await BlueprintRepository.AddOrUpdateAggregateRangeAsync(blueprintObjects);
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Remove(TAggregateRoot blueprintObj)
        {
            BlueprintRepository.RemoveAggregate(blueprintObj);
        }

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TAggregateRoot blueprintObj)
        {
            await BlueprintRepository.RemoveAggregateAsync(blueprintObj);
        }

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void RemoveRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            BlueprintRepository.RemoveAggregateRange(blueprintObjects);
        }

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            await BlueprintRepository.RemoveAggregateRangeAsync(blueprintObjects);
        }

        #endregion
    }
}

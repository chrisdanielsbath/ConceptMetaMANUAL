/****************************
 * DomainRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common.Domain
{
    /// <summary>
    /// Basic Domain Repository
    /// </summary>
    public abstract partial class DomainRepository<TDomainObj, TBlueprintObj, TDomainUnitOfWork, TBlueprintUnitOfWork, TBlueprintAggregateRepository>
        : IReadWriteDomainRepository<TDomainObj>
        where TDomainObj : class
        where TBlueprintObj : class
        where TDomainUnitOfWork : class, IDomainUnitOfWork<TBlueprintUnitOfWork>
        where TBlueprintUnitOfWork : class, IBlueprintUnitOfWork
        where TBlueprintAggregateRepository : IReadWriteBlueprintAggregateRepository<TBlueprintObj>
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="DomainRepository{TDomainObj, TBlueprintObj, TDomainUnitOfWork, TBlueprintUnitOfWork, TBlueprintAggregateRepository}" /> class
        /// </summary>
        /// <param name="domainUnitOfWork"></param>
        /// <param name="blueprintAggregateRepository"></param>
        public DomainRepository(
            TDomainUnitOfWork domainUnitOfWork,
            TBlueprintAggregateRepository blueprintAggregateRepository)
        {
            DomainUnitOfWork = domainUnitOfWork;
            BlueprintRepository = blueprintAggregateRepository;
        }

        #endregion

        #region Instance Properties
        protected TDomainUnitOfWork DomainUnitOfWork { get; private set; }
        protected TBlueprintUnitOfWork BlueprintUnitOfWork => DomainUnitOfWork.BlueprintUnitOfWork;
        protected TBlueprintAggregateRepository BlueprintRepository { get; private set; }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Converts a domain object to a blueprint object
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        protected abstract TBlueprintObj ToBlueprintObj(TDomainObj domainObj);

        /// <summary>
        /// Converts a set of domain objects to a set of blueprint objects
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TBlueprintObj> ToBlueprintObjects(IEnumerable<TDomainObj> domainObjects);

        /// <summary>
        /// Converts a blueprint object to a domain object
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected abstract TDomainObj ToDomainObject(TBlueprintObj blueprintObj);

        /// <summary>
        /// Converts a set of blueprint objects to a set of domain objects
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TDomainObj> ToDomainObjects(IEnumerable<TBlueprintObj> blueprintObjects);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TDomainObj Get(params object[] keyValues)
        {
            TBlueprintObj blueprintObj =
                BlueprintRepository.GetByBusinessKey(keyValues);

            return ToDomainObject(blueprintObj);
        }

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TDomainObj> GetAsync(params object[] keyValues)
        {
            TBlueprintObj blueprintObj =
                await BlueprintRepository.GetByBusinessKeyAsync(keyValues);

            return ToDomainObject(blueprintObj);
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TDomainObj> GetAll()
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                BlueprintRepository.GetAll();

            return ToDomainObjects(blueprintObjects);
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TDomainObj>> GetAllAsync()
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                await BlueprintRepository.GetAllAsync();

            return ToDomainObjects(blueprintObjects);
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        public void Add(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            BlueprintRepository.Add(blueprintObj);
        }

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        public async Task AddAsync(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            await BlueprintRepository.AddAsync(blueprintObj);
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        public void AddRange(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            BlueprintRepository.AddRange(blueprintObjects);
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            await BlueprintRepository.AddRangeAsync(blueprintObjects);
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="domainObj"></param>
        public void AddIfNotExists(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            BlueprintRepository.AddIfNotExists(blueprintObj);
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        public async Task AddIfNotExistsAsync(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            await BlueprintRepository.AddIfNotExistsAsync(blueprintObj);
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="domainObjects"></param>
        public void AddRangeIfNotExists(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            BlueprintRepository.AddRangeIfNotExists(blueprintObjects);
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        public async Task AddRangeIfNotExistsAsync(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            await BlueprintRepository.AddRangeIfNotExistsAsync(blueprintObjects);
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        public void Update(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            BlueprintRepository.Update(blueprintObj);
        }

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            await BlueprintRepository.UpdateAsync(blueprintObj);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        public void UpdateRange(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            BlueprintRepository.UpdateRange(blueprintObjects);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            await BlueprintRepository.UpdateRangeAsync(blueprintObjects);
        }

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        public void AddOrUpdate(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            BlueprintRepository.AddOrUpdate(blueprintObj);
        }

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            await BlueprintRepository.AddOrUpdateAsync(blueprintObj);
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        public void AddOrUpdateRange(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            BlueprintRepository.AddOrUpdateRange(blueprintObjects);
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        public async Task AddOrUpdateRangeAsync(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            await BlueprintRepository.AddOrUpdateRangeAsync(blueprintObjects);
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        public void Remove(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            BlueprintRepository.Remove(blueprintObj);
        }

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TDomainObj domainObj)
        {
            TBlueprintObj blueprintObj =
                ToBlueprintObj(domainObj);

            await BlueprintRepository.RemoveAsync(blueprintObj);
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        public void RemoveRange(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            BlueprintRepository.RemoveRange(blueprintObjects);
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<TDomainObj> domainObjects)
        {
            IEnumerable<TBlueprintObj> blueprintObjects =
                ToBlueprintObjects(domainObjects);

            await BlueprintRepository.RemoveRangeAsync(blueprintObjects);
        }

        #endregion
    }
}

/****************************
 * BlueprintAggregateRootRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common.Blueprint
{
    /// <summary>
    /// Blueprint repository for aggregate roots
    /// </summary>
    public abstract partial class BlueprintAggregateRootRepository<TAggregateRoot, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityAggregateRootRepository>
        : BlueprintRepository<TAggregateRoot, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityAggregateRootRepository>,
        IReadWriteBlueprintAggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : class
        where TDbEntity : class
        where TBlueprintUnitOfWork : class, IBlueprintUnitOfWork<TDbUnitOfWork>
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
        where TDbEntityAggregateRootRepository : IReadWriteEntityAggregateRootRepository<TDbEntity>
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BlueprintAggregateRootRepository{TAggregateRoot, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityRepository}" /> class
        /// </summary>
        /// <param name="blueprintUnitOfWork"></param>
        /// <param name="dbEntityRepository"></param>
        public BlueprintAggregateRootRepository(
            TBlueprintUnitOfWork blueprintUnitOfWork,
            TDbEntityAggregateRootRepository dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The aggregate root repository to be used when persisting and retrieving database aggregates
        /// </summary>
        protected TDbEntityAggregateRootRepository DbEntityAggregateRootRepository => DbEntityRepository;

        #endregion

        #region Core protected methods

        /// <summary>
        /// Method to identify and perform necessary changes
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        protected abstract void AddAndUpdateAndRemoveEntitiesForAggregates(
            IEnumerable<TAggregateRoot> oldItems,
            IEnumerable<TAggregateRoot> newItems);

        /// <summary>
        /// Method to identify and perform necessary changes
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <returns></returns>
        protected abstract Task AddAndUpdateAndRemoveEntitiesForAggregatesAsync(
            IEnumerable<TAggregateRoot> oldItems,
            IEnumerable<TAggregateRoot> newItems);

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract TAggregateRoot GetAggregateByBusinessKey(params object[] keyValues);

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract Task<TAggregateRoot> GetAggregateByBusinessKeyAsync(params object[] keyValues);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TAggregateRoot GetAggregate(params object[] keyValues)
        {
            TDbEntity dbEntity =
                DbEntityAggregateRootRepository.GetAggregate(keyValues);

            return ToBlueprintObject(dbEntity);
        }

        /// <summary>
        /// Gets an aggregate from the data store
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TAggregateRoot> GetAggregateAsync(params object[] keyValues)
        {
            TDbEntity dbEntity =
                await DbEntityAggregateRootRepository.GetAggregateAsync(keyValues);

            return ToBlueprintObject(dbEntity);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TAggregateRoot> GetAllAggregates()
        {
            IEnumerable<TDbEntity> dbEntities =
                DbEntityAggregateRootRepository.GetAllAggregates();

            return ToBlueprintObjects(dbEntities);
        }

        /// <summary>
        /// Gets all aggregates from the data store
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TAggregateRoot>> GetAllAggregatesAsync()
        {
            IEnumerable<TDbEntity> dbEntities =
                await DbEntityAggregateRootRepository.GetAllAggregatesAsync();

            return ToBlueprintObjects(dbEntities);
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddAggregate(TAggregateRoot blueprintObj)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            List<TAggregateRoot> entities = new List<TAggregateRoot> { blueprintObj };
            AddAndUpdateAndRemoveEntitiesForAggregates(emptyList, entities);
        }

        /// <summary>
        /// Adds an aggregate to the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddAggregateAsync(TAggregateRoot blueprintObj)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            List<TAggregateRoot> entities = new List<TAggregateRoot> { blueprintObj };
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(emptyList, entities);
        }

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            AddAndUpdateAndRemoveEntitiesForAggregates(emptyList, blueprintObjects);
        }

        /// <summary>
        /// Adds a set of aggregates to the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddAggregateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(emptyList, blueprintObjects);
        }

        /// <summary>
        /// Adds an aggregate in the data store if no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddAggregateIfNotExists(TAggregateRoot blueprintObj)
        {
            PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = Get(GetPrimaryKeyObjectArray(blueprintObj));
            if (oldItem == null)
            {
                AddAggregate(blueprintObj);
            }
        }

        /// <summary>
        /// Adds an aggregate in the data store if no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddAggregateIfNotExistsAsync(TAggregateRoot blueprintObj)
        {
            await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = await GetAsync(GetPrimaryKeyObjectArray(blueprintObj));
            if (oldItem == null)
            {
                await AddAggregateAsync(blueprintObj);
            }
        }

        /// <summary>
        /// Adds a set of aggregates to the data store where no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddAggregateRangeIfNotExists(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            List<TAggregateRoot> itemsToAdd = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                TAggregateRoot oldItem = Get(GetPrimaryKeyObjectArray(blueprintObj));
                if (oldItem == null)
                {
                    itemsToAdd.Add(blueprintObj);
                }
            }
            AddAndUpdateAndRemoveEntitiesForAggregates(emptyList, itemsToAdd);
        }

        /// <summary>
        /// Adds a set of aggregates to the data store where no existing entry has the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddAggregateRangeIfNotExistsAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            List<TAggregateRoot> itemsToAdd = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                TAggregateRoot oldItem = await GetAsync(GetPrimaryKeyObjectArray(blueprintObj));
                if (oldItem == null)
                {
                    itemsToAdd.Add(blueprintObj);
                }
            }
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(emptyList, itemsToAdd);
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void UpdateAggregate(TAggregateRoot blueprintObj)
        {
            PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
                        
            List<TAggregateRoot> items = new List<TAggregateRoot> { blueprintObj };
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
                        
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, items);
        }

        /// <summary>
        /// Updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task UpdateAggregateAsync(TAggregateRoot blueprintObj)
        {
            await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
                        
            List<TAggregateRoot> items = new List<TAggregateRoot> { blueprintObj };
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
                        
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, items);
        }

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void UpdateAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
                oldItems.Add(oldItem);
            }
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, blueprintObjects);
        }

        /// <summary>
        /// Updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task UpdateAggregateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
                oldItems.Add(oldItem);
            }
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, blueprintObjects);
        }

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddOrUpdateAggregate(TAggregateRoot blueprintObj)
        {
            PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
                        
            List<TAggregateRoot> items = new List<TAggregateRoot> { blueprintObj };
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
                        
            if (oldItem != null)
            {
                oldItems = new List<TAggregateRoot> { oldItem };
            }
            else
            {
                oldItems = new List<TAggregateRoot>();
            }
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, items);
        }

        /// <summary>
        /// Adds an aggregate or updates an aggregate in the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAggregateAsync(TAggregateRoot blueprintObj)
        {
            await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
                        
            List<TAggregateRoot> items = new List<TAggregateRoot> { blueprintObj };
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
                        
            if (oldItem != null)
            {
                oldItems = new List<TAggregateRoot> { oldItem };
            }
            else
            {
                oldItems = new List<TAggregateRoot>();
            }
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, items);
        }

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddOrUpdateAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
                if (oldItem != null)
                {
                    oldItems.Add(oldItem);
                }
            }
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, blueprintObjects);
        }

        /// <summary>
        /// Adds or updates a set of aggregates in the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAggregateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
                if (oldItem != null)
                {
                    oldItems.Add(oldItem);
                }
            }
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, blueprintObjects);
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void RemoveAggregate(TAggregateRoot blueprintObj)
        {
            PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, emptyList);
        }

        /// <summary>
        /// Removes an aggregate from the data store
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task RemoveAggregateAsync(TAggregateRoot blueprintObj)
        {
            await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
            TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
            List<TAggregateRoot> oldItems = new List<TAggregateRoot> { oldItem };
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, emptyList);
        }

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void RemoveAggregateRange(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                PopulateMissingPrimaryKeysIfKnown(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = GetAggregate(GetPrimaryKeyObjectArray(blueprintObj));
                oldItems.Add(oldItem);
            }
            AddAndUpdateAndRemoveEntitiesForAggregates(oldItems, emptyList);
        }

        /// <summary>
        /// Removes a set of aggregates from the data store
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task RemoveAggregateRangeAsync(IEnumerable<TAggregateRoot> blueprintObjects)
        {
            List<TAggregateRoot> oldItems = new List<TAggregateRoot>();
            List<TAggregateRoot> emptyList = new List<TAggregateRoot>();
            foreach (TAggregateRoot blueprintObj in blueprintObjects)
            {
                await PopulateMissingPrimaryKeysIfKnownAsync(new List<TAggregateRoot> { blueprintObj });
                TAggregateRoot oldItem = await GetAggregateAsync(GetPrimaryKeyObjectArray(blueprintObj));
                oldItems.Add(oldItem);
            }
            await AddAndUpdateAndRemoveEntitiesForAggregatesAsync(oldItems, emptyList);
        }

        #endregion
    }
}

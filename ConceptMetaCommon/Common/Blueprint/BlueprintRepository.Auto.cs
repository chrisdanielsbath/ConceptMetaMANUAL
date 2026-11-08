/****************************
 * BlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConceptMeta.Common.Blueprint
{
    /// <summary>
    /// Basic Blueprint Repository
    /// </summary>
    public abstract partial class BlueprintRepository<TBlueprintObj, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityRepository>
        : IReadWriteBlueprintRepository<TBlueprintObj>
        where TBlueprintObj : class
        where TDbEntity : class
        where TBlueprintUnitOfWork : class, IBlueprintUnitOfWork<TDbUnitOfWork>
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
        where TDbEntityRepository : IReadWriteEntityRepository<TDbEntity>
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BlueprintRepository{TBlueprintObj, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityRepository}" /> class
        /// </summary>
        /// <param name="blueprintUnitOfWork"></param>
        /// <param name="dbEntityRepository"></param>
        public BlueprintRepository(
            TBlueprintUnitOfWork blueprintUnitOfWork,
            TDbEntityRepository dbEntityRepository)
        {
            BlueprintUnitOfWork = blueprintUnitOfWork;
            DbEntityRepository = dbEntityRepository;
        }

        #endregion

        #region Instance Properties
        protected TBlueprintUnitOfWork BlueprintUnitOfWork { get; private set; }
        protected TDbUnitOfWork DbUnitOfWork => BlueprintUnitOfWork.DbUnitOfWork;
        protected TDbEntityRepository DbEntityRepository { get; private set; }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified blueprintObj
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected abstract object[] GetPrimaryKeyObjectArray(TBlueprintObj blueprintObj);

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected abstract TDbEntity ToDbEntity(TBlueprintObj blueprintObj);

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TDbEntity> ToDbEntities(IEnumerable<TBlueprintObj> blueprintObjects);

        /// <summary>
        /// Converts a database entity to a blueprint object
        /// </summary>
        /// <param name="dbEntity"></param>
        /// <returns></returns>
        protected abstract TBlueprintObj ToBlueprintObject(TDbEntity dbEntity);

        /// <summary>
        /// Converts a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TBlueprintObj> ToBlueprintObjects(IEnumerable<TDbEntity> dbEntities);

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected abstract IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> ToEntityBlueprintPairs(IEnumerable<TBlueprintObj> blueprintObjects);

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected abstract IEnumerable<TBlueprintObj> ToBlueprintObjects(IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> entityBlueprintPairs);

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract TBlueprintObj GetByBusinessKey(params object[] keyValues);

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public abstract Task<TBlueprintObj> GetByBusinessKeyAsync(params object[] keyValues);

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public abstract void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        /// <summary>
        /// Gets a function that maps a blueprintObj to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public abstract Func<TBlueprintObj, string> GetLogicalKeyFunction();

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public abstract Func<TBlueprintObj, bool> GetMissingPrimaryKeyPredicate();

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public abstract void CopyPrimaryKeyValuesFromEntityToObjects(
            TBlueprintObj fromBlueprintObj,
            IEnumerable<TBlueprintObj> toObjects);

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public abstract void PopulateForeignKeyValuesFromParents(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public abstract Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public abstract void PopulateMissingPrimaryKeysIfKnown(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public abstract Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<TBlueprintObj> items);

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public abstract void RenumberNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public abstract void SortNestedObjects(
            IEnumerable<TBlueprintObj> items,
            bool recurse = true);

        #endregion

        #region More Methods

        /// <summary>
        /// Identifies which items need to be added, updated and removed, based on primary keys
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <param name="itemsToAdd"></param>
        /// <param name="itemsToUpdate1"></param>
        /// <param name="itemsToUpdate2"></param>
        /// <param name="itemsToRemove"></param>
        public void IdentifyItemsPerAction(
            IEnumerable<TBlueprintObj> oldItems,
            IEnumerable<TBlueprintObj> newItems,
            out IEnumerable<TBlueprintObj> itemsToAdd,
            out IEnumerable<TBlueprintObj> itemsToUpdate1,
            out IEnumerable<TBlueprintObj> itemsToUpdate2,
            out IEnumerable<TBlueprintObj> itemsToRemove)
        {
            IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> oldEntityBlueprintPairs = ToEntityBlueprintPairs(oldItems);
            IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> newEntityBlueprintPairs = ToEntityBlueprintPairs(newItems);

            DbEntityRepository.IdentifyItemsPerAction(
                oldEntityBlueprintPairs,
                newEntityBlueprintPairs,
                out IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> entityBlueprintPairsToAdd,
                out IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> entityBlueprintPairsToUpdate1,
                out IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> entityBlueprintPairsToUpdate2,
                out IEnumerable<KeyValuePair<TDbEntity, TBlueprintObj>> entityBlueprintPairsToRemove);

            itemsToAdd = ToBlueprintObjects(entityBlueprintPairsToAdd);
            itemsToUpdate1 = ToBlueprintObjects(entityBlueprintPairsToUpdate1);
            itemsToUpdate2 = ToBlueprintObjects(entityBlueprintPairsToUpdate2);
            itemsToRemove = ToBlueprintObjects(entityBlueprintPairsToRemove);
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TBlueprintObj Get(params object[] keyValues)
        {
            TDbEntity dbEntity =
                DbEntityRepository.Get(keyValues);

            return ToBlueprintObject(dbEntity);
        }

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TBlueprintObj> GetAsync(params object[] keyValues)
        {
            TDbEntity dbEntity =
                await DbEntityRepository.GetAsync(keyValues);

            return ToBlueprintObject(dbEntity);
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TBlueprintObj> GetAll()
        {
            IEnumerable<TDbEntity> dbEntities =
                DbEntityRepository.GetAll();

            return ToBlueprintObjects(dbEntities);
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TBlueprintObj>> GetAllAsync()
        {
            IEnumerable<TDbEntity> dbEntities =
                await DbEntityRepository.GetAllAsync();

            return ToBlueprintObjects(dbEntities);
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Add(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            DbEntityRepository.Add(dbEntity);
        }

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddAsync(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            await DbEntityRepository.AddAsync(dbEntity);
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.AddRange(dbEntities);
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.AddRangeAsync(dbEntities);
        }

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddSterilisedRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.AddSterilisedRange(dbEntities);
        }

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddSterilisedRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.AddSterilisedRangeAsync(dbEntities);
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddIfNotExists(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            DbEntityRepository.AddIfNotExists(dbEntity);
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddIfNotExistsAsync(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            await DbEntityRepository.AddIfNotExistsAsync(dbEntity);
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddRangeIfNotExists(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.AddRangeIfNotExists(dbEntities);
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddRangeIfNotExistsAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.AddRangeIfNotExistsAsync(dbEntities);
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Update(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            DbEntityRepository.Update(dbEntity);
        }

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            await DbEntityRepository.UpdateAsync(dbEntity);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void UpdateRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.UpdateRange(dbEntities);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.UpdateRangeAsync(dbEntities);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void UpdateSterilisedRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.UpdateSterilisedRange(dbEntities);
        }

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task UpdateSterilisedRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.UpdateSterilisedRangeAsync(dbEntities);
        }

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void AddOrUpdate(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            DbEntityRepository.AddOrUpdate(dbEntity);
        }

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            await DbEntityRepository.AddOrUpdateAsync(dbEntity);
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void AddOrUpdateRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.AddOrUpdateRange(dbEntities);
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task AddOrUpdateRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.AddOrUpdateRangeAsync(dbEntities);
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        public void Remove(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            DbEntityRepository.Remove(dbEntity);
        }

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TBlueprintObj blueprintObj)
        {
            TDbEntity dbEntity =
                ToDbEntity(blueprintObj);

            await DbEntityRepository.RemoveAsync(dbEntity);
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        public void RemoveRange(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            DbEntityRepository.RemoveRange(dbEntities);
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<TBlueprintObj> blueprintObjects)
        {
            IEnumerable<TDbEntity> dbEntities =
                ToDbEntities(blueprintObjects);

            await DbEntityRepository.RemoveRangeAsync(dbEntities);
        }

        #endregion
    }
}

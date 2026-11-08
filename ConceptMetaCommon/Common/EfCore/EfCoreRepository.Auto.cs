/****************************
 * EfCoreRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ConceptMeta.Common.EfCore
{
    /// <summary>
    /// Basic EfCore Repository
    /// </summary>
    public abstract partial class EfCoreRepository<TEntity>
        : IQueryableReadWriteEntityRepository<TEntity>
        where TEntity : class
    {

        #region Instance Variables
        protected readonly DbContext Context;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="EfCoreRepository{TEntity}" /> class
        /// </summary>
        /// <param name="context"></param>
        public EfCoreRepository(DbContext context)
        {
            Context = context;
            PopulateRichEntityIncludes();
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// Paths to the parent entities that should be included within the results of each "Rich Entity" query
        /// </summary>
        protected IList<string> RichEntityIncludes { get; } = new List<string>();

        #endregion

        #region Protected methods

        /// <summary>
        /// Modifies the query so that the returned dataset includes child objects
        /// </summary>
        /// <param name="query"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        protected IQueryable<TEntity> ApplyIncludes(
            IQueryable<TEntity> query,
            IList<string> includes)
        {
            IQueryable<TEntity> result = query;
            if (includes != null)
            {
                foreach (string includeExpression in includes)
                {
                    result = result.Include(includeExpression);
                }
                if (includes.Count() > 1)
                {
                    result = result.AsSplitQuery();
                }
            }
            return result;
        }

        /// <summary>
        /// Returns the existing item from the database that matches the supplied item, 
        /// and also populates the primary key within the supplied item if it is missing
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected TEntity EnrichEntityAndReturnExistingItem(TEntity entity)
        {
            // ensure the primary key is populated within the supplied entity
            PopulateMissingPrimaryKeyIfKnown(entity);
            // try to find the item by primary key
            TEntity existingItem = Context.Set<TEntity>().Find(GetPrimaryKeyObjectArray(entity));
            // return the item, if found
            return existingItem;
        }

        /// <summary>
        /// Returns the existing item from the database that matches the supplied item, 
        /// and also populates the primary key within the supplied item if it is missing
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected async Task<TEntity> EnrichEntityAndReturnExistingItemAsync(TEntity entity)
        {
            // ensure the primary key is populated within the supplied entity
            await PopulateMissingPrimaryKeyIfKnownAsync(entity);
            // try to find the item by primary key
            TEntity existingItem = Context.Set<TEntity>().Find(GetPrimaryKeyObjectArray(entity));
            // return the item, if found
            return existingItem;
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract object[] GetPrimaryKeyObjectArray(TEntity entity);

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the entity with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, bool>> GetPrimaryKeyPredicate(params object[] keyValues);

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, bool>> GetPrimaryKeyPredicate(TEntity entity);

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, bool>> GetLogicalKeyPredicate(TEntity entity);

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified entity
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract object[] GetBusinessKeyObjectArray(TEntity entity);

        /// <summary>
        /// Gets the business key predicate that can be used to identify the entity with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected abstract Expression<Func<TEntity, bool>> GetBusinessKeyPredicate(params object[] keyValues);

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected abstract void CopyNonPkFields(
            TEntity from,
            TEntity to);

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected abstract void PopulateRichEntityIncludes();

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        protected abstract bool EntityHasReferencesToChildObjects(TEntity entity);

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="sterilisedEntity"></param>
        protected abstract void PopulateSterilisedEntity(
            TEntity entity,
            out TEntity sterilisedEntity);

        #endregion

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public abstract bool PopulateMissingPrimaryKeyIfKnown(TEntity e);

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public abstract Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(TEntity e);

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public abstract void PopulateForeignKeyValuesFromParents(IEnumerable<TEntity> items);

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public abstract void CopyUniqueKeyValuesToChildren(IEnumerable<TEntity> items);

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public abstract void CopyPrimaryKeyValuesFromEntityToObjects(
            TEntity fromEntity,
            IEnumerable<TEntity> toObjects);

        /// <summary>
        /// Gets a function that maps a entity to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public abstract Func<TEntity, string> GetLogicalKeyFunction();

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public abstract Func<TEntity, bool> GetMissingPrimaryKeyPredicate();

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TEntity Get(params object[] keyValues)
        {
            return Context.Set<TEntity>().Find(keyValues);
        }

        /// <summary>
        /// Gets the object identified by the specified key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TEntity> GetAsync(params object[] keyValues)
        {
            return await Context.Set<TEntity>().FindAsync(keyValues);
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll()
        {
            return Context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>();
            result = ApplyIncludes(result, includes);
            return result.ToList();
        }

        /// <summary>
        /// Gets all objects in the collection
        /// </summary>
        /// <param name="includes"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>();
            result = ApplyIncludes(result, includes);
            return await result.ToListAsync();
        }

        /// <summary>
        /// Gets the entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public TEntity GetByBusinessKey(params object[] keyValues)
        {
            Expression<Func<TEntity, bool>> predicate = GetBusinessKeyPredicate(keyValues);

            return (Find(predicate)).FirstOrDefault();
        }

        /// <summary>
        /// Gets the entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByBusinessKeyAsync(params object[] keyValues)
        {
            Expression<Func<TEntity, bool>> predicate = GetBusinessKeyPredicate(keyValues);

            return (await FindAsync(predicate)).FirstOrDefault();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).ToList();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Finds the number of objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public int FindCount(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate).Count();
        }

        /// <summary>
        /// Finds the number of objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<int> FindCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Context.Set<TEntity>().Where(predicate).CountAsync();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find(
            Expression<Func<TEntity, bool>> predicate,
            IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>();
            result = ApplyIncludes(result, includes);
            return result.Where(predicate).ToList();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync(
            Expression<Func<TEntity, bool>> predicate,
            IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>();
            result = ApplyIncludes(result, includes);
            return await result.Where(predicate).ToListAsync();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find<TOrderBy>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize)
        {
            return Context.Set<TEntity>()
                .Where(predicate)
                .OrderBy(orderBy)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync<TOrderBy>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize)
        {
            return await Context.Set<TEntity>()
                .Where(predicate)
                .OrderBy(orderBy)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> Find<TOrderBy>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize,
            IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>()
            .Where(predicate)
            .OrderBy(orderBy)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
            result = ApplyIncludes(result, includes);
            return result.ToList();
        }

        /// <summary>
        /// Finds the objects that satisfy the specified condition
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="orderBy"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <param name="includes"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FindAsync<TOrderBy>(
            Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, TOrderBy>> orderBy,
            int pageIndex,
            int pageSize,
            IList<string> includes)
        {
            IQueryable<TEntity> result = Context.Set<TEntity>()
            .Where(predicate)
            .OrderBy(orderBy)
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize);
            result = ApplyIncludes(result, includes);
            return await result.ToListAsync();
        }

        #endregion

        #region Methods that add objects

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
        }

        /// <summary>
        /// Adds the object to the repository collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Task.CompletedTask;
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Add(entity);
            }
        }

        /// <summary>
        /// Adds a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Add(entity);
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        public void AddSterilisedRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                PopulateSterilisedEntity(
                    entity,
                    out TEntity sterilisedEntity);

                if (sterilisedEntity == null)
                {
                    Add(entity);
                }
                else
                {
                    Add(sterilisedEntity);
                }
            }
        }

        /// <summary>
        /// Adds sterilised variants of a set of objects to the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddSterilisedRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                PopulateSterilisedEntity(
                    entity,
                    out TEntity sterilisedEntity);

                if (sterilisedEntity == null)
                {
                    await AddAsync(entity);
                }
                else
                {
                    await AddAsync(sterilisedEntity);
                }
            }
            await Task.CompletedTask;
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="entity"></param>
        public void AddIfNotExists(TEntity entity)
        {
            TEntity existingItem = EnrichEntityAndReturnExistingItem(entity);
            if (existingItem == null)
            {
                Add(entity);
            }
        }

        /// <summary>
        /// Adds the object to the repository collection if no existing object shares the same identifier
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddIfNotExistsAsync(TEntity entity)
        {
            TEntity existingItem = await EnrichEntityAndReturnExistingItemAsync(entity);
            if (existingItem == null)
            {
                Add(entity);
            }
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="entities"></param>
        public void AddRangeIfNotExists(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                AddIfNotExists(entity);
            }
        }

        /// <summary>
        /// Adds objects to the repository collection where no existing object shares the same identifier
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddRangeIfNotExistsAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await AddIfNotExistsAsync(entity);
            }
        }

        #endregion

        #region Methods that update objects

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            TEntity existingItem = EnrichEntityAndReturnExistingItem(entity);
            if (existingItem != null)
            {
                CopyNonPkFields(entity, existingItem);
            }
            else
            {
                throw new Exception("No existing item found to update");
            }
        }

        /// <summary>
        /// Updates the object in the repository collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(TEntity entity)
        {
            TEntity existingItem = await EnrichEntityAndReturnExistingItemAsync(entity);
            if (existingItem != null)
            {
                CopyNonPkFields(entity, existingItem);
            }
            else
            {
                throw new Exception("No existing item found to update");
            }
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                Update(entity);
            };
        }

        /// <summary>
        /// Updates a set of objects in the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await UpdateAsync(entity);
            };
        }

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="entities"></param>
        public void UpdateSterilisedRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                PopulateSterilisedEntity(
                    entity,
                    out TEntity sterilisedEntity);

                if (sterilisedEntity == null)
                {
                    Update(entity);
                }
                else
                {
                    Update(sterilisedEntity);
                }
            }
        }

        /// <summary>
        /// Updates a set of objects in the repository collection with sterlised variants of the supplied values
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task UpdateSterilisedRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                PopulateSterilisedEntity(
                    entity,
                    out TEntity sterilisedEntity);

                if (sterilisedEntity == null)
                {
                    await UpdateAsync(entity);
                }
                else
                {
                    await UpdateAsync(sterilisedEntity);
                }
            }
            await Task.CompletedTask;
        }

        #endregion

        #region Methods that add or update objects

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="entity"></param>
        public void AddOrUpdate(TEntity entity)
        {
            TEntity existingItem = EnrichEntityAndReturnExistingItem(entity);
            if (existingItem == null)
            {
                Add(entity);
            }
            else
            {
                CopyNonPkFields(entity, existingItem);
            }
        }

        /// <summary>
        /// Adds or updates the object in the repository collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task AddOrUpdateAsync(TEntity entity)
        {
            TEntity existingItem = await EnrichEntityAndReturnExistingItemAsync(entity);
            if (existingItem == null)
            {
                Add(entity);
            }
            else
            {
                CopyNonPkFields(entity, existingItem);
            }
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="entities"></param>
        public void AddOrUpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                AddOrUpdate(entity);
            }
        }

        /// <summary>
        /// Adds or updates a set of objects in the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task AddOrUpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            foreach (TEntity entity in entities)
            {
                await AddOrUpdateAsync(entity);
            }
        }

        #endregion

        #region Methods that enrich content

        /// <summary>
        /// Modifies objects to populate primary keys that can be deduced from logical keys
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> PopulateMissingPrimaryKeysIfKnown(IEnumerable<TEntity> items)
        {
            List<TEntity> result = new List<TEntity>();
            foreach (TEntity item in items)
            {
                if (PopulateMissingPrimaryKeyIfKnown(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Modifies objects to populate primary keys that can be deduced from logical keys
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<TEntity> items)
        {
            List<TEntity> result = new List<TEntity>();
            foreach (TEntity item in items)
            {
                if (await PopulateMissingPrimaryKeyIfKnownAsync(item))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        #endregion

        #region Methods that identify change

        /// <summary>
        /// Identifies which items need to be added, updated and removed, based on primary keys
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <param name="itemsToAdd"></param>
        /// <param name="itemsToUpdate1"></param>
        /// <param name="itemsToUpdate2"></param>
        /// <param name="itemsToRemove"></param>
        public void IdentifyItemsPerAction<TBlueprintObj>(
            IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> oldItems,
            IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> newItems,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToAdd,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToUpdate1,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToUpdate2,
            out IEnumerable<KeyValuePair<TEntity, TBlueprintObj>> itemsToRemove)
        {
            List<KeyValuePair<TEntity, TBlueprintObj>> rangeToAdd = new List<KeyValuePair<TEntity, TBlueprintObj>>();
            List<KeyValuePair<TEntity, TBlueprintObj>> rangeToUpdate1 = new List<KeyValuePair<TEntity, TBlueprintObj>>();
            List<KeyValuePair<TEntity, TBlueprintObj>> rangeToUpdate2 = new List<KeyValuePair<TEntity, TBlueprintObj>>();
            List<KeyValuePair<TEntity, TBlueprintObj>> rangeToRemove = new List<KeyValuePair<TEntity, TBlueprintObj>>();

            List<TEntity> entitiesToAdd = new List<TEntity>();
            List<TEntity> entitiesToUpdate1 = new List<TEntity>();
            List<TEntity> entitiesToUpdate2 = new List<TEntity>();
            List<TEntity> entitiesToRemove = new List<TEntity>();

            if (newItems != null)
            {
                if (oldItems == null)
                {
                    // need to *add* all the new items
                    rangeToAdd = newItems.ToList();

                    foreach (KeyValuePair<TEntity, TBlueprintObj> newItem in newItems)
                    {
                        // add the new item to our list of items to add, provided a matching item isn't there already
                        if (entitiesToAdd.AsQueryable().Where(GetLogicalKeyPredicate(newItem.Key)).FirstOrDefault() == null)
                        {
                            rangeToAdd.Add(newItem);
                            entitiesToAdd.Add(newItem.Key);

                            if (EntityHasReferencesToChildObjects(newItem.Key))
                            {
                                rangeToUpdate2.Add(newItem);
                                entitiesToUpdate2.Add(newItem.Key);
                            }
                        }
                    }
                }
                else
                {
                    List<TEntity> oldEntities = new List<TEntity>();
                    foreach (KeyValuePair<TEntity, TBlueprintObj> oldItem in oldItems)
                    {
                        oldEntities.Add(oldItem.Key);
                    }
                                
                    // need to either *add* or *update* each item from the new list, depending on whether it is present in the old list
                    foreach (KeyValuePair<TEntity, TBlueprintObj> newItem in newItems)
                    {
                        TEntity oldEntity = oldEntities.AsQueryable().Where(GetPrimaryKeyPredicate(newItem.Key)).FirstOrDefault();
                        if (oldEntity == null)
                        {
                            // new item - add it to our list of items to add, provided a matching item isn't there already
                            if (entitiesToAdd.AsQueryable().Where(GetLogicalKeyPredicate(newItem.Key)).FirstOrDefault() == null)
                            {
                                rangeToAdd.Add(newItem);
                                entitiesToAdd.Add(newItem.Key);

                                if (EntityHasReferencesToChildObjects(newItem.Key))
                                {
                                    rangeToUpdate2.Add(newItem);
                                    entitiesToUpdate2.Add(newItem.Key);
                                }
                            }
                        }
                        else
                        {
                            // existing item - add it to our list of items to update, provided a matching item isn't there already
                            if (entitiesToUpdate1.AsQueryable().Where(GetLogicalKeyPredicate(newItem.Key)).FirstOrDefault() == null)
                            {
                                rangeToUpdate1.Add(newItem);
                                entitiesToUpdate1.Add(newItem.Key);

                                if (EntityHasReferencesToChildObjects(newItem.Key))
                                {
                                    rangeToUpdate2.Add(newItem);
                                    entitiesToUpdate2.Add(newItem.Key);
                                }
                            }
                        }
                    }

                    List<TEntity> newEntities = new List<TEntity>();
                    foreach (KeyValuePair<TEntity, TBlueprintObj> newItem in newItems)
                    {
                        newEntities.Add(newItem.Key);
                    }

                    foreach (KeyValuePair<TEntity, TBlueprintObj> oldItem in oldItems)
                    {
                        TEntity newEntity = newEntities.AsQueryable().Where(GetPrimaryKeyPredicate(oldItem.Key)).FirstOrDefault();
                        if (newEntity == null)
                        {
                            // existing item - add it to our list of items to remove, provided a matching item isn't there already
                            if (entitiesToRemove.AsQueryable().Where(GetLogicalKeyPredicate(oldItem.Key)).FirstOrDefault() == null)
                            {
                                rangeToRemove.Add(oldItem);
                                entitiesToRemove.Add(oldItem.Key);
                            }
                        }
                    }
                }
            }
            itemsToAdd = rangeToAdd;
            itemsToUpdate1 = rangeToUpdate1;
            itemsToUpdate2 = rangeToUpdate2;
            itemsToRemove = rangeToRemove;
        }

        #endregion

        #region Methods that remove objects

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="entity"></param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Removes the object from the repository collection
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task RemoveAsync(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="entities"></param>
        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
        }

        /// <summary>
        /// Removes a set of objects from the repository collection
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            Context.Set<TEntity>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        #endregion
    }
}

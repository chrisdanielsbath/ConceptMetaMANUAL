/****************************
 * IncludeBlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Blueprint.Comparers;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositories
{
    /// <summary>
    /// Repository class for the <see cref="BlueprintModels.Include" /> entity
    /// </summary>
    public partial class IncludeBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.Include, DbEntities.Include, IConceptMetaDbUnitOfWork>,
        IIncludeBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public IncludeBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.Include> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified include
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.Include include)
        {
            return new object[] { include.IncludeId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.Include ToDbEntity(BlueprintModels.Include blueprintObj)
        {
            return (DbEntities.Include)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.Include),
                typeof(DbEntities.Include));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.Include> ToDbEntities(IEnumerable<BlueprintModels.Include> blueprintObjects)
        {
            return (IEnumerable<DbEntities.Include>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Include>),
                typeof(IEnumerable<DbEntities.Include>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="include"></param>
        /// <returns></returns>
        protected override BlueprintModels.Include ToBlueprintObject(DbEntities.Include include)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.Include result = (BlueprintModels.Include)BlueprintUnitOfWork.FromEntityMapper.Map(
                include,
                typeof(DbEntities.Include),
                typeof(BlueprintModels.Include));

            // sort nested objects
            BlueprintUnitOfWork.Includes.SortNestedObjects(new List<BlueprintModels.Include> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Include> ToBlueprintObjects(IEnumerable<DbEntities.Include> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Include> result = (IEnumerable<BlueprintModels.Include>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.Include>),
                typeof(IEnumerable<BlueprintModels.Include>));

            // sort nested objects
            BlueprintUnitOfWork.Includes.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.Include, BlueprintModels.Include>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.Include> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.Include, BlueprintModels.Include>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Include>),
                typeof(IEnumerable<KeyValuePair<DbEntities.Include, BlueprintModels.Include>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Include> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.Include, BlueprintModels.Include>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Include> result = (IEnumerable<BlueprintModels.Include>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.Include, BlueprintModels.Include>>),
                typeof(IEnumerable<BlueprintModels.Include>));

            // sort nested objects
            BlueprintUnitOfWork.Includes.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.Include GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string itemValue = (string)keyValues[2];
            return GetByModelNameConceptNameItemValue(
                modelName,
                conceptName,
                itemValue
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.Include> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string itemValue = (string)keyValues[2];
            return await GetByModelNameConceptNameItemValueAsync(
                modelName,
                conceptName,
                itemValue
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.Include> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a include to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Include, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.ItemValue != null ? e.ItemValue.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Include, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.IncludeId == default || e.IncludeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.Include fromBlueprintObj,
            IEnumerable<BlueprintModels.Include> toObjects)
        {
            foreach (BlueprintModels.Include obj in toObjects)
            {
                // populate the primary key within the object
                obj.IncludeId = fromBlueprintObj.IncludeId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.Include> items)
        {
            foreach (BlueprintModels.Include item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.ConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.Include> items)
        {
            foreach (BlueprintModels.Include item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.ConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.Include> items)
        {
            foreach (BlueprintModels.Include item in items)
            {
                if (item.IncludeId == default || item.IncludeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.ItemValue != default && item.ItemValue != "")
                    {
                        item.IncludeId = DbUnitOfWork.Includes.GetIncludeIdByModelNameConceptNameItemValue(
                            item.ModelName,
                            item.ConceptName,
                            item.ItemValue);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.Include> items)
        {
            foreach (BlueprintModels.Include item in items)
            {
                if (item.IncludeId == default || item.IncludeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.ItemValue != default && item.ItemValue != "")
                    {
                        item.IncludeId = await DbUnitOfWork.Includes.GetIncludeIdByModelNameConceptNameItemValueAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.ItemValue);
                    }
                }
            }
        }

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void RenumberNestedObjects(
            IEnumerable<BlueprintModels.Include> items,
            bool recurse = true)
        {
            // nothing to renumber
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.Include> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public BlueprintModels.Include GetByIncludeId(int includeId)
        {
            // get the rich entity
            DbEntities.Include include =
                DbUnitOfWork.Includes.GetRichEntityByIncludeId(
                    includeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Include> GetByIncludeIdAsync(int includeId)
        {
            // get the rich entity
            DbEntities.Include include =
                await DbUnitOfWork.Includes.GetRichEntityByIncludeIdAsync(
                    includeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public BlueprintModels.Include GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue)
        {
            // get the rich entity
            DbEntities.Include include =
                DbUnitOfWork.Includes.GetRichEntityByModelNameConceptNameItemValue(
                    modelName,
                    conceptName,
                    itemValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Include> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue)
        {
            // get the rich entity
            DbEntities.Include include =
                await DbUnitOfWork.Includes.GetRichEntityByModelNameConceptNameItemValueAsync(
                    modelName,
                    conceptName,
                    itemValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public BlueprintModels.Include GetByConceptIdItemValue(
            int conceptId,
            string itemValue)
        {
            // get the rich entity
            DbEntities.Include include =
                DbUnitOfWork.Includes.GetRichEntityByConceptIdItemValue(
                    conceptId,
                    itemValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Include> GetByConceptIdItemValueAsync(
            int conceptId,
            string itemValue)
        {
            // get the rich entity
            DbEntities.Include include =
                await DbUnitOfWork.Includes.GetRichEntityByConceptIdItemValueAsync(
                    conceptId,
                    itemValue);

            // transform the rich entity and return the result
            return ToBlueprintObject(include);
        }

        #endregion
    }
}

/****************************
 * ConceptUniqueKeyBlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Blueprint.Comparers;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositories
{
    /// <summary>
    /// Repository class for the <see cref="BlueprintModels.ConceptUniqueKey" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptUniqueKey, DbEntities.ConceptUniqueKey, IConceptMetaDbUnitOfWork>,
        IConceptUniqueKeyBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptUniqueKeyBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptUniqueKey> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptUniqueKey
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptUniqueKey conceptUniqueKey)
        {
            return new object[] { conceptUniqueKey.ConceptUniqueKeyId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptUniqueKey ToDbEntity(BlueprintModels.ConceptUniqueKey blueprintObj)
        {
            return (DbEntities.ConceptUniqueKey)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptUniqueKey),
                typeof(DbEntities.ConceptUniqueKey));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptUniqueKey> ToDbEntities(IEnumerable<BlueprintModels.ConceptUniqueKey> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptUniqueKey>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKey>),
                typeof(IEnumerable<DbEntities.ConceptUniqueKey>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptUniqueKey ToBlueprintObject(DbEntities.ConceptUniqueKey conceptUniqueKey)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptUniqueKey result = (BlueprintModels.ConceptUniqueKey)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptUniqueKey,
                typeof(DbEntities.ConceptUniqueKey),
                typeof(BlueprintModels.ConceptUniqueKey));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeys.SortNestedObjects(new List<BlueprintModels.ConceptUniqueKey> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptUniqueKey> ToBlueprintObjects(IEnumerable<DbEntities.ConceptUniqueKey> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptUniqueKey> result = (IEnumerable<BlueprintModels.ConceptUniqueKey>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptUniqueKey>),
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKey>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeys.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptUniqueKey> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKey>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptUniqueKey> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptUniqueKey> result = (IEnumerable<BlueprintModels.ConceptUniqueKey>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKey, BlueprintModels.ConceptUniqueKey>>),
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKey>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeys.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptUniqueKey GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string uniqueKeyName = (string)keyValues[2];
            return GetByModelNameConceptNameUniqueKeyName(
                modelName,
                conceptName,
                uniqueKeyName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptUniqueKey> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string uniqueKeyName = (string)keyValues[2];
            return await GetByModelNameConceptNameUniqueKeyNameAsync(
                modelName,
                conceptName,
                uniqueKeyName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptUniqueKey> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptUniqueKey conceptUniqueKey in items)
            {
                foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef propertyFamilyRef in conceptUniqueKey.PropertyFamilyRefs)
                {
                    propertyFamilyRef.ModelName = conceptUniqueKey.ModelName;
                    propertyFamilyRef.ConceptName = conceptUniqueKey.ConceptName;
                    propertyFamilyRef.UniqueKeyName = conceptUniqueKey.UniqueKeyName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.CopyLogicalBusinessKeysToNestedObjects(conceptUniqueKey.PropertyFamilyRefs, true);
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptUniqueKey to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptUniqueKey, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.UniqueKeyName != null ? e.UniqueKeyName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptUniqueKey, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptUniqueKeyId == default || e.ConceptUniqueKeyId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptUniqueKey fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptUniqueKey> toObjects)
        {
            foreach (BlueprintModels.ConceptUniqueKey obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptUniqueKeyId = fromBlueprintObj.ConceptUniqueKeyId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptUniqueKey> items)
        {
            foreach (BlueprintModels.ConceptUniqueKey item in items)
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
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptUniqueKey> items)
        {
            foreach (BlueprintModels.ConceptUniqueKey item in items)
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
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptUniqueKey> items)
        {
            foreach (BlueprintModels.ConceptUniqueKey item in items)
            {
                if (item.ConceptUniqueKeyId == default || item.ConceptUniqueKeyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.UniqueKeyName != default && item.UniqueKeyName != "")
                    {
                        item.ConceptUniqueKeyId = DbUnitOfWork.ConceptUniqueKeys.GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyName(
                            item.ModelName,
                            item.ConceptName,
                            item.UniqueKeyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptUniqueKey> items)
        {
            foreach (BlueprintModels.ConceptUniqueKey item in items)
            {
                if (item.ConceptUniqueKeyId == default || item.ConceptUniqueKeyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.UniqueKeyName != default && item.UniqueKeyName != "")
                    {
                        item.ConceptUniqueKeyId = await DbUnitOfWork.ConceptUniqueKeys.GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.UniqueKeyName);
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
            IEnumerable<BlueprintModels.ConceptUniqueKey> items,
            bool recurse = true)
        {
            int i;
            foreach (BlueprintModels.ConceptUniqueKey conceptUniqueKey in items)
            {
                i = 1;
                foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef propertyFamilyRef in conceptUniqueKey.PropertyFamilyRefs)
                {
                    propertyFamilyRef.SeqNo = i++;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.RenumberNestedObjects(conceptUniqueKey.PropertyFamilyRefs, true);
                }
            }
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.ConceptUniqueKey> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptUniqueKey conceptUniqueKey in items
                .Where(item => item != null))
            {
                conceptUniqueKey.PropertyFamilyRefs.Sort(new ConceptUniqueKeyPropertyFamilyRefComparer());
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.SortNestedObjects(conceptUniqueKey.PropertyFamilyRefs, true);
                }
            }
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKey GetByConceptUniqueKeyId(int conceptUniqueKeyId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByConceptUniqueKeyId(
                    conceptUniqueKeyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKey> GetByConceptUniqueKeyIdAsync(int conceptUniqueKeyId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                await DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByConceptUniqueKeyIdAsync(
                    conceptUniqueKeyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKey GetByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByModelNameConceptNameUniqueKeyName(
                    modelName,
                    conceptName,
                    uniqueKeyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKey> GetByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                await DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByModelNameConceptNameUniqueKeyNameAsync(
                    modelName,
                    conceptName,
                    uniqueKeyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKey GetByConceptIdUniqueKeyName(
            int conceptId,
            string uniqueKeyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByConceptIdUniqueKeyName(
                    conceptId,
                    uniqueKeyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKey> GetByConceptIdUniqueKeyNameAsync(
            int conceptId,
            string uniqueKeyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKey conceptUniqueKey =
                await DbUnitOfWork.ConceptUniqueKeys.GetRichEntityByConceptIdUniqueKeyNameAsync(
                    conceptId,
                    uniqueKeyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKey);
        }

        #endregion
    }
}

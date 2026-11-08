/****************************
 * ConceptUniqueKeyPropertyFamilyRefBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, DbEntities.ConceptUniqueKeyPropertyFamilyRef, IConceptMetaDbUnitOfWork>,
        IConceptUniqueKeyPropertyFamilyRefBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptUniqueKeyPropertyFamilyRefBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptUniqueKeyPropertyFamilyRef> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptUniqueKeyPropertyFamilyRef
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            return new object[] { conceptUniqueKeyPropertyFamilyRef.ConceptUniqueKeyPropertyFamilyRefId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptUniqueKeyPropertyFamilyRef ToDbEntity(BlueprintModels.ConceptUniqueKeyPropertyFamilyRef blueprintObj)
        {
            return (DbEntities.ConceptUniqueKeyPropertyFamilyRef)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptUniqueKeyPropertyFamilyRef),
                typeof(DbEntities.ConceptUniqueKeyPropertyFamilyRef));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> ToDbEntities(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>),
                typeof(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRef"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptUniqueKeyPropertyFamilyRef ToBlueprintObject(DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptUniqueKeyPropertyFamilyRef result = (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptUniqueKeyPropertyFamilyRef,
                typeof(DbEntities.ConceptUniqueKeyPropertyFamilyRef),
                typeof(BlueprintModels.ConceptUniqueKeyPropertyFamilyRef));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.SortNestedObjects(new List<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> ToBlueprintObjects(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> result = (IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptUniqueKeyPropertyFamilyRef>),
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> result = (IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptUniqueKeyPropertyFamilyRef, BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>>),
                typeof(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string uniqueKeyName = (string)keyValues[2];
            string propertyFamilyName = (string)keyValues[3];
            return GetByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
                modelName,
                conceptName,
                uniqueKeyName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string uniqueKeyName = (string)keyValues[2];
            string propertyFamilyName = (string)keyValues[3];
            return await GetByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
                modelName,
                conceptName,
                uniqueKeyName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a conceptUniqueKeyPropertyFamilyRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptUniqueKeyId.ToString() + "|"
                + e.ConceptPropertyFamilyId.ToString() + "|"
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptUniqueKeyPropertyFamilyRefId == default || e.ConceptUniqueKeyPropertyFamilyRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptUniqueKeyPropertyFamilyRef fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> toObjects)
        {
            foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptUniqueKeyPropertyFamilyRefId = fromBlueprintObj.ConceptUniqueKeyPropertyFamilyRefId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                // populate non-recursive foreign key fields
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
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyName(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                // populate non-recursive foreign key fields
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
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = await DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                if (item.ConceptUniqueKeyPropertyFamilyRefId == default || item.ConceptUniqueKeyPropertyFamilyRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.UniqueKeyName != default && item.UniqueKeyName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptUniqueKeyPropertyFamilyRefId = DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
                            item.ModelName,
                            item.ConceptName,
                            item.UniqueKeyName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptUniqueKeyPropertyFamilyRef item in items)
            {
                if (item.ConceptUniqueKeyPropertyFamilyRefId == default || item.ConceptUniqueKeyPropertyFamilyRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.UniqueKeyName != default && item.UniqueKeyName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptUniqueKeyPropertyFamilyRefId = await DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.UniqueKeyName,
                            item.PropertyFamilyName);
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
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items,
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
            IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyPropertyFamilyRefId(int conceptUniqueKeyPropertyFamilyRefId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByConceptUniqueKeyPropertyFamilyRefId(
                    conceptUniqueKeyPropertyFamilyRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyPropertyFamilyRefIdAsync(int conceptUniqueKeyPropertyFamilyRefId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                await DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByConceptUniqueKeyPropertyFamilyRefIdAsync(
                    conceptUniqueKeyPropertyFamilyRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
                    modelName,
                    conceptName,
                    uniqueKeyName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                await DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
                    modelName,
                    conceptName,
                    uniqueKeyName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyIdConceptPropertyFamilyId(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyId(
                    conceptUniqueKeyId,
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptUniqueKeyPropertyFamilyRef conceptUniqueKeyPropertyFamilyRef =
                await DbUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs.GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
                    conceptUniqueKeyId,
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptUniqueKeyPropertyFamilyRef);
        }

        #endregion
    }
}

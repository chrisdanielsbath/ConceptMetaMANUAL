/****************************
 * ConceptSubTypePropertyFamilyRefBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptSubTypePropertyFamilyRef, DbEntities.ConceptSubTypePropertyFamilyRef, IConceptMetaDbUnitOfWork>,
        IConceptSubTypePropertyFamilyRefBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptSubTypePropertyFamilyRefBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptSubTypePropertyFamilyRef> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptSubTypePropertyFamilyRef
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            return new object[] { conceptSubTypePropertyFamilyRef.ConceptSubTypePropertyFamilyRefId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptSubTypePropertyFamilyRef ToDbEntity(BlueprintModels.ConceptSubTypePropertyFamilyRef blueprintObj)
        {
            return (DbEntities.ConceptSubTypePropertyFamilyRef)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptSubTypePropertyFamilyRef),
                typeof(DbEntities.ConceptSubTypePropertyFamilyRef));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> ToDbEntities(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>),
                typeof(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRef"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptSubTypePropertyFamilyRef ToBlueprintObject(DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptSubTypePropertyFamilyRef result = (BlueprintModels.ConceptSubTypePropertyFamilyRef)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptSubTypePropertyFamilyRef,
                typeof(DbEntities.ConceptSubTypePropertyFamilyRef),
                typeof(BlueprintModels.ConceptSubTypePropertyFamilyRef));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.SortNestedObjects(new List<BlueprintModels.ConceptSubTypePropertyFamilyRef> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> ToBlueprintObjects(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> result = (IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptSubTypePropertyFamilyRef>),
                typeof(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> result = (IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptSubTypePropertyFamilyRef, BlueprintModels.ConceptSubTypePropertyFamilyRef>>),
                typeof(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptSubTypePropertyFamilyRef GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string subTypeName = (string)keyValues[2];
            string propertyFamilyName = (string)keyValues[3];
            return GetByModelNameConceptNameSubTypeNamePropertyFamilyName(
                modelName,
                conceptName,
                subTypeName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string subTypeName = (string)keyValues[2];
            string propertyFamilyName = (string)keyValues[3];
            return await GetByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
                modelName,
                conceptName,
                subTypeName,
                propertyFamilyName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a conceptSubTypePropertyFamilyRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptSubTypePropertyFamilyRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptSubTypeId.ToString() + "|"
                + e.ConceptPropertyFamilyId.ToString() + "|"
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptSubTypePropertyFamilyRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptSubTypePropertyFamilyRefId == default || e.ConceptSubTypePropertyFamilyRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptSubTypePropertyFamilyRef fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> toObjects)
        {
            foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptSubTypePropertyFamilyRefId = fromBlueprintObj.ConceptSubTypePropertyFamilyRefId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptSubTypeId == default || item.ConceptSubTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.SubTypeName != default && item.SubTypeName != "")
                    {
                        item.ConceptSubTypeId = DbUnitOfWork.ConceptSubTypes.GetConceptSubTypeIdByModelNameConceptNameSubTypeName(
                            item.ModelName,
                            item.ConceptName,
                            item.SubTypeName);
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
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptSubTypeId == default || item.ConceptSubTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.SubTypeName != default && item.SubTypeName != "")
                    {
                        item.ConceptSubTypeId = await DbUnitOfWork.ConceptSubTypes.GetConceptSubTypeIdByModelNameConceptNameSubTypeNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.SubTypeName);
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
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef item in items)
            {
                if (item.ConceptSubTypePropertyFamilyRefId == default || item.ConceptSubTypePropertyFamilyRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.SubTypeName != default && item.SubTypeName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptSubTypePropertyFamilyRefId = DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyName(
                            item.ModelName,
                            item.ConceptName,
                            item.SubTypeName,
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
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items)
        {
            foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef item in items)
            {
                if (item.ConceptSubTypePropertyFamilyRefId == default || item.ConceptSubTypePropertyFamilyRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.SubTypeName != default && item.SubTypeName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptSubTypePropertyFamilyRefId = await DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.SubTypeName,
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
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items,
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
            IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubTypePropertyFamilyRef GetByConceptSubTypePropertyFamilyRefId(int conceptSubTypePropertyFamilyRefId)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByConceptSubTypePropertyFamilyRefId(
                    conceptSubTypePropertyFamilyRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypePropertyFamilyRefIdAsync(int conceptSubTypePropertyFamilyRefId)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                await DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByConceptSubTypePropertyFamilyRefIdAsync(
                    conceptSubTypePropertyFamilyRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubTypePropertyFamilyRef GetByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyName(
                    modelName,
                    conceptName,
                    subTypeName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                await DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
                    modelName,
                    conceptName,
                    subTypeName,
                    propertyFamilyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubTypePropertyFamilyRef GetByConceptSubTypeIdConceptPropertyFamilyId(
            int conceptSubTypeId,
            int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByConceptSubTypeIdConceptPropertyFamilyId(
                    conceptSubTypeId,
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int conceptSubTypeId,
            int conceptPropertyFamilyId)
        {
            // get the rich entity
            DbEntities.ConceptSubTypePropertyFamilyRef conceptSubTypePropertyFamilyRef =
                await DbUnitOfWork.ConceptSubTypePropertyFamilyRefs.GetRichEntityByConceptSubTypeIdConceptPropertyFamilyIdAsync(
                    conceptSubTypeId,
                    conceptPropertyFamilyId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubTypePropertyFamilyRef);
        }

        #endregion
    }
}

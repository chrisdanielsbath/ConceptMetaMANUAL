/****************************
 * ConceptSubTypeBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.ConceptSubType" /> entity
    /// </summary>
    public partial class ConceptSubTypeBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptSubType, DbEntities.ConceptSubType, IConceptMetaDbUnitOfWork>,
        IConceptSubTypeBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptSubTypeBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptSubType> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptSubType
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptSubType conceptSubType)
        {
            return new object[] { conceptSubType.ConceptSubTypeId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptSubType ToDbEntity(BlueprintModels.ConceptSubType blueprintObj)
        {
            return (DbEntities.ConceptSubType)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptSubType),
                typeof(DbEntities.ConceptSubType));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptSubType> ToDbEntities(IEnumerable<BlueprintModels.ConceptSubType> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptSubType>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptSubType>),
                typeof(IEnumerable<DbEntities.ConceptSubType>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptSubType"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptSubType ToBlueprintObject(DbEntities.ConceptSubType conceptSubType)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptSubType result = (BlueprintModels.ConceptSubType)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptSubType,
                typeof(DbEntities.ConceptSubType),
                typeof(BlueprintModels.ConceptSubType));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypes.SortNestedObjects(new List<BlueprintModels.ConceptSubType> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptSubType> ToBlueprintObjects(IEnumerable<DbEntities.ConceptSubType> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptSubType> result = (IEnumerable<BlueprintModels.ConceptSubType>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptSubType>),
                typeof(IEnumerable<BlueprintModels.ConceptSubType>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypes.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptSubType> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptSubType>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptSubType> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptSubType> result = (IEnumerable<BlueprintModels.ConceptSubType>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptSubType, BlueprintModels.ConceptSubType>>),
                typeof(IEnumerable<BlueprintModels.ConceptSubType>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptSubTypes.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptSubType GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string subTypeName = (string)keyValues[2];
            return GetByModelNameConceptNameSubTypeName(
                modelName,
                conceptName,
                subTypeName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptSubType> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string subTypeName = (string)keyValues[2];
            return await GetByModelNameConceptNameSubTypeNameAsync(
                modelName,
                conceptName,
                subTypeName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptSubType> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptSubType conceptSubType in items)
            {
                foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef propertyFamilyRef in conceptSubType.PropertyFamilyRefs)
                {
                    propertyFamilyRef.ModelName = conceptSubType.ModelName;
                    propertyFamilyRef.ConceptName = conceptSubType.ConceptName;
                    propertyFamilyRef.SubTypeName = conceptSubType.SubTypeName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.CopyLogicalBusinessKeysToNestedObjects(conceptSubType.PropertyFamilyRefs, true);
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptSubType to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptSubType, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.SubTypeName != null ? e.SubTypeName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptSubType, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptSubTypeId == default || e.ConceptSubTypeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptSubType fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptSubType> toObjects)
        {
            foreach (BlueprintModels.ConceptSubType obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptSubTypeId = fromBlueprintObj.ConceptSubTypeId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptSubType> items)
        {
            foreach (BlueprintModels.ConceptSubType item in items)
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
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptSubType> items)
        {
            foreach (BlueprintModels.ConceptSubType item in items)
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
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptSubType> items)
        {
            foreach (BlueprintModels.ConceptSubType item in items)
            {
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
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptSubType> items)
        {
            foreach (BlueprintModels.ConceptSubType item in items)
            {
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
            }
        }

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void RenumberNestedObjects(
            IEnumerable<BlueprintModels.ConceptSubType> items,
            bool recurse = true)
        {
            int i;
            foreach (BlueprintModels.ConceptSubType conceptSubType in items)
            {
                i = 1;
                foreach (BlueprintModels.ConceptSubTypePropertyFamilyRef propertyFamilyRef in conceptSubType.PropertyFamilyRefs)
                {
                    propertyFamilyRef.SeqNo = i++;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.RenumberNestedObjects(conceptSubType.PropertyFamilyRefs, true);
                }
            }
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.ConceptSubType> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptSubType conceptSubType in items
                .Where(item => item != null))
            {
                conceptSubType.PropertyFamilyRefs.Sort(new ConceptSubTypePropertyFamilyRefComparer());
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs.SortNestedObjects(conceptSubType.PropertyFamilyRefs, true);
                }
            }
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubType GetByConceptSubTypeId(int conceptSubTypeId)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                DbUnitOfWork.ConceptSubTypes.GetRichEntityByConceptSubTypeId(
                    conceptSubTypeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubType> GetByConceptSubTypeIdAsync(int conceptSubTypeId)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                await DbUnitOfWork.ConceptSubTypes.GetRichEntityByConceptSubTypeIdAsync(
                    conceptSubTypeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubType GetByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                DbUnitOfWork.ConceptSubTypes.GetRichEntityByModelNameConceptNameSubTypeName(
                    modelName,
                    conceptName,
                    subTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubType> GetByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                await DbUnitOfWork.ConceptSubTypes.GetRichEntityByModelNameConceptNameSubTypeNameAsync(
                    modelName,
                    conceptName,
                    subTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptSubType GetByConceptIdSubTypeName(
            int conceptId,
            string subTypeName)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                DbUnitOfWork.ConceptSubTypes.GetRichEntityByConceptIdSubTypeName(
                    conceptId,
                    subTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptSubType> GetByConceptIdSubTypeNameAsync(
            int conceptId,
            string subTypeName)
        {
            // get the rich entity
            DbEntities.ConceptSubType conceptSubType =
                await DbUnitOfWork.ConceptSubTypes.GetRichEntityByConceptIdSubTypeNameAsync(
                    conceptId,
                    subTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptSubType);
        }

        #endregion
    }
}

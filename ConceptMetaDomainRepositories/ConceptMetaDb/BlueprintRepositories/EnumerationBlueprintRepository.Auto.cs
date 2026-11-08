/****************************
 * EnumerationBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.Enumeration" /> entity
    /// </summary>
    public partial class EnumerationBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.Enumeration, DbEntities.Enumeration, IConceptMetaDbUnitOfWork>,
        IEnumerationBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public EnumerationBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.Enumeration> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified enumeration
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.Enumeration enumeration)
        {
            return new object[] { enumeration.EnumerationId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.Enumeration ToDbEntity(BlueprintModels.Enumeration blueprintObj)
        {
            return (DbEntities.Enumeration)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.Enumeration),
                typeof(DbEntities.Enumeration));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.Enumeration> ToDbEntities(IEnumerable<BlueprintModels.Enumeration> blueprintObjects)
        {
            return (IEnumerable<DbEntities.Enumeration>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Enumeration>),
                typeof(IEnumerable<DbEntities.Enumeration>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="enumeration"></param>
        /// <returns></returns>
        protected override BlueprintModels.Enumeration ToBlueprintObject(DbEntities.Enumeration enumeration)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.Enumeration result = (BlueprintModels.Enumeration)BlueprintUnitOfWork.FromEntityMapper.Map(
                enumeration,
                typeof(DbEntities.Enumeration),
                typeof(BlueprintModels.Enumeration));

            // sort nested objects
            BlueprintUnitOfWork.Enumerations.SortNestedObjects(new List<BlueprintModels.Enumeration> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Enumeration> ToBlueprintObjects(IEnumerable<DbEntities.Enumeration> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Enumeration> result = (IEnumerable<BlueprintModels.Enumeration>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.Enumeration>),
                typeof(IEnumerable<BlueprintModels.Enumeration>));

            // sort nested objects
            BlueprintUnitOfWork.Enumerations.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.Enumeration> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Enumeration>),
                typeof(IEnumerable<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Enumeration> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Enumeration> result = (IEnumerable<BlueprintModels.Enumeration>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.Enumeration, BlueprintModels.Enumeration>>),
                typeof(IEnumerable<BlueprintModels.Enumeration>));

            // sort nested objects
            BlueprintUnitOfWork.Enumerations.SortNestedObjects(result);

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
        public override BlueprintModels.Enumeration GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string enumerationName = (string)keyValues[1];
            return GetByModelNameEnumerationName(
                modelName,
                enumerationName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.Enumeration> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string enumerationName = (string)keyValues[1];
            return await GetByModelNameEnumerationNameAsync(
                modelName,
                enumerationName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.Enumeration> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.Enumeration enumeration in items)
            {
                foreach (BlueprintModels.EnumerationMember enumerationMember in enumeration.EnumeratedValues)
                {
                    enumerationMember.ModelName = enumeration.ModelName;
                    enumerationMember.DataTypeName = enumeration.DataTypeName;
                    enumerationMember.EnumerationName = enumeration.EnumerationName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.EnumerationMembers.CopyLogicalBusinessKeysToNestedObjects(enumeration.EnumeratedValues, true);
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a enumeration to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Enumeration, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptModelId.ToString() + "|"
                + (e.EnumerationName != null ? e.EnumerationName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Enumeration, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.EnumerationId == default || e.EnumerationId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.Enumeration fromBlueprintObj,
            IEnumerable<BlueprintModels.Enumeration> toObjects)
        {
            foreach (BlueprintModels.Enumeration obj in toObjects)
            {
                // populate the primary key within the object
                obj.EnumerationId = fromBlueprintObj.EnumerationId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.Enumeration> items)
        {
            foreach (BlueprintModels.Enumeration item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = DbUnitOfWork.ConceptModels.GetConceptModelIdByModelName(
                            item.ModelName);
                    }
                }
                if (item.DataTypeId == default || item.DataTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.DataTypeName != default && item.DataTypeName != "")
                    {
                        item.DataTypeId = DbUnitOfWork.DataTypes.GetDataTypeIdByModelNameDataTypeName(
                            item.ModelName,
                            item.DataTypeName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.Enumeration> items)
        {
            foreach (BlueprintModels.Enumeration item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = await DbUnitOfWork.ConceptModels.GetConceptModelIdByModelNameAsync(
                            item.ModelName);
                    }
                }
                if (item.DataTypeId == default || item.DataTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.DataTypeName != default && item.DataTypeName != "")
                    {
                        item.DataTypeId = await DbUnitOfWork.DataTypes.GetDataTypeIdByModelNameDataTypeNameAsync(
                            item.ModelName,
                            item.DataTypeName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.Enumeration> items)
        {
            foreach (BlueprintModels.Enumeration item in items)
            {
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationName(
                            item.ModelName,
                            item.EnumerationName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.Enumeration> items)
        {
            foreach (BlueprintModels.Enumeration item in items)
            {
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = await DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationNameAsync(
                            item.ModelName,
                            item.EnumerationName);
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
            IEnumerable<BlueprintModels.Enumeration> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.Enumeration enumeration in items)
            {
                if (recurse)
                {
                    BlueprintUnitOfWork.EnumerationMembers.RenumberNestedObjects(enumeration.EnumeratedValues, true);
                }
            }
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.Enumeration> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.Enumeration enumeration in items
                .Where(item => item != null))
            {
                if (recurse)
                {
                    BlueprintUnitOfWork.EnumerationMembers.SortNestedObjects(enumeration.EnumeratedValues, true);
                }
            }
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public BlueprintModels.Enumeration GetByEnumerationId(int enumerationId)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                DbUnitOfWork.Enumerations.GetRichEntityByEnumerationId(
                    enumerationId);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Enumeration> GetByEnumerationIdAsync(int enumerationId)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                await DbUnitOfWork.Enumerations.GetRichEntityByEnumerationIdAsync(
                    enumerationId);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public BlueprintModels.Enumeration GetByModelNameEnumerationName(
            string modelName,
            string enumerationName)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                DbUnitOfWork.Enumerations.GetRichEntityByModelNameEnumerationName(
                    modelName,
                    enumerationName);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Enumeration> GetByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                await DbUnitOfWork.Enumerations.GetRichEntityByModelNameEnumerationNameAsync(
                    modelName,
                    enumerationName);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public BlueprintModels.Enumeration GetByConceptModelIdEnumerationName(
            int conceptModelId,
            string enumerationName)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                DbUnitOfWork.Enumerations.GetRichEntityByConceptModelIdEnumerationName(
                    conceptModelId,
                    enumerationName);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Enumeration> GetByConceptModelIdEnumerationNameAsync(
            int conceptModelId,
            string enumerationName)
        {
            // get the rich entity
            DbEntities.Enumeration enumeration =
                await DbUnitOfWork.Enumerations.GetRichEntityByConceptModelIdEnumerationNameAsync(
                    conceptModelId,
                    enumerationName);

            // transform the rich entity and return the result
            return ToBlueprintObject(enumeration);
        }

        #endregion
    }
}

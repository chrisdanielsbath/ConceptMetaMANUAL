/****************************
 * DataTypeBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.DataType" /> entity
    /// </summary>
    public partial class DataTypeBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.DataType, DbEntities.DataType, IConceptMetaDbUnitOfWork>,
        IDataTypeBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public DataTypeBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.DataType> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified dataType
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.DataType dataType)
        {
            return new object[] { dataType.DataTypeId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.DataType ToDbEntity(BlueprintModels.DataType blueprintObj)
        {
            return (DbEntities.DataType)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.DataType),
                typeof(DbEntities.DataType));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.DataType> ToDbEntities(IEnumerable<BlueprintModels.DataType> blueprintObjects)
        {
            return (IEnumerable<DbEntities.DataType>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.DataType>),
                typeof(IEnumerable<DbEntities.DataType>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override BlueprintModels.DataType ToBlueprintObject(DbEntities.DataType dataType)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.DataType result = (BlueprintModels.DataType)BlueprintUnitOfWork.FromEntityMapper.Map(
                dataType,
                typeof(DbEntities.DataType),
                typeof(BlueprintModels.DataType));

            // sort nested objects
            BlueprintUnitOfWork.DataTypes.SortNestedObjects(new List<BlueprintModels.DataType> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.DataType> ToBlueprintObjects(IEnumerable<DbEntities.DataType> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.DataType> result = (IEnumerable<BlueprintModels.DataType>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.DataType>),
                typeof(IEnumerable<BlueprintModels.DataType>));

            // sort nested objects
            BlueprintUnitOfWork.DataTypes.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.DataType> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.DataType>),
                typeof(IEnumerable<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.DataType> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.DataType> result = (IEnumerable<BlueprintModels.DataType>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.DataType, BlueprintModels.DataType>>),
                typeof(IEnumerable<BlueprintModels.DataType>));

            // sort nested objects
            BlueprintUnitOfWork.DataTypes.SortNestedObjects(result);

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
        public override BlueprintModels.DataType GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string dataTypeName = (string)keyValues[1];
            return GetByModelNameDataTypeName(
                modelName,
                dataTypeName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.DataType> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string dataTypeName = (string)keyValues[1];
            return await GetByModelNameDataTypeNameAsync(
                modelName,
                dataTypeName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.DataType> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a dataType to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.DataType, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptModelId.ToString() + "|"
                + (e.DataTypeName != null ? e.DataTypeName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.DataType, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.DataTypeId == default || e.DataTypeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.DataType fromBlueprintObj,
            IEnumerable<BlueprintModels.DataType> toObjects)
        {
            foreach (BlueprintModels.DataType obj in toObjects)
            {
                // populate the primary key within the object
                obj.DataTypeId = fromBlueprintObj.DataTypeId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.DataType> items)
        {
            foreach (BlueprintModels.DataType item in items)
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
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.DataType> items)
        {
            foreach (BlueprintModels.DataType item in items)
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
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.DataType> items)
        {
            foreach (BlueprintModels.DataType item in items)
            {
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
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.DataType> items)
        {
            foreach (BlueprintModels.DataType item in items)
            {
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
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void RenumberNestedObjects(
            IEnumerable<BlueprintModels.DataType> items,
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
            IEnumerable<BlueprintModels.DataType> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public BlueprintModels.DataType GetByDataTypeId(int dataTypeId)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                DbUnitOfWork.DataTypes.GetRichEntityByDataTypeId(
                    dataTypeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.DataType> GetByDataTypeIdAsync(int dataTypeId)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                await DbUnitOfWork.DataTypes.GetRichEntityByDataTypeIdAsync(
                    dataTypeId);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public BlueprintModels.DataType GetByModelNameDataTypeName(
            string modelName,
            string dataTypeName)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                DbUnitOfWork.DataTypes.GetRichEntityByModelNameDataTypeName(
                    modelName,
                    dataTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.DataType> GetByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                await DbUnitOfWork.DataTypes.GetRichEntityByModelNameDataTypeNameAsync(
                    modelName,
                    dataTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public BlueprintModels.DataType GetByConceptModelIdDataTypeName(
            int conceptModelId,
            string dataTypeName)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                DbUnitOfWork.DataTypes.GetRichEntityByConceptModelIdDataTypeName(
                    conceptModelId,
                    dataTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.DataType> GetByConceptModelIdDataTypeNameAsync(
            int conceptModelId,
            string dataTypeName)
        {
            // get the rich entity
            DbEntities.DataType dataType =
                await DbUnitOfWork.DataTypes.GetRichEntityByConceptModelIdDataTypeNameAsync(
                    conceptModelId,
                    dataTypeName);

            // transform the rich entity and return the result
            return ToBlueprintObject(dataType);
        }

        #endregion
    }
}

/****************************
 * DataTypeRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.EntityRepositories
{
    /// <summary>
    /// Repository class for the <see cref="DbEntities.DataType" /> entity
    /// </summary>
    public partial class DataTypeRepository
        : ConceptMetaDbRepository<DbEntities.DataType>,
        IDataTypeRepository
    {

        #region Constructors
        public DataTypeRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately within each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified dataType
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(DbEntities.DataType dataType)
        {
            return new object[] { dataType.DataTypeId };
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the dataType with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.DataType, bool>> GetPrimaryKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.DataTypeId == (int)keyValues[0]) && (e.DataTypeId != default && e.DataTypeId != default(int)));
        }

        /// <summary>
        /// Gets the primary key predicate that can be used to identify the specified dataType
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.DataType, bool>> GetPrimaryKeyPredicate(DbEntities.DataType dataType)
        {
            return (e => 
                (e.DataTypeId == dataType.DataTypeId) && (e.DataTypeId != default && e.DataTypeId != default(int)));
        }

        /// <summary>
        /// Gets the logical key predicate that can be used to identify the specified dataType
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.DataType, bool>> GetLogicalKeyPredicate(DbEntities.DataType dataType)
        {
            return (e => 
                (e.ConceptModelId == dataType.ConceptModelId) && 
                (e.DataTypeName == dataType.DataTypeName));
        }

        /// <summary>
        /// Gets the object array of business key values that can be used to identify the specified dataType
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override object[] GetBusinessKeyObjectArray(DbEntities.DataType dataType)
        {
            return new object[] { dataType.ModelName, dataType.DataTypeName };
        }

        /// <summary>
        /// Gets the business key predicate that can be used to identify the dataType with the specified key values
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        protected override Expression<Func<DbEntities.DataType, bool>> GetBusinessKeyPredicate(params object[] keyValues)
        {
            return (e => 
                (e.ModelName == (string)keyValues[0]) && (e.ModelName != default && e.ModelName != "") && 
                (e.DataTypeName == (string)keyValues[1]) && (e.DataTypeName != default && e.DataTypeName != ""));
        }

        /// <summary>
        /// Copies non-primary key field values from one instance to another
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        protected override void CopyNonPkFields(
            DbEntities.DataType from,
            DbEntities.DataType to)
        {
            to.ConceptModelId = from.ConceptModelId;
            to.DataTypeName = from.DataTypeName;
            to.SqlServerDataType = from.SqlServerDataType;
            to.OracleDataType = from.OracleDataType;
            to.MySqlDataType = from.MySqlDataType;
            to.MongoDbDataType = from.MongoDbDataType;
            to.DotNetDataType = from.DotNetDataType;
            to.JavaDataType = from.JavaDataType;
            to.XmlDataType = from.XmlDataType;
            to.ExampleValueAsString = from.ExampleValueAsString;
            to.JsonDataType = from.JsonDataType;
            to.JsonFormat = from.JsonFormat;
            to.OpenApiDataType = from.OpenApiDataType;
            to.OpenApiFormat = from.OpenApiFormat;
            to.ErsDataType = from.ErsDataType;
            to.BasicDataType = from.BasicDataType;
            to.MinLength = from.MinLength;
            to.MaxLength = from.MaxLength;
            to.MinValue = from.MinValue;
            to.MaxValue = from.MaxValue;
            to.TotalDigits = from.TotalDigits;
            to.DecimalPlaces = from.DecimalPlaces;
            to.DatePrecision = from.DatePrecision;
            to.HasLength = from.HasLength;
            to.HasTotalDigits = from.HasTotalDigits;
            to.HasDecimalPlaces = from.HasDecimalPlaces;
            to.HasIdentity = from.HasIdentity;
            to.HasDatePrecision = from.HasDatePrecision;
        }

        /// <summary>
        /// Adds parent entities to the set of items to be returned by "Rich Entity" queries
        /// </summary>
        protected override void PopulateRichEntityIncludes()
        {
            // add the paths to included entities
            RichEntityIncludes.Add("ConceptModel");
        }

        /// <summary>
        /// Returns a boolean reflecting whether the entity has references to child objects.  If it does, it will need special treatment
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        protected override bool EntityHasReferencesToChildObjects(DbEntities.DataType dataType)
        {
            return false;
        }

        /// <summary>
        /// Populates a sterilised copy of the entity - sterilised in the sense that references to child objects will have been removed
        /// </summary>
        /// <param name="dataType"></param>
        /// <param name="sterilisedEntity"></param>
        protected override void PopulateSterilisedEntity(
            DbEntities.DataType dataType,
            out DbEntities.DataType sterilisedEntity)
        {
            sterilisedEntity = null;
        }

        #endregion

        #region Methods that must be implemented separately within each concrete class

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool PopulateMissingPrimaryKeyIfKnown(DbEntities.DataType e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.DataTypeId == default || e.DataTypeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int dataTypeId = GetDataTypeIdByConceptModelIdDataTypeName(
                    e.ConceptModelId,
                    e.DataTypeName);

                // test whether the item has been found within the database
                if (dataTypeId != default && dataTypeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.DataTypeId = dataTypeId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override async Task<bool> PopulateMissingPrimaryKeyIfKnownAsync(DbEntities.DataType e)
        {
            bool result = false;

            // test whether primary key is already set
            if ((e.DataTypeId == default || e.DataTypeId == default(int)))
            {
                // primary key is not set - find the item within the database, using the logical key
                int dataTypeId = await GetDataTypeIdByConceptModelIdDataTypeNameAsync(
                    e.ConceptModelId,
                    e.DataTypeName);

                // test whether the item has been found within the database
                if (dataTypeId != default && dataTypeId != default(int))
                {
                    // item has been found in the database - so populate the primary key field
                    e.DataTypeId = dataTypeId;
                    result = true;
                }
            }
            return result;
        }

        /// <summary>
        /// Populates foreign key fields using unique key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<DbEntities.DataType> items)
        {
            foreach (DbEntities.DataType item in items)
            {
                // populate foreign key fields
                if (item.ConceptModel != null)
                {
                    if (item.ConceptModel.ConceptModelId != default && item.ConceptModel.ConceptModelId != default(int))
                    {
                        item.ConceptModelId = item.ConceptModel.ConceptModelId;
                    }
                }
            }
        }

        /// <summary>
        /// Copies unique key values to child objects
        /// </summary>
        /// <param name="items"></param>
        public override void CopyUniqueKeyValuesToChildren(IEnumerable<DbEntities.DataType> items)
        {
            foreach (DbEntities.DataType item in items)
            {
                // populate foreign key fields within child objects (if any)
                if (item.Concepts != null)
                {
                    foreach (DbEntities.Concept childItem in item.Concepts)
                    {
                        if (item.DataTypeId != default && item.DataTypeId != default(int))
                        {
                            childItem.DataTypeId = item.DataTypeId;
                        }
                    }
                }
                if (item.Enumerations != null)
                {
                    foreach (DbEntities.Enumeration childItem in item.Enumerations)
                    {
                        if (item.DataTypeId != default && item.DataTypeId != default(int))
                        {
                            childItem.DataTypeId = item.DataTypeId;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a dataType to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<DbEntities.DataType, string> GetLogicalKeyFunction()
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
        public override Func<DbEntities.DataType, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.DataTypeId == default || e.DataTypeId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from an entity to each object within a collection
        /// </summary>
        /// <param name="fromEntity">the entity from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            DbEntities.DataType fromEntity,
            IEnumerable<DbEntities.DataType> toObjects)
        {
            foreach (DbEntities.DataType obj in toObjects)
            {
                // populate the primary key within the object
                obj.DataTypeId = fromEntity.DataTypeId;
            }
        }

        #endregion

        #region Methods that return Ids

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public int GetDataTypeIdByModelNameDataTypeName(
            string modelName,
            string dataTypeName)
        {
            return (Find(
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName)))
                .Select(dataType => dataType.DataTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<int> GetDataTypeIdByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName)
        {
            return (await FindAsync(
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName)))
                .Select(dataType => dataType.DataTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public int GetDataTypeIdByConceptModelIdDataTypeName(
            int conceptModelId,
            string dataTypeName)
        {
            return (Find(
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName)))
                .Select(dataType => dataType.DataTypeId)
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<int> GetDataTypeIdByConceptModelIdDataTypeNameAsync(
            int conceptModelId,
            string dataTypeName)
        {
            return (await FindAsync(
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName)))
                .Select(dataType => dataType.DataTypeId)
                .FirstOrDefault();
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public DbEntities.DataType GetByDataTypeId(int? dataTypeId)
        {
            return (Find (
                    dataType =>
                        (dataType.DataTypeId == dataTypeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetByDataTypeIdAsync(int? dataTypeId)
        {
            return (await FindAsync (
                    dataType =>
                        (dataType.DataTypeId == dataTypeId)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public DbEntities.DataType GetRichEntityByDataTypeId(int? dataTypeId)
        {
            return (Find(
                    dataType =>
                        (dataType.DataTypeId == dataTypeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetRichEntityByDataTypeIdAsync(int? dataTypeId)
        {
            return (await FindAsync(
                    dataType =>
                        (dataType.DataTypeId == dataTypeId),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public DbEntities.DataType GetByModelNameDataTypeName(
            string modelName,
            string dataTypeName)
        {
            return (Find (
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName)
        {
            return (await FindAsync (
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public DbEntities.DataType GetRichEntityByModelNameDataTypeName(
            string modelName,
            string dataTypeName)
        {
            return (Find(
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetRichEntityByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName)
        {
            return (await FindAsync(
                    dataType =>
                        (dataType.ConceptModel.ModelName == modelName)
                        && (dataType.DataTypeName == dataTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public DbEntities.DataType GetByConceptModelIdDataTypeName(
            int? conceptModelId,
            string dataTypeName)
        {
            return (Find (
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetByConceptModelIdDataTypeNameAsync(
            int? conceptModelId,
            string dataTypeName)
        {
            return (await FindAsync (
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName)))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public DbEntities.DataType GetRichEntityByConceptModelIdDataTypeName(
            int? conceptModelId,
            string dataTypeName)
        {
            return (Find(
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        public async Task<DbEntities.DataType> GetRichEntityByConceptModelIdDataTypeNameAsync(
            int? conceptModelId,
            string dataTypeName)
        {
            return (await FindAsync(
                    dataType =>
                        (dataType.ConceptModelId == conceptModelId)
                        && (dataType.DataTypeName == dataTypeName),
                    RichEntityIncludes))
                .FirstOrDefault();
        }

        #endregion
    }
}

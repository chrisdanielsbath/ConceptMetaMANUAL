/****************************
 * IDataTypeRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.DataType" /> entity
    /// </summary>
    public partial interface IDataTypeRepository
        : IConceptMetaDbRepository<DbEntities.DataType>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        int GetDataTypeIdByModelNameDataTypeName(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<int> GetDataTypeIdByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        int GetDataTypeIdByConceptModelIdDataTypeName(
            int conceptModelId,
            string dataTypeName);

        /// <summary>
        /// Gets the DataTypeId of the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<int> GetDataTypeIdByConceptModelIdDataTypeNameAsync(
            int conceptModelId,
            string dataTypeName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        DbEntities.DataType GetByDataTypeId(int? dataTypeId);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetByDataTypeIdAsync(int? dataTypeId);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        DbEntities.DataType GetRichEntityByDataTypeId(int? dataTypeId);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetRichEntityByDataTypeIdAsync(int? dataTypeId);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        DbEntities.DataType GetByModelNameDataTypeName(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        DbEntities.DataType GetRichEntityByModelNameDataTypeName(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetRichEntityByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        DbEntities.DataType GetByConceptModelIdDataTypeName(
            int? conceptModelId,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetByConceptModelIdDataTypeNameAsync(
            int? conceptModelId,
            string dataTypeName);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        DbEntities.DataType GetRichEntityByConceptModelIdDataTypeName(
            int? conceptModelId,
            string dataTypeName);

        /// <summary>
        /// Gets the unique Rich DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.DataType> GetRichEntityByConceptModelIdDataTypeNameAsync(
            int? conceptModelId,
            string dataTypeName);

        #endregion
    }
}

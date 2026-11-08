/****************************
 * IDataTypeBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.DataType" /> entity
    /// </summary>
    public partial interface IDataTypeBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.DataType>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        BlueprintModels.DataType GetByDataTypeId(int dataTypeId);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified DataTypeId
        /// </summary>
        /// <param name="dataTypeId"></param>
        /// <returns></returns>
        Task<BlueprintModels.DataType> GetByDataTypeIdAsync(int dataTypeId);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        BlueprintModels.DataType GetByModelNameDataTypeName(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ModelName, DataTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<BlueprintModels.DataType> GetByModelNameDataTypeNameAsync(
            string modelName,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        BlueprintModels.DataType GetByConceptModelIdDataTypeName(
            int conceptModelId,
            string dataTypeName);

        /// <summary>
        /// Gets the unique DataType that is identified by the specified ConceptModelId, DataTypeName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        Task<BlueprintModels.DataType> GetByConceptModelIdDataTypeNameAsync(
            int conceptModelId,
            string dataTypeName);

        #endregion
    }
}

/****************************
 * IConceptSubTypeBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptSubType" /> entity
    /// </summary>
    public partial interface IConceptSubTypeBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptSubType>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubType GetByConceptSubTypeId(int conceptSubTypeId);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubType> GetByConceptSubTypeIdAsync(int conceptSubTypeId);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubType GetByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubType> GetByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubType GetByConceptIdSubTypeName(
            int conceptId,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubType> GetByConceptIdSubTypeNameAsync(
            int conceptId,
            string subTypeName);

        #endregion
    }
}

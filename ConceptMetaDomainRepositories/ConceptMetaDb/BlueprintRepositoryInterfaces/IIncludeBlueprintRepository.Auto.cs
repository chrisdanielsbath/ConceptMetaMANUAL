/****************************
 * IIncludeBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.Include" /> entity
    /// </summary>
    public partial interface IIncludeBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.Include>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        BlueprintModels.Include GetByIncludeId(int includeId);

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        Task<BlueprintModels.Include> GetByIncludeIdAsync(int includeId);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        BlueprintModels.Include GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<BlueprintModels.Include> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        BlueprintModels.Include GetByConceptIdItemValue(
            int conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<BlueprintModels.Include> GetByConceptIdItemValueAsync(
            int conceptId,
            string itemValue);

        #endregion
    }
}

/****************************
 * IQualifierBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.Qualifier" /> entity
    /// </summary>
    public partial interface IQualifierBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.Qualifier>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        BlueprintModels.Qualifier GetByQualifierId(int qualifierId);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        Task<BlueprintModels.Qualifier> GetByQualifierIdAsync(int qualifierId);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        BlueprintModels.Qualifier GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<BlueprintModels.Qualifier> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        BlueprintModels.Qualifier GetByConceptIdItemValue(
            int conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<BlueprintModels.Qualifier> GetByConceptIdItemValueAsync(
            int conceptId,
            string itemValue);

        #endregion
    }
}

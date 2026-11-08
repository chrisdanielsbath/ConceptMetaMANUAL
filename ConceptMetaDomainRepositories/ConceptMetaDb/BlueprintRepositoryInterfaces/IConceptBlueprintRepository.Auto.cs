/****************************
 * IConceptBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.Concept" /> entity
    /// </summary>
    public partial interface IConceptBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.Concept>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        BlueprintModels.Concept GetByConceptId(int conceptId);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<BlueprintModels.Concept> GetByConceptIdAsync(int conceptId);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        BlueprintModels.Concept GetByModelNameConceptName(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<BlueprintModels.Concept> GetByModelNameConceptNameAsync(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        BlueprintModels.Concept GetByConceptModelIdConceptName(
            int conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<BlueprintModels.Concept> GetByConceptModelIdConceptNameAsync(
            int conceptModelId,
            string conceptName);

        #endregion
    }
}

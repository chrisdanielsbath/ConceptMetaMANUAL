/****************************
 * IEnumerationBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.Enumeration" /> entity
    /// </summary>
    public partial interface IEnumerationBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.Enumeration>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        BlueprintModels.Enumeration GetByEnumerationId(int enumerationId);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        Task<BlueprintModels.Enumeration> GetByEnumerationIdAsync(int enumerationId);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        BlueprintModels.Enumeration GetByModelNameEnumerationName(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<BlueprintModels.Enumeration> GetByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        BlueprintModels.Enumeration GetByConceptModelIdEnumerationName(
            int conceptModelId,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<BlueprintModels.Enumeration> GetByConceptModelIdEnumerationNameAsync(
            int conceptModelId,
            string enumerationName);

        #endregion
    }
}

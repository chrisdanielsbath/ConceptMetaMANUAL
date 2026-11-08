/****************************
 * IConceptRefBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptRef" /> entity
    /// </summary>
    public partial interface IConceptRefBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptRef>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptRef GetByConceptRefId(int conceptRefId);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptRef> GetByConceptRefIdAsync(int conceptRefId);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptRef GetByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptRef> GetByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptRef GetByConceptIdPropertyName(
            int conceptId,
            string propertyName);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptRef> GetByConceptIdPropertyNameAsync(
            int conceptId,
            string propertyName);

        #endregion
    }
}

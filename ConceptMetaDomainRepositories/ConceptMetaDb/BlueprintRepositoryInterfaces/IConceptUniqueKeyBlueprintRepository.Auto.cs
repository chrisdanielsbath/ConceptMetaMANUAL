/****************************
 * IConceptUniqueKeyBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptUniqueKey" /> entity
    /// </summary>
    public partial interface IConceptUniqueKeyBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptUniqueKey>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKey GetByConceptUniqueKeyId(int conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKey> GetByConceptUniqueKeyIdAsync(int conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKey GetByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKey> GetByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKey GetByConceptIdUniqueKeyName(
            int conceptId,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKey> GetByConceptIdUniqueKeyNameAsync(
            int conceptId,
            string uniqueKeyName);

        #endregion
    }
}

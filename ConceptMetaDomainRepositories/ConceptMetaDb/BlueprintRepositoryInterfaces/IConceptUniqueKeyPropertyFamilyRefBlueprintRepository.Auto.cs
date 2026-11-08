/****************************
 * IConceptUniqueKeyPropertyFamilyRefBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    public partial interface IConceptUniqueKeyPropertyFamilyRefBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyPropertyFamilyRefId(int conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyPropertyFamilyRefIdAsync(int conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyIdConceptPropertyFamilyId(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId);

        #endregion
    }
}

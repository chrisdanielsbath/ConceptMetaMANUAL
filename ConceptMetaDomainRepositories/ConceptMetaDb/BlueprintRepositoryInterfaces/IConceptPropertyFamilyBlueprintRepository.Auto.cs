/****************************
 * IConceptPropertyFamilyBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptPropertyFamily" /> entity
    /// </summary>
    public partial interface IConceptPropertyFamilyBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptPropertyFamily>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptPropertyFamily GetByConceptPropertyFamilyId(int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptPropertyFamily> GetByConceptPropertyFamilyIdAsync(int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptPropertyFamily GetByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptPropertyFamily> GetByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptPropertyFamily GetByConceptIdPropertyFamilyName(
            int conceptId,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptPropertyFamily> GetByConceptIdPropertyFamilyNameAsync(
            int conceptId,
            string propertyFamilyName);

        #endregion
    }
}

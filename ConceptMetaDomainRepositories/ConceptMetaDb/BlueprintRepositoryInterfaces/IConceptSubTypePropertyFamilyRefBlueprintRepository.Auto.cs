/****************************
 * IConceptSubTypePropertyFamilyRefBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    public partial interface IConceptSubTypePropertyFamilyRefBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.ConceptSubTypePropertyFamilyRef>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubTypePropertyFamilyRef GetByConceptSubTypePropertyFamilyRefId(int conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypePropertyFamilyRefIdAsync(int conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubTypePropertyFamilyRef GetByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptSubTypePropertyFamilyRef GetByConceptSubTypeIdConceptPropertyFamilyId(
            int conceptSubTypeId,
            int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int conceptSubTypeId,
            int conceptPropertyFamilyId);

        #endregion
    }
}

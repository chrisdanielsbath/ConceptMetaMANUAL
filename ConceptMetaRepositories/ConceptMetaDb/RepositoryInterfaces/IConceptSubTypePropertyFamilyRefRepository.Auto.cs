/****************************
 * IConceptSubTypePropertyFamilyRefRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptSubTypePropertyFamilyRef" /> entity
    /// </summary>
    public partial interface IConceptSubTypePropertyFamilyRefRepository
        : IConceptMetaDbRepository<DbEntities.ConceptSubTypePropertyFamilyRef>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        int GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<int> GetConceptSubTypePropertyFamilyRefIdByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        int GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyId(
            int conceptSubTypeId,
            int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the ConceptSubTypePropertyFamilyRefId of the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<int> GetConceptSubTypePropertyFamilyRefIdByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int conceptSubTypeId,
            int conceptPropertyFamilyId);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptSubTypePropertyFamilyRef GetByConceptSubTypePropertyFamilyRefId(int? conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypePropertyFamilyRefIdAsync(int? conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByConceptSubTypePropertyFamilyRefId(int? conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypePropertyFamilyRefId
        /// </summary>
        /// <param name="conceptSubTypePropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByConceptSubTypePropertyFamilyRefIdAsync(int? conceptSubTypePropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubTypePropertyFamilyRef GetByModelNameConceptNameSubTypeNamePropertyFamilyName(
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
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string subTypeName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ModelName, ConceptName, SubTypeName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByModelNameConceptNameSubTypeNamePropertyFamilyNameAsync(
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
        DbEntities.ConceptSubTypePropertyFamilyRef GetByConceptSubTypeIdConceptPropertyFamilyId(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        DbEntities.ConceptSubTypePropertyFamilyRef GetRichEntityByConceptSubTypeIdConceptPropertyFamilyId(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptSubTypePropertyFamilyRef that is identified by the specified ConceptSubTypeId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubTypePropertyFamilyRef> GetRichEntityByConceptSubTypeIdConceptPropertyFamilyIdAsync(
            int? conceptSubTypeId,
            int? conceptPropertyFamilyId);

        #endregion
    }
}

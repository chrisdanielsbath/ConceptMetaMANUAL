/****************************
 * IConceptUniqueKeyPropertyFamilyRefRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptUniqueKeyPropertyFamilyRef" /> entity
    /// </summary>
    public partial interface IConceptUniqueKeyPropertyFamilyRefRepository
        : IConceptMetaDbRepository<DbEntities.ConceptUniqueKeyPropertyFamilyRef>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        int GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<int> GetConceptUniqueKeyPropertyFamilyRefIdByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        int GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyId(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId);

        /// <summary>
        /// Gets the ConceptUniqueKeyPropertyFamilyRefId of the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<int> GetConceptUniqueKeyPropertyFamilyRefIdByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int conceptUniqueKeyId,
            int conceptPropertyFamilyId);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyPropertyFamilyRefId(int? conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyPropertyFamilyRefIdAsync(int? conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByConceptUniqueKeyPropertyFamilyRefId(int? conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyPropertyFamilyRefId
        /// </summary>
        /// <param name="conceptUniqueKeyPropertyFamilyRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByConceptUniqueKeyPropertyFamilyRefIdAsync(int? conceptUniqueKeyPropertyFamilyRefId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
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
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string uniqueKeyName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ModelName, ConceptName, UniqueKeyName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByModelNameConceptNameUniqueKeyNamePropertyFamilyNameAsync(
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
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetByConceptUniqueKeyIdConceptPropertyFamilyId(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKeyPropertyFamilyRef GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyId(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKeyPropertyFamilyRef that is identified by the specified ConceptUniqueKeyId, ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKeyPropertyFamilyRef> GetRichEntityByConceptUniqueKeyIdConceptPropertyFamilyIdAsync(
            int? conceptUniqueKeyId,
            int? conceptPropertyFamilyId);

        #endregion
    }
}

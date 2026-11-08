/****************************
 * IConceptPropertyFamilyRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptPropertyFamily" /> entity
    /// </summary>
    public partial interface IConceptPropertyFamilyRepository
        : IConceptMetaDbRepository<DbEntities.ConceptPropertyFamily>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        int GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<int> GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        int GetConceptPropertyFamilyIdByConceptIdPropertyFamilyName(
            int conceptId,
            string propertyFamilyName);

        /// <summary>
        /// Gets the ConceptPropertyFamilyId of the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<int> GetConceptPropertyFamilyIdByConceptIdPropertyFamilyNameAsync(
            int conceptId,
            string propertyFamilyName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetByConceptPropertyFamilyId(int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptPropertyFamily> GetByConceptPropertyFamilyIdAsync(int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetRichEntityByConceptPropertyFamilyId(int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptPropertyFamilyId
        /// </summary>
        /// <param name="conceptPropertyFamilyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptPropertyFamily> GetRichEntityByConceptPropertyFamilyIdAsync(int? conceptPropertyFamilyId);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetByModelNameConceptNamePropertyFamilyName(
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
        Task<DbEntities.ConceptPropertyFamily> GetByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetRichEntityByModelNameConceptNamePropertyFamilyName(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ModelName, ConceptName, PropertyFamilyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptPropertyFamily> GetRichEntityByModelNameConceptNamePropertyFamilyNameAsync(
            string modelName,
            string conceptName,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetByConceptIdPropertyFamilyName(
            int? conceptId,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptPropertyFamily> GetByConceptIdPropertyFamilyNameAsync(
            int? conceptId,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        DbEntities.ConceptPropertyFamily GetRichEntityByConceptIdPropertyFamilyName(
            int? conceptId,
            string propertyFamilyName);

        /// <summary>
        /// Gets the unique Rich ConceptPropertyFamily that is identified by the specified ConceptId, PropertyFamilyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptPropertyFamily> GetRichEntityByConceptIdPropertyFamilyNameAsync(
            int? conceptId,
            string propertyFamilyName);

        #endregion
    }
}

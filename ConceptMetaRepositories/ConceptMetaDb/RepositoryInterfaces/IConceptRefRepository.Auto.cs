/****************************
 * IConceptRefRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptRef" /> entity
    /// </summary>
    public partial interface IConceptRefRepository
        : IConceptMetaDbRepository<DbEntities.ConceptRef>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        int GetConceptRefIdByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<int> GetConceptRefIdByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        int GetConceptRefIdByConceptIdPropertyName(
            int conceptId,
            string propertyName);

        /// <summary>
        /// Gets the ConceptRefId of the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<int> GetConceptRefIdByConceptIdPropertyNameAsync(
            int conceptId,
            string propertyName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetByConceptRefId(int? conceptRefId);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptRef> GetByConceptRefIdAsync(int? conceptRefId);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetRichEntityByConceptRefId(int? conceptRefId);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptRef> GetRichEntityByConceptRefIdAsync(int? conceptRefId);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetByModelNameConceptNamePropertyName(
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
        Task<DbEntities.ConceptRef> GetByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetRichEntityByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptRef> GetRichEntityByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetByConceptIdPropertyName(
            int? conceptId,
            string propertyName);

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptRef> GetByConceptIdPropertyNameAsync(
            int? conceptId,
            string propertyName);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        DbEntities.ConceptRef GetRichEntityByConceptIdPropertyName(
            int? conceptId,
            string propertyName);

        /// <summary>
        /// Gets the unique Rich ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptRef> GetRichEntityByConceptIdPropertyNameAsync(
            int? conceptId,
            string propertyName);

        #endregion
    }
}

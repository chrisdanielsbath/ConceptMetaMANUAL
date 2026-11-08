/****************************
 * IConceptUniqueKeyRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptUniqueKey" /> entity
    /// </summary>
    public partial interface IConceptUniqueKeyRepository
        : IConceptMetaDbRepository<DbEntities.ConceptUniqueKey>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        int GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<int> GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        int GetConceptUniqueKeyIdByConceptIdUniqueKeyName(
            int conceptId,
            string uniqueKeyName);

        /// <summary>
        /// Gets the ConceptUniqueKeyId of the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<int> GetConceptUniqueKeyIdByConceptIdUniqueKeyNameAsync(
            int conceptId,
            string uniqueKeyName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetByConceptUniqueKeyId(int? conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKey> GetByConceptUniqueKeyIdAsync(int? conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetRichEntityByConceptUniqueKeyId(int? conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptUniqueKeyId
        /// </summary>
        /// <param name="conceptUniqueKeyId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKey> GetRichEntityByConceptUniqueKeyIdAsync(int? conceptUniqueKeyId);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetByModelNameConceptNameUniqueKeyName(
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
        Task<DbEntities.ConceptUniqueKey> GetByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetRichEntityByModelNameConceptNameUniqueKeyName(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ModelName, ConceptName, UniqueKeyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKey> GetRichEntityByModelNameConceptNameUniqueKeyNameAsync(
            string modelName,
            string conceptName,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetByConceptIdUniqueKeyName(
            int? conceptId,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKey> GetByConceptIdUniqueKeyNameAsync(
            int? conceptId,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        DbEntities.ConceptUniqueKey GetRichEntityByConceptIdUniqueKeyName(
            int? conceptId,
            string uniqueKeyName);

        /// <summary>
        /// Gets the unique Rich ConceptUniqueKey that is identified by the specified ConceptId, UniqueKeyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="uniqueKeyName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptUniqueKey> GetRichEntityByConceptIdUniqueKeyNameAsync(
            int? conceptId,
            string uniqueKeyName);

        #endregion
    }
}

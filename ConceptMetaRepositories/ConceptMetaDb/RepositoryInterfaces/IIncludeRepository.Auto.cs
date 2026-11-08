/****************************
 * IIncludeRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.Include" /> entity
    /// </summary>
    public partial interface IIncludeRepository
        : IConceptMetaDbRepository<DbEntities.Include>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        int GetIncludeIdByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<int> GetIncludeIdByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        int GetIncludeIdByConceptIdItemValue(
            int conceptId,
            string itemValue);

        /// <summary>
        /// Gets the IncludeId of the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<int> GetIncludeIdByConceptIdItemValueAsync(
            int conceptId,
            string itemValue);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        DbEntities.Include GetByIncludeId(int? includeId);

        /// <summary>
        /// Gets the unique Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetByIncludeIdAsync(int? includeId);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        DbEntities.Include GetRichEntityByIncludeId(int? includeId);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified IncludeId
        /// </summary>
        /// <param name="includeId"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetRichEntityByIncludeIdAsync(int? includeId);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Include GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Include GetRichEntityByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetRichEntityByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Include GetByConceptIdItemValue(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Include GetRichEntityByConceptIdItemValue(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Include that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Include> GetRichEntityByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue);

        #endregion
    }
}

/****************************
 * IConceptRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.Concept" /> entity
    /// </summary>
    public partial interface IConceptRepository
        : IConceptMetaDbRepository<DbEntities.Concept>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        int GetConceptIdByModelNameConceptName(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<int> GetConceptIdByModelNameConceptNameAsync(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        int GetConceptIdByConceptModelIdConceptName(
            int conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<int> GetConceptIdByConceptModelIdConceptNameAsync(
            int conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        int GetConceptIdByConceptId(int conceptId);

        /// <summary>
        /// Gets the ConceptId of the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<int> GetConceptIdByConceptIdAsync(int conceptId);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        DbEntities.Concept GetByConceptId(int? conceptId);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetByConceptIdAsync(int? conceptId);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        DbEntities.Concept GetRichEntityByConceptId(int? conceptId);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetRichEntityByConceptIdAsync(int? conceptId);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        DbEntities.Concept GetByModelNameConceptName(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetByModelNameConceptNameAsync(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        DbEntities.Concept GetRichEntityByModelNameConceptName(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetRichEntityByModelNameConceptNameAsync(
            string modelName,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        DbEntities.Concept GetByConceptModelIdConceptName(
            int? conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetByConceptModelIdConceptNameAsync(
            int? conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        DbEntities.Concept GetRichEntityByConceptModelIdConceptName(
            int? conceptModelId,
            string conceptName);

        /// <summary>
        /// Gets the unique Rich Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        Task<DbEntities.Concept> GetRichEntityByConceptModelIdConceptNameAsync(
            int? conceptModelId,
            string conceptName);

        #endregion
    }
}

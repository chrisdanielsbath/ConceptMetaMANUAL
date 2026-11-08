/****************************
 * IEnumerationRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.Enumeration" /> entity
    /// </summary>
    public partial interface IEnumerationRepository
        : IConceptMetaDbRepository<DbEntities.Enumeration>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        int GetEnumerationIdByModelNameEnumerationName(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<int> GetEnumerationIdByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        int GetEnumerationIdByConceptModelIdEnumerationName(
            int conceptModelId,
            string enumerationName);

        /// <summary>
        /// Gets the EnumerationId of the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<int> GetEnumerationIdByConceptModelIdEnumerationNameAsync(
            int conceptModelId,
            string enumerationName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetByEnumerationId(int? enumerationId);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetByEnumerationIdAsync(int? enumerationId);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetRichEntityByEnumerationId(int? enumerationId);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified EnumerationId
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetRichEntityByEnumerationIdAsync(int? enumerationId);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetByModelNameEnumerationName(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetRichEntityByModelNameEnumerationName(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ModelName, EnumerationName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetRichEntityByModelNameEnumerationNameAsync(
            string modelName,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetByConceptModelIdEnumerationName(
            int? conceptModelId,
            string enumerationName);

        /// <summary>
        /// Gets the unique Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetByConceptModelIdEnumerationNameAsync(
            int? conceptModelId,
            string enumerationName);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        DbEntities.Enumeration GetRichEntityByConceptModelIdEnumerationName(
            int? conceptModelId,
            string enumerationName);

        /// <summary>
        /// Gets the unique Rich Enumeration that is identified by the specified ConceptModelId, EnumerationName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        Task<DbEntities.Enumeration> GetRichEntityByConceptModelIdEnumerationNameAsync(
            int? conceptModelId,
            string enumerationName);

        #endregion
    }
}

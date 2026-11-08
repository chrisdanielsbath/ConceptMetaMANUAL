/****************************
 * IEnumerationMemberRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.EnumerationMember" /> entity
    /// </summary>
    public partial interface IEnumerationMemberRepository
        : IConceptMetaDbRepository<DbEntities.EnumerationMember>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        int GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<int> GetEnumerationMemberIdByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        int GetEnumerationMemberIdByEnumerationIdEnumeratedValue(
            int enumerationId,
            string enumeratedValue);

        /// <summary>
        /// Gets the EnumerationMemberId of the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<int> GetEnumerationMemberIdByEnumerationIdEnumeratedValueAsync(
            int enumerationId,
            string enumeratedValue);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetByEnumerationMemberId(int? enumerationMemberId);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetByEnumerationMemberIdAsync(int? enumerationMemberId);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetRichEntityByEnumerationMemberId(int? enumerationMemberId);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetRichEntityByEnumerationMemberIdAsync(int? enumerationMemberId);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetRichEntityByModelNameEnumerationNameEnumeratedValue(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetRichEntityByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetByEnumerationIdEnumeratedValue(
            int? enumerationId,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetByEnumerationIdEnumeratedValueAsync(
            int? enumerationId,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        DbEntities.EnumerationMember GetRichEntityByEnumerationIdEnumeratedValue(
            int? enumerationId,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique Rich EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<DbEntities.EnumerationMember> GetRichEntityByEnumerationIdEnumeratedValueAsync(
            int? enumerationId,
            string enumeratedValue);

        #endregion
    }
}

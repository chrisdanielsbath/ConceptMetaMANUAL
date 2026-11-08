/****************************
 * IEnumerationMemberBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.EnumerationMember" /> entity
    /// </summary>
    public partial interface IEnumerationMemberBlueprintRepository
        : IReadWriteBlueprintRepository<BlueprintModels.EnumerationMember>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        BlueprintModels.EnumerationMember GetByEnumerationMemberId(int enumerationMemberId);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationMemberId
        /// </summary>
        /// <param name="enumerationMemberId"></param>
        /// <returns></returns>
        Task<BlueprintModels.EnumerationMember> GetByEnumerationMemberIdAsync(int enumerationMemberId);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified ModelName, EnumerationName, EnumeratedValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="enumerationName"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        BlueprintModels.EnumerationMember GetByModelNameEnumerationNameEnumeratedValue(
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
        Task<BlueprintModels.EnumerationMember> GetByModelNameEnumerationNameEnumeratedValueAsync(
            string modelName,
            string enumerationName,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        BlueprintModels.EnumerationMember GetByEnumerationIdEnumeratedValue(
            int enumerationId,
            string enumeratedValue);

        /// <summary>
        /// Gets the unique EnumerationMember that is identified by the specified EnumerationId, EnumeratedValue
        /// </summary>
        /// <param name="enumerationId"></param>
        /// <param name="enumeratedValue"></param>
        /// <returns></returns>
        Task<BlueprintModels.EnumerationMember> GetByEnumerationIdEnumeratedValueAsync(
            int enumerationId,
            string enumeratedValue);

        #endregion
    }
}

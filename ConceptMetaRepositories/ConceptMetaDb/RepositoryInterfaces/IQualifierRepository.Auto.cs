/****************************
 * IQualifierRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.Qualifier" /> entity
    /// </summary>
    public partial interface IQualifierRepository
        : IConceptMetaDbRepository<DbEntities.Qualifier>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        int GetQualifierIdByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<int> GetQualifierIdByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        int GetQualifierIdByConceptIdItemValue(
            int conceptId,
            string itemValue);

        /// <summary>
        /// Gets the QualifierId of the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<int> GetQualifierIdByConceptIdItemValueAsync(
            int conceptId,
            string itemValue);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetByQualifierId(int? qualifierId);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetByQualifierIdAsync(int? qualifierId);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetRichEntityByQualifierId(int? qualifierId);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified QualifierId
        /// </summary>
        /// <param name="qualifierId"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetRichEntityByQualifierIdAsync(int? qualifierId);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetRichEntityByModelNameConceptNameItemValue(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ModelName, ConceptName, ItemValue
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetRichEntityByModelNameConceptNameItemValueAsync(
            string modelName,
            string conceptName,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetByConceptIdItemValue(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        DbEntities.Qualifier GetRichEntityByConceptIdItemValue(
            int? conceptId,
            string itemValue);

        /// <summary>
        /// Gets the unique Rich Qualifier that is identified by the specified ConceptId, ItemValue
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="itemValue"></param>
        /// <returns></returns>
        Task<DbEntities.Qualifier> GetRichEntityByConceptIdItemValueAsync(
            int? conceptId,
            string itemValue);

        #endregion
    }
}

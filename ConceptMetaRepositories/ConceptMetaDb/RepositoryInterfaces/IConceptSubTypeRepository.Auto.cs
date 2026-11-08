/****************************
 * IConceptSubTypeRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptSubType" /> entity
    /// </summary>
    public partial interface IConceptSubTypeRepository
        : IConceptMetaDbRepository<DbEntities.ConceptSubType>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        int GetConceptSubTypeIdByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<int> GetConceptSubTypeIdByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        int GetConceptSubTypeIdByConceptIdSubTypeName(
            int conceptId,
            string subTypeName);

        /// <summary>
        /// Gets the ConceptSubTypeId of the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<int> GetConceptSubTypeIdByConceptIdSubTypeNameAsync(
            int conceptId,
            string subTypeName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetByConceptSubTypeId(int? conceptSubTypeId);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetByConceptSubTypeIdAsync(int? conceptSubTypeId);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetRichEntityByConceptSubTypeId(int? conceptSubTypeId);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptSubTypeId
        /// </summary>
        /// <param name="conceptSubTypeId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetRichEntityByConceptSubTypeIdAsync(int? conceptSubTypeId);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetRichEntityByModelNameConceptNameSubTypeName(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ModelName, ConceptName, SubTypeName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetRichEntityByModelNameConceptNameSubTypeNameAsync(
            string modelName,
            string conceptName,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetByConceptIdSubTypeName(
            int? conceptId,
            string subTypeName);

        /// <summary>
        /// Gets the unique ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetByConceptIdSubTypeNameAsync(
            int? conceptId,
            string subTypeName);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        DbEntities.ConceptSubType GetRichEntityByConceptIdSubTypeName(
            int? conceptId,
            string subTypeName);

        /// <summary>
        /// Gets the unique Rich ConceptSubType that is identified by the specified ConceptId, SubTypeName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="subTypeName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptSubType> GetRichEntityByConceptIdSubTypeNameAsync(
            int? conceptId,
            string subTypeName);

        #endregion
    }
}

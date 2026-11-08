/****************************
 * IConceptModelRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DbEntities.ConceptModel" /> entity
    /// </summary>
    public partial interface IConceptModelRepository
        : IConceptMetaDbRepository<DbEntities.ConceptModel>,
        IConceptMetaDbAggregateRootRepository<DbEntities.ConceptModel>
    {

        #region Methods that return Ids

        /// <summary>
        /// Gets the ConceptModelId of the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        int GetConceptModelIdByModelName(string modelName);

        /// <summary>
        /// Gets the ConceptModelId of the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<int> GetConceptModelIdByModelNameAsync(string modelName);

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetByConceptModelId(int? conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetByConceptModelIdAsync(int? conceptModelId);

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetRichEntityByConceptModelId(int? conceptModelId);

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetRichEntityByConceptModelIdAsync(int? conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetAggregateByConceptModelId(int? conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetAggregateByConceptModelIdAsync(int? conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetByModelNameAsync(string modelName);

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetRichEntityByModelName(string modelName);

        /// <summary>
        /// Gets the unique Rich ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetRichEntityByModelNameAsync(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetAggregateByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetAggregateByModelNameAsync(string modelName);

        #endregion
    }
}

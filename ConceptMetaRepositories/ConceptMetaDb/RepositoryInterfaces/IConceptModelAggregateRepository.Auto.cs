/****************************
 * IConceptModelAggregateRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using ConceptMeta.Common;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;

namespace ConceptMeta.ConceptMetaDb.RepositoryInterfaces
{
    /// <summary>
    /// Aggregate Repository interface for the <see cref="DbEntities.ConceptModel" /> entity
    /// </summary>
    public partial interface IConceptModelAggregateRepository
        : IReadableRepository<DbEntities.ConceptModel>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetByConceptModelId(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetByConceptModelIdAsync(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        DbEntities.ConceptModel GetByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<DbEntities.ConceptModel> GetByModelNameAsync(string modelName);

        #endregion
    }
}

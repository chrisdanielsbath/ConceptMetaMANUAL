/****************************
 * ConceptModelAggregateRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using ConceptMeta.Common;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using ConceptMeta.ConceptMetaDb.RepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.AggregateRepositories
{
    /// <summary>
    /// Aggregate Repository class for the <see cref="DbEntities.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelAggregateRepository
        : ReadableEntityAggregateRepository<DbEntities.ConceptModel>,
        IConceptModelAggregateRepository
    {

        #region Instance Properties
        public IConceptModelRepository ConceptModelRepository
        {
            get
            {
                return (IConceptModelRepository)EntityRepository;
            }
        }

        #endregion

        #region Constructors
        public ConceptModelAggregateRepository(IConceptMetaDbAggregateRootRepository<DbEntities.ConceptModel> aggregateRootRepository)
            : base (aggregateRootRepository)
        {
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetByConceptModelId(int conceptModelId)
        {
            return ConceptModelRepository.GetAggregateByConceptModelId(
                conceptModelId);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetByConceptModelIdAsync(int conceptModelId)
        {
            return await ConceptModelRepository.GetAggregateByConceptModelIdAsync(
                conceptModelId);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public DbEntities.ConceptModel GetByModelName(string modelName)
        {
            return ConceptModelRepository.GetAggregateByModelName(
                modelName);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<DbEntities.ConceptModel> GetByModelNameAsync(string modelName)
        {
            return await ConceptModelRepository.GetAggregateByModelNameAsync(
                modelName);
        }

        #endregion
    }
}

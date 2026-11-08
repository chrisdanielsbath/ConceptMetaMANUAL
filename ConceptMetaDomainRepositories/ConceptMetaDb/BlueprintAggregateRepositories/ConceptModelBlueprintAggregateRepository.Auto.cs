/****************************
 * ConceptModelBlueprintAggregateRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using ConceptMeta.Common;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintAggregateRepositories
{
    /// <summary>
    /// Aggregate Repository class for the <see cref="BlueprintModels.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelBlueprintAggregateRepository
        : BlueprintAggregateRepository<BlueprintModels.ConceptModel>,
        IConceptModelBlueprintAggregateRepository
    {

        #region Instance Properties
        public IConceptModelBlueprintRepository ConceptModelBlueprintRepository
        {
            get
            {
                return (IConceptModelBlueprintRepository)this.BlueprintRepository;
            }
        }

        #endregion

        #region Constructors
        public ConceptModelBlueprintAggregateRepository(IReadWriteBlueprintAggregateRootRepository<BlueprintModels.ConceptModel> aggregateRootRepository)
            : base (aggregateRootRepository)
        {
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.ConceptModel GetByBusinessKey(params object[] keyValues)
        {
            return ConceptModelBlueprintRepository.GetAggregateByBusinessKey(keyValues);
        }

        /// <summary>
        /// Gets an aggregate from the data store based on a business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptModel> GetByBusinessKeyAsync(params object[] keyValues)
        {
            return await ConceptModelBlueprintRepository.GetAggregateByBusinessKeyAsync(keyValues);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetByConceptModelId(int conceptModelId)
        {
            return ConceptModelBlueprintRepository.GetAggregateByConceptModelId(
                conceptModelId);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetByConceptModelIdAsync(int conceptModelId)
        {
            return await ConceptModelBlueprintRepository.GetAggregateByConceptModelIdAsync(
                conceptModelId);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetByModelName(string modelName)
        {
            return ConceptModelBlueprintRepository.GetAggregateByModelName(
                modelName);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetByModelNameAsync(string modelName)
        {
            return await ConceptModelBlueprintRepository.GetAggregateByModelNameAsync(
                modelName);
        }

        #endregion
    }
}

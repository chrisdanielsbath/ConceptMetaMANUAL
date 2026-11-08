/****************************
 * IConceptModelBlueprintAggregateRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using ConceptMeta.Common;
using BlueprintModels = ConceptMeta.Blueprint;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Aggregate Repository interface for the <see cref="BlueprintModels.ConceptModel" /> entity
    /// </summary>
    public partial interface IConceptModelBlueprintAggregateRepository
        : IConceptMetaDbBlueprintAggregateRepository<BlueprintModels.ConceptModel>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetByConceptModelId(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetByConceptModelIdAsync(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetByModelNameAsync(string modelName);

        #endregion
    }
}

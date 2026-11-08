/****************************
 * IConceptModelBlueprintRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="BlueprintModels.ConceptModel" /> entity
    /// </summary>
    public partial interface IConceptModelBlueprintRepository
        : IReadWriteBlueprintAggregateRootRepository<BlueprintModels.ConceptModel>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetByConceptModelId(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetByConceptModelIdAsync(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetAggregateByConceptModelId(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetAggregateByConceptModelIdAsync(int conceptModelId);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetByModelNameAsync(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        BlueprintModels.ConceptModel GetAggregateByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<BlueprintModels.ConceptModel> GetAggregateByModelNameAsync(string modelName);

        #endregion
    }
}

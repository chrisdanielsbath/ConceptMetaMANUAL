/****************************
 * IConceptModelDomainRepository.Auto.cs
 ****************************/
using System.Threading.Tasks;
using DomainModels = ConceptMeta.Domain;
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb.DomainRepositoryInterfaces
{
    /// <summary>
    /// Repository interface for the <see cref="DomainModels.ConceptModel" /> entity
    /// </summary>
    public partial interface IConceptModelDomainRepository
        : IReadWriteDomainRepository<DomainModels.ConceptModel>
    {

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        DomainModels.ConceptModel GetByModelName(string modelName);

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        Task<DomainModels.ConceptModel> GetByModelNameAsync(string modelName);

        #endregion
    }
}

/****************************
 * ConceptModelDomainRepository.Auto.cs
 ****************************/
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueprintModels = ConceptMeta.Blueprint;
using DomainModels = ConceptMeta.Domain;
using ConceptMeta.ConceptMetaDb.DomainRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.DomainRepositories
{
    /// <summary>
    /// Repository class for the <see cref="DomainModels.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelDomainRepository
        : ConceptMetaDbDomainRepository<DomainModels.ConceptModel, BlueprintModels.ConceptModel, IConceptMetaDbBlueprintUnitOfWork>,
        IConceptModelDomainRepository
    {

        #region Instance Properties
        private IConceptMetaDbBlueprintUnitOfWork ConceptMetaDbBlueprintUnitOfWork
        {
            get
            {
                return BlueprintUnitOfWork;
            }
        }

        #endregion

        #region Constructors
        public ConceptModelDomainRepository(
            IConceptMetaDbDomainUnitOfWork<IConceptMetaDbBlueprintUnitOfWork> domainUnitOfWork,
            IConceptMetaDbBlueprintAggregateRepository<BlueprintModels.ConceptModel> blueprintAggregateRepository)
            : base (domainUnitOfWork, blueprintAggregateRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Converts a domain object to a blueprint object
        /// </summary>
        /// <param name="domainObj"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptModel ToBlueprintObj(DomainModels.ConceptModel domainObj)
        {
            return (BlueprintModels.ConceptModel)DomainUnitOfWork.ToBlueprintMapper.Map(
                domainObj,
                typeof(DomainModels.ConceptModel),
                typeof(BlueprintModels.ConceptModel));
        }

        /// <summary>
        /// Converts a set of domain objects to a set of blueprint objects
        /// </summary>
        /// <param name="domainObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptModel> ToBlueprintObjects(IEnumerable<DomainModels.ConceptModel> domainObjects)
        {
            return (IEnumerable<BlueprintModels.ConceptModel>)DomainUnitOfWork.ToBlueprintMapper.Map(
                domainObjects,
                typeof(IEnumerable<DomainModels.ConceptModel>),
                typeof(IEnumerable<BlueprintModels.ConceptModel>));
        }

        /// <summary>
        /// Converts a blueprint object to a domain object
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DomainModels.ConceptModel ToDomainObject(BlueprintModels.ConceptModel blueprintObj)
        {
            return (DomainModels.ConceptModel)DomainUnitOfWork.FromBlueprintMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptModel),
                typeof(DomainModels.ConceptModel));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of domain objects
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DomainModels.ConceptModel> ToDomainObjects(IEnumerable<BlueprintModels.ConceptModel> blueprintObjects)
        {
            return (IEnumerable<DomainModels.ConceptModel>)DomainUnitOfWork.FromBlueprintMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptModel>),
                typeof(IEnumerable<DomainModels.ConceptModel>));
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public DomainModels.ConceptModel GetByModelName(string modelName)
        {
            // get the blueprint aggregate
            BlueprintModels.ConceptModel conceptModel =
                BlueprintUnitOfWork.ConceptModelAggregates.GetByModelName(
                    modelName);

            // map it to a domain object
            return (DomainModels.ConceptModel)DomainUnitOfWork.FromBlueprintMapper.Map(
                conceptModel,
                typeof(BlueprintModels.ConceptModel),
                typeof(DomainModels.ConceptModel));
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<DomainModels.ConceptModel> GetByModelNameAsync(string modelName)
        {
            // get the blueprint aggregate
            BlueprintModels.ConceptModel conceptModel =
                await BlueprintUnitOfWork.ConceptModelAggregates.GetByModelNameAsync(
                    modelName);

            // map it to a domain object
            return (DomainModels.ConceptModel)DomainUnitOfWork.FromBlueprintMapper.Map(
                conceptModel,
                typeof(BlueprintModels.ConceptModel),
                typeof(DomainModels.ConceptModel));
        }

        #endregion
    }
}

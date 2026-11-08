/****************************
 * ConceptMetaDbDomainRepository.Auto.cs
 ****************************/
using ConceptMeta.Common.Domain;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository for the ConceptMeta model, to be used when persisting and retrieving domain objects
    /// This class acts as a simplified form of the <see cref="DomainRepository{TDomainObj, TBlueprintObj, TDomainUnitOfWork, TBlueprintUnitOfWork, TBlueprintAggregateRepository}" /> class that is appropriate to the particular data store in use
    /// </summary>
    public abstract partial class ConceptMetaDbDomainRepository<TDomainObj, TBlueprintObj, TBlueprintUnitOfWork>
        : DomainRepository<TDomainObj, TBlueprintObj, IConceptMetaDbDomainUnitOfWork<TBlueprintUnitOfWork>, TBlueprintUnitOfWork, IConceptMetaDbBlueprintAggregateRepository<TBlueprintObj>>
        where TDomainObj : class
        where TBlueprintObj : class
        where TBlueprintUnitOfWork : class, IConceptMetaDbBlueprintUnitOfWork
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbDomainRepository{TDomainObj, TBlueprintObj, TBlueprintUnitOfWork}" /> class
        /// </summary>
        /// <param name="blueprintUnitOfWork"></param>
        /// <param name="blueprintAggregateRepository"></param>
        public ConceptMetaDbDomainRepository(
            IConceptMetaDbDomainUnitOfWork<TBlueprintUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbBlueprintAggregateRepository<TBlueprintObj> blueprintAggregateRepository)
            : base (blueprintUnitOfWork, blueprintAggregateRepository)
        {
        }

        #endregion
    }
}

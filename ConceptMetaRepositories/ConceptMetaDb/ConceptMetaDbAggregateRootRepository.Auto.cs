/****************************
 * ConceptMetaDbAggregateRootRepository.Auto.cs
 ****************************/
namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate root repository for the ConceptMeta model, to be used when persisting and retrieving aggregates
    /// This class acts as an alias for the AggregateRootRepository class that is appropriate to the particular Orm and Dbms that are in use
    /// </summary>
    public abstract partial class ConceptMetaDbAggregateRootRepository<TAggregateRoot>
        : ConceptMetaDbAggregateRootRepositoryBase<TAggregateRoot>,
        IConceptMetaDbAggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbAggregateRootRepository{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="dbUnitOfWork"></param>
        public ConceptMetaDbAggregateRootRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
            : base (dbUnitOfWork.DbContext)
        {
            DbUnitOfWork = dbUnitOfWork;
        }

        #endregion

        #region Instance Properties
        public ConceptMetaDbUnitOfWork DbUnitOfWork { get; private set; }

        #endregion
    }
}

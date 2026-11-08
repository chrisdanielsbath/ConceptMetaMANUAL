/****************************
 * ConceptMetaDbAggregateRootRepositoryBase.Auto.cs
 ****************************/
using ConceptMeta.Common.EfCore;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate root repository for the ConceptMeta model, to be used when persisting and retrieving aggregates
    /// This class acts as an alias for the <see cref="AggregateRootRepository{TDomainObj, TDbEntity, IConceptMetaDbDomainUnitOfWork{TDbUnitOfWork}, TDbUnitOfWork, IEntityRepository{TDbEntity}}" /> class that is appropriate to the particular Orm and Dbms that are in use
    /// </summary>
    public abstract partial class ConceptMetaDbAggregateRootRepositoryBase<TAggregateRoot>
        : EfCoreAggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbAggregateRootRepositoryBase{TAggregateRoot}" /> class
        /// </summary>
        /// <param name="context"></param>
        public ConceptMetaDbAggregateRootRepositoryBase(ConceptMetaDbContext context)
            : base (context)
        {
            DbContext = context;
        }

        #endregion

        #region Instance Properties
        public ConceptMetaDbContext DbContext { get; private set; }

        #endregion
    }
}

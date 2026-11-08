/****************************
 * ConceptMetaDbBlueprintAggregateRootRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;
using ConceptMeta.Common.Blueprint;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate root repository for the ConceptMeta model, to be used when persisting and retrieving blueprint aggregates
    /// This class acts as a simplified form of the <see cref="BlueprintAggregateRootRepository{TAggregateRoot, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityAggregateRootRepository}" /> class that is appropriate to the particular data store in use
    /// </summary>
    public abstract partial class ConceptMetaDbBlueprintAggregateRootRepository<TBlueprintObj, TDbEntity, TDbUnitOfWork>
        : BlueprintAggregateRootRepository<TBlueprintObj, TDbEntity, IConceptMetaDbBlueprintUnitOfWork<TDbUnitOfWork>, TDbUnitOfWork, IReadWriteEntityAggregateRootRepository<TDbEntity>>
        where TBlueprintObj : class
        where TDbEntity : class
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbBlueprintAggregateRootRepository{TBlueprintObj, TDbEntity, TDbUnitOfWork}" /> class
        /// </summary>
        /// <param name="blueprintUnitOfWork"></param>
        /// <param name="dbEntityRepository"></param>
        public ConceptMetaDbBlueprintAggregateRootRepository(
            IConceptMetaDbBlueprintUnitOfWork<TDbUnitOfWork> blueprintUnitOfWork,
            IReadWriteEntityAggregateRootRepository<TDbEntity> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion
    }
}

/****************************
 * ConceptMetaDbBlueprintRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;
using ConceptMeta.Common.Blueprint;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository for the ConceptMeta model, to be used when persisting and retrieving blueprints
    /// This class acts as a simplified form of the <see cref="BlueprintRepository{TBlueprintObj, TDbEntity, TBlueprintUnitOfWork, TDbUnitOfWork, TDbEntityRepository}" /> class that is appropriate to the particular data store in use
    /// </summary>
    public abstract partial class ConceptMetaDbBlueprintRepository<TBlueprintObj, TDbEntity, TDbUnitOfWork>
        : BlueprintRepository<TBlueprintObj, TDbEntity, IConceptMetaDbBlueprintUnitOfWork<TDbUnitOfWork>, TDbUnitOfWork, IReadWriteEntityRepository<TDbEntity>>,
        IConceptMetaDbBlueprintRepository<TBlueprintObj>
        where TBlueprintObj : class
        where TDbEntity : class
        where TDbUnitOfWork : class, IConceptMetaDbUnitOfWork
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbBlueprintRepository{TBlueprintObj, TDbEntity, TDbUnitOfWork}" /> class
        /// </summary>
        /// <param name="blueprintUnitOfWork"></param>
        /// <param name="dbEntityRepository"></param>
        public ConceptMetaDbBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<TDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<TDbEntity> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion
    }
}

/****************************
 * ConceptMetaDbRepository.Auto.cs
 ****************************/
namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the Repository class that is appropriate to the particular Orm and Dbms that are in use
    /// </summary>
    public abstract partial class ConceptMetaDbRepository<T>
        : ConceptMetaDbRepositoryBase<T>, IConceptMetaDbRepository<T>
        where T : class
    {

        #region Constructors
        public ConceptMetaDbRepository(ConceptMetaDbUnitOfWork dbUnitOfWork)
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

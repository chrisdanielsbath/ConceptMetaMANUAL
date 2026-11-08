/****************************
 * ConceptMetaDbRepositoryBase.Auto.cs
 ****************************/
using ConceptMeta.Common.EfCore;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the Repository class that is appropriate to the particular Orm and Dbms that are in use
    /// </summary>
    public abstract partial class ConceptMetaDbRepositoryBase<T>
        : EfCoreRepository<T>
        where T : class
    {

        #region Constructors
        public ConceptMetaDbRepositoryBase(ConceptMetaDbContext context)
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

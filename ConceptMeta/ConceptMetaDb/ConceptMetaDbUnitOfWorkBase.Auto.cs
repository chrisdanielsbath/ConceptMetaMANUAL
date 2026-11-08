/****************************
 * ConceptMetaDbUnitOfWorkBase.Auto.cs
 ****************************/
using ConceptMeta.Common.EfCore;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Base Unit Of Work class for the ConceptMeta model, to be used when persisting and retrieving entities
    /// This class acts as an alias for the UnitOfWork class that is appropriate to the Orm that is in use
    /// </summary>
    public partial class ConceptMetaDbUnitOfWorkBase
        : EfCoreUnitOfWork<ConceptMetaDbContext>
    {

        #region Constructors
        public ConceptMetaDbUnitOfWorkBase(ConceptMetaDbContext dbContext)
            : base (dbContext)
        {
            DbContext = dbContext;
        }

        #endregion

        #region Instance Properties
        public ConceptMetaDbContext DbContext { get; private set; }

        #endregion
    }
}

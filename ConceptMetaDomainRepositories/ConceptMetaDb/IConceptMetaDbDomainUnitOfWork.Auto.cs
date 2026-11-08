/****************************
 * IConceptMetaDbDomainUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common;
using ConceptMeta.ConceptMetaDb.DomainRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Domain Unit Of Work interface for the ConceptMeta model
    /// </summary>
    public partial interface IConceptMetaDbDomainUnitOfWork
        : IDomainUnitOfWork
    {

        #region Instance Properties
        IConceptModelDomainRepository ConceptModels { get; }

        #endregion
    }
}

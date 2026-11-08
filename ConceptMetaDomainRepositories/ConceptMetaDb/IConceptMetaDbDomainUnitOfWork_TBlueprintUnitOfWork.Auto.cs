/****************************
 * IConceptMetaDbDomainUnitOfWork_TBlueprintUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Domain Unit Of Work interface for the ConceptMeta model with a specified BlueprintUnitOfWork
    /// </summary>
    public partial interface IConceptMetaDbDomainUnitOfWork<TBlueprintUnitOfWork>
        : IConceptMetaDbDomainUnitOfWork,
        IDomainUnitOfWork<TBlueprintUnitOfWork>
        where TBlueprintUnitOfWork : class, IBlueprintUnitOfWork
    {
    }
}

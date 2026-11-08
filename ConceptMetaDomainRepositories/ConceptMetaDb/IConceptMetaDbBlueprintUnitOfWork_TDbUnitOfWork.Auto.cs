/****************************
 * IConceptMetaDbBlueprintUnitOfWork_TDbUnitOfWork.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Blueprint Unit Of Work interface for the ConceptMeta model with a specified DbUnitOfWork
    /// </summary>
    public partial interface IConceptMetaDbBlueprintUnitOfWork<TDbUnitOfWork>
        : IConceptMetaDbBlueprintUnitOfWork,
        IBlueprintUnitOfWork<TDbUnitOfWork>
        where TDbUnitOfWork : class, ITransactionalUnitOfWork
    {
    }
}

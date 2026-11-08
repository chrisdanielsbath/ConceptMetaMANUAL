/****************************
 * IDomainUnitOfWorkSync.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Domain Unit Of Work interface
    /// </summary>
    public partial interface IDomainUnitOfWorkSync
        : IDomainUnitOfWorkBase,
        ITransactionalUnitOfWorkSync
    {
    }
}

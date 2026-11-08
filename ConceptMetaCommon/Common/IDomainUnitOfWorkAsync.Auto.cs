/****************************
 * IDomainUnitOfWorkAsync.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Domain Unit Of Work interface
    /// </summary>
    public partial interface IDomainUnitOfWorkAsync
        : IDomainUnitOfWorkBase,
        ITransactionalUnitOfWorkAsync
    {
    }
}

/****************************
 * IDomainUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Domain Unit Of Work interface
    /// </summary>
    public partial interface IDomainUnitOfWork
        : ITransactionalUnitOfWork,
        IDomainUnitOfWorkSync,
        IDomainUnitOfWorkAsync
    {
    }
}

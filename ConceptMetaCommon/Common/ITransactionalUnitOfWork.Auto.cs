/****************************
 * ITransactionalUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Transactional Unit Of Work interface
    /// </summary>
    public partial interface ITransactionalUnitOfWork
        : IReadWriteUnitOfWork,
        ITransactionalUnitOfWorkSync,
        ITransactionalUnitOfWorkAsync
    {
    }
}

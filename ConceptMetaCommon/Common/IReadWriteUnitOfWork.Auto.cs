/****************************
 * IReadWriteUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Unit Of Work interface
    /// </summary>
    public partial interface IReadWriteUnitOfWork
        : IReadableUnitOfWork,
        IReadWriteUnitOfWorkSync,
        IReadWriteUnitOfWorkAsync
    {
    }
}

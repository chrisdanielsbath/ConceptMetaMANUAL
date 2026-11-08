/****************************
 * IReadableUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Unit Of Work interface
    /// </summary>
    public partial interface IReadableUnitOfWork
        : IReadableUnitOfWorkSync,
        IReadableUnitOfWorkAsync
    {
    }
}

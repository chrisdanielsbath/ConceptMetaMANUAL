/****************************
 * IReadWriteRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Repository Interface
    /// </summary>
    public partial interface IReadWriteRepository<T>
        : IReadableRepository<T>,
        IReadWriteSyncRepository<T>,
        IReadWriteAsyncRepository<T>
        where T : class
    {
    }
}

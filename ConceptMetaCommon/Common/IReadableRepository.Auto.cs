/****************************
 * IReadableRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Readable Repository Interface
    /// </summary>
    public partial interface IReadableRepository<T>
        : IReadableSyncRepository<T>,
        IReadableAsyncRepository<T>
        where T : class
    {
    }
}

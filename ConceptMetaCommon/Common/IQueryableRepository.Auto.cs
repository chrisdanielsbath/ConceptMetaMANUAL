/****************************
 * IQueryableRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Repository Interface
    /// </summary>
    public partial interface IQueryableRepository<T>
        : IReadableRepository<T>,
        IQueryableSyncRepository<T>,
        IQueryableAsyncRepository<T>
        where T : class
    {
    }
}

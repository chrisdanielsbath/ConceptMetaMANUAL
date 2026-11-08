/****************************
 * IReadableDomainAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Readable Domain Repository Interface
    /// </summary>
    public partial interface IReadableDomainAsyncRepository<TDomainObj>
        : IReadableAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

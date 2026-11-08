/****************************
 * IReadableDomainRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Domain Repository Interface
    /// </summary>
    public partial interface IReadableDomainRepository<TDomainObj>
        : IReadableRepository<TDomainObj>,
        IReadableDomainSyncRepository<TDomainObj>,
        IReadableDomainAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

/****************************
 * IReadWriteDomainRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IReadWriteDomainRepository<TDomainObj>
        : IReadableDomainRepository<TDomainObj>,
        IReadWriteDomainSyncRepository<TDomainObj>,
        IReadWriteDomainAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

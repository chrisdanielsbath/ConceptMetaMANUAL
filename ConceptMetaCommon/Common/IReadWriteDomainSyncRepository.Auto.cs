/****************************
 * IReadWriteDomainSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IReadWriteDomainSyncRepository<TDomainObj>
        : IReadableDomainSyncRepository<TDomainObj>,
        IReadWriteSyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

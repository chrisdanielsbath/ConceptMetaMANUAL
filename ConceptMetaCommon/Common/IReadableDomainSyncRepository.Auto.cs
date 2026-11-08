/****************************
 * IReadableDomainSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Readable Domain Repository Interface
    /// </summary>
    public partial interface IReadableDomainSyncRepository<TDomainObj>
        : IReadableSyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

/****************************
 * IQueryableDomainSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Domain Repository Interface
    /// </summary>
    public partial interface IQueryableDomainSyncRepository<TDomainObj>
        : IReadableDomainSyncRepository<TDomainObj>,
        IQueryableSyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

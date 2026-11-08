/****************************
 * IQueryableReadWriteDomainSyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Queryable Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IQueryableReadWriteDomainSyncRepository<TDomainObj>
        : IReadWriteDomainSyncRepository<TDomainObj>,
        IQueryableDomainSyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

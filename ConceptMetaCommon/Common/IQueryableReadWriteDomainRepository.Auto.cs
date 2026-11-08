/****************************
 * IQueryableReadWriteDomainRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IQueryableReadWriteDomainRepository<TDomainObj>
        : IReadWriteDomainRepository<TDomainObj>,
        IQueryableReadWriteDomainSyncRepository<TDomainObj>,
        IQueryableReadWriteDomainAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

/****************************
 * IQueryableDomainRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Queryable Domain Repository Interface
    /// </summary>
    public partial interface IQueryableDomainRepository<TDomainObj>
        : IReadableDomainRepository<TDomainObj>,
        IQueryableDomainSyncRepository<TDomainObj>,
        IQueryableDomainAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

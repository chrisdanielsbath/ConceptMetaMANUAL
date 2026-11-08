/****************************
 * IQueryableReadWriteDomainAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IQueryableReadWriteDomainAsyncRepository<TDomainObj>
        : IReadWriteDomainAsyncRepository<TDomainObj>,
        IQueryableDomainAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

/****************************
 * IQueryableDomainAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Domain Repository Interface
    /// </summary>
    public partial interface IQueryableDomainAsyncRepository<TDomainObj>
        : IReadableDomainAsyncRepository<TDomainObj>,
        IQueryableAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

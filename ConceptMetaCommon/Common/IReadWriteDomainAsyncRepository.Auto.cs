/****************************
 * IReadWriteDomainAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Domain Repository Interface
    /// </summary>
    public partial interface IReadWriteDomainAsyncRepository<TDomainObj>
        : IReadableDomainAsyncRepository<TDomainObj>,
        IReadWriteAsyncRepository<TDomainObj>
        where TDomainObj : class
    {
    }
}

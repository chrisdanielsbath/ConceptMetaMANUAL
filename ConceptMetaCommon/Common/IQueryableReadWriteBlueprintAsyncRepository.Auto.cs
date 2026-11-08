/****************************
 * IQueryableReadWriteBlueprintAsyncRepository.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Queryable Read/Write Blueprint Repository interface
    /// </summary>
    public partial interface IQueryableReadWriteBlueprintAsyncRepository<TBlueprint>
        : IReadWriteBlueprintAsyncRepository<TBlueprint>,
        IQueryableBlueprintAsyncRepository<TBlueprint>
        where TBlueprint : class
    {
    }
}

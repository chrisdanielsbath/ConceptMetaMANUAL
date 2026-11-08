/****************************
 * IConceptMetaDbBlueprintAggregateRootRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate root repository interface for the ConceptMeta model, to be used when persisting and retrieving blueprint aggregates
    /// </summary>
    public partial interface IConceptMetaDbBlueprintAggregateRootRepository<TBlueprintObj>
        : IReadWriteBlueprintAggregateRootRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

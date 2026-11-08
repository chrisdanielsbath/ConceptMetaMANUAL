/****************************
 * IConceptMetaDbBlueprintAggregateRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate repository interface for the ConceptMeta model, to be used when persisting and retrieving blueprint aggregates
    /// </summary>
    public partial interface IConceptMetaDbBlueprintAggregateRepository<TBlueprintObj>
        : IReadWriteBlueprintAggregateRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

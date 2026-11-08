/****************************
 * IConceptMetaDbAggregateRootRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate root repository interface for the ConceptMeta model, to be used when persisting and retrieving aggregates
    /// </summary>
    public partial interface IConceptMetaDbAggregateRootRepository<TAggregateRoot>
        : IReadWriteEntityAggregateRootRepository<TAggregateRoot>
        where TAggregateRoot : class
    {
    }
}

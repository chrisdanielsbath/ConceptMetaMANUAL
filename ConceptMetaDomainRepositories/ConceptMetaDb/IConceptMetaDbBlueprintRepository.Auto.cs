/****************************
 * IConceptMetaDbBlueprintRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository interface for the ConceptMeta model, to be used when persisting and retrieving blueprint objects
    /// </summary>
    public partial interface IConceptMetaDbBlueprintRepository<TBlueprintObj>
        : IReadWriteBlueprintRepository<TBlueprintObj>
        where TBlueprintObj : class
    {
    }
}

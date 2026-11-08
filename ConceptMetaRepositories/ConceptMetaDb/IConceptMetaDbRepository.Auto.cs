/****************************
 * IConceptMetaDbRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic Repository Interface for the ConceptMeta model, to be used when persisting and retrieving entities
    /// </summary>
    public partial interface IConceptMetaDbRepository<T>
        : IQueryableReadWriteEntityRepository<T>
        where T : class
    {
    }
}

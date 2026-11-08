/****************************
 * ConceptMetaDbBlueprintAggregateRepository.Auto.cs
 ****************************/
using ConceptMeta.Common;

namespace ConceptMeta.ConceptMetaDb
{
    /// <summary>
    /// Basic aggregate repository for the ConceptMeta model, to be used when persisting and retrieving blueprint aggregates
    /// This class acts as a specialised form of the <see cref="BlueprintAggregateRepository{TBlueprintObj}" /> class that is appropriate to the particular data store in use
    /// </summary>
    public abstract partial class ConceptMetaDbBlueprintAggregateRepository<TBlueprintObj>
        : BlueprintAggregateRepository<TBlueprintObj>
        where TBlueprintObj : class
    {

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="ConceptMetaDbBlueprintAggregateRepository{TBlueprintObj}" /> class
        /// </summary>
        /// <param name="blueprintAggregateRootRepository"></param>
        public ConceptMetaDbBlueprintAggregateRepository(IConceptMetaDbBlueprintAggregateRootRepository<TBlueprintObj> blueprintAggregateRootRepository)
            : base (blueprintAggregateRootRepository)
        {
        }

        #endregion
    }
}

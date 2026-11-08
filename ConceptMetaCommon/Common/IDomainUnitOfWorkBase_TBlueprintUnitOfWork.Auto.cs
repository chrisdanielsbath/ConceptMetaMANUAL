/****************************
 * IDomainUnitOfWorkBase_TBlueprintUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Domain Unit Of Work base interface with specified BlueprintUnitOfWork
    /// </summary>
    public partial interface IDomainUnitOfWorkBase<TBlueprintUnitOfWork>
        where TBlueprintUnitOfWork : class
    {

        #region Instance Properties

        /// <summary>
        /// The Unit Of Work class to be used when persisting and retrieving blueprint objects
        /// </summary>
        TBlueprintUnitOfWork BlueprintUnitOfWork { get; }

        #endregion
    }
}

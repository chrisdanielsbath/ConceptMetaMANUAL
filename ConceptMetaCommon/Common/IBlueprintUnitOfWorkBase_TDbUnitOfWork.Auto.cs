/****************************
 * IBlueprintUnitOfWorkBase_TDbUnitOfWork.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Blueprint Unit Of Work base interface with specific TDbUnitOfWork
    /// </summary>
    public partial interface IBlueprintUnitOfWorkBase<TDbUnitOfWork>
        where TDbUnitOfWork : class
    {

        #region Instance Properties

        /// <summary>
        /// The Unit Of Work class to be used when persisting and retrieving database entities
        /// </summary>
        TDbUnitOfWork DbUnitOfWork { get; }

        #endregion
    }
}

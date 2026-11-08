/****************************
 * IReadWriteUnitOfWorkSync.Auto.cs
 ****************************/
namespace ConceptMeta.Common
{
    /// <summary>
    /// Synchronous Read/Write Unit Of Work interface
    /// </summary>
    public partial interface IReadWriteUnitOfWorkSync
        : IReadableUnitOfWorkSync
    {

        #region Instance Methods

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        int SaveChanges();

        #endregion
    }
}

/****************************
 * IReadableUnitOfWorkBase.Auto.cs
 ****************************/
using System;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Readable Unit Of Work base interface
    /// </summary>
    public partial interface IReadableUnitOfWorkBase
        : IDisposable
    {

        #region Instance Methods

        /// <summary>
        /// A method that may optionally be called after SaveChanges().
        /// This clears the cache without making any change to the current transaction.
        /// </summary>
        void ClearCache();

        #endregion
    }
}

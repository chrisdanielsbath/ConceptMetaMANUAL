/****************************
 * IReadWriteUnitOfWorkAsync.Auto.cs
 ****************************/
using System.Threading.Tasks;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Asynchronous Read/Write Unit Of Work interface
    /// </summary>
    public partial interface IReadWriteUnitOfWorkAsync
        : IReadableUnitOfWorkAsync
    {

        #region Instance Methods

        /// <summary>
        /// Saves changes
        /// </summary>
        /// <returns></returns>
        Task<int> SaveChangesAsync();

        #endregion
    }
}

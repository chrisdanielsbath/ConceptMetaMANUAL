/****************************
 * IDomainUnitOfWorkBase.Auto.cs
 ****************************/
using AutoMapper;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Domain Unit Of Work base interface
    /// </summary>
    public partial interface IDomainUnitOfWorkBase
    {

        #region Instance Properties

        /// <summary>
        /// The mapper to be used when converting to blueprint objects
        /// </summary>
        IMapper ToBlueprintMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from blueprint objects
        /// </summary>
        IMapper FromBlueprintMapper { get; }

        #endregion
    }
}

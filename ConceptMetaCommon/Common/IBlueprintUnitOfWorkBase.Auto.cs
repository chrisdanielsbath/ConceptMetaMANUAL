/****************************
 * IBlueprintUnitOfWorkBase.Auto.cs
 ****************************/
using AutoMapper;

namespace ConceptMeta.Common
{
    /// <summary>
    /// Common Blueprint Unit Of Work base interface
    /// </summary>
    public partial interface IBlueprintUnitOfWorkBase
    {

        #region Instance Properties

        /// <summary>
        /// The mapper to be used when converting to Entities
        /// </summary>
        IMapper ToEntityMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from Entities
        /// </summary>
        IMapper FromEntityMapper { get; }

        /// <summary>
        /// The mapper to be used when converting to Entity/Blueprint pairs
        /// </summary>
        IMapper ToEntityBlueprintPairMapper { get; }

        /// <summary>
        /// The mapper to be used when converting from Entity/Blueprint pairs
        /// </summary>
        IMapper FromEntityBlueprintPairMapper { get; }

        #endregion
    }
}

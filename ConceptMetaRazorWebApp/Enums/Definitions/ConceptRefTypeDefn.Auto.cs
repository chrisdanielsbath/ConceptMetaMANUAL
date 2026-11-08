/****************************
 * ConceptRefTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="ConceptRefType" /> enumeration
    /// </summary>
    public partial class ConceptRefTypeDefn
        : EnumProviderBase<ConceptRefType>
    {

        #region Constructors
        public ConceptRefTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<ConceptRefType, string>
            {
                { ConceptRefType.UniqueContainer, "The parent concept forms part of the unique identifier for the child concept, and acts as the unique container when the model is expressed in a hierarchical structure" },
                { ConceptRefType.Identifying, "The parent concept forms part of the unique identifier for the child concept, but does not act as the unique container" },
                { ConceptRefType.Descriptive, "The parent concept provides non-identifying, descriptive detail about the child concept" }
            };
        }

        #endregion
    }
}

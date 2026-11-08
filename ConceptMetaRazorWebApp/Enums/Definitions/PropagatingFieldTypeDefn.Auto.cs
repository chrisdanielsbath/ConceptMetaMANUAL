/****************************
 * PropagatingFieldTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="PropagatingFieldType" /> enumeration
    /// </summary>
    public partial class PropagatingFieldTypeDefn
        : EnumProviderBase<PropagatingFieldType>
    {

        #region Constructors
        public PropagatingFieldTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<PropagatingFieldType, string>
            {
                { PropagatingFieldType.BusinessKey, "The propagating field acts as a Business Key" },
                { PropagatingFieldType.SurrogateKey, "The propagating field acts as a Surrogate Key" }
            };
        }

        #endregion
    }
}

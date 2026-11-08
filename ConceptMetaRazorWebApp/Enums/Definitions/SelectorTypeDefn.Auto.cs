/****************************
 * SelectorTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="SelectorType" /> enumeration
    /// </summary>
    public partial class SelectorTypeDefn
        : EnumProviderBase<SelectorType>
    {

        #region Constructors
        public SelectorTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<SelectorType, string>
            {
                { SelectorType.Dropdown, "A dropdown list should be rendered" },
                { SelectorType.Searchable, "A searchable text box should be rendered" }
            };
        }

        #endregion
    }
}

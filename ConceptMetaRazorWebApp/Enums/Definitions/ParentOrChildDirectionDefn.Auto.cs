/****************************
 * ParentOrChildDirectionDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="ParentOrChildDirection" /> enumeration
    /// </summary>
    public partial class ParentOrChildDirectionDefn
        : EnumProviderBase<ParentOrChildDirection>
    {

        #region Constructors
        public ParentOrChildDirectionDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<ParentOrChildDirection, string>
            {
                { ParentOrChildDirection.ToChild, "The referenced concept may occur more than once, and acts as the child concept when the model is expressed in a relational structure" },
                { ParentOrChildDirection.ToParent, "The referenced concept is single-valued, and acts as the parent concept when the model is expressed in a relational structure" }
            };
        }

        #endregion
    }
}

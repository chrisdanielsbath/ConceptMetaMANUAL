/****************************
 * ConceptTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="ConceptType" /> enumeration
    /// </summary>
    public partial class ConceptTypeDefn
        : EnumProviderBase<ConceptType>
    {

        #region Constructors
        public ConceptTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<ConceptType, string>
            {
                { ConceptType.DataType, "The concept represents a Data Type" },
                { ConceptType.Enumeration, "The concept represents an Enumeration" },
                { ConceptType.Object, "The concept represents an Entity (i.e. a class of object)" },
                { ConceptType.Scalar, "The concept represents a scalar-valued property (either a Domain or a Field)" },
                { ConceptType.UniqueKey, "The concept represents a particular unique key through which an Entity may be referenced" },
                { ConceptType.SubType, "The concept represents an Entity Subtype (i.e. a particular specialised variant of a class of object)" }
            };
        }

        #endregion
    }
}

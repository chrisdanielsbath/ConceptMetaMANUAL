/****************************
 * BasicDataTypeDefn.Auto.cs
 ****************************/
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Definitions
{
    /// <summary>
    /// Definition providing information about the <see cref="BasicDataType" /> enumeration
    /// </summary>
    public partial class BasicDataTypeDefn
        : EnumProviderBase<BasicDataType>
    {

        #region Constructors
        public BasicDataTypeDefn()
            : base ()
        {
        }

        #endregion

        #region Instance Methods
        protected override void BuildDictionary()
        {
            Dictionary = new Dictionary<BasicDataType, string>
            {
                { BasicDataType.Binary, "The scalar field holds binary values" },
                { BasicDataType.Boolean, "The scalar field holds true/false values" },
                { BasicDataType.Integer, "The scalar field holds integer values" },
                { BasicDataType.Date, "The scalar field holds values that represent a date, datetime or time" },
                { BasicDataType.Decimal, "The scalar field holds numeric values" },
                { BasicDataType.String, "The scalar field holds string values" },
                { BasicDataType.Xml, "The scalar field holds XML values" }
            };
        }

        #endregion
    }
}

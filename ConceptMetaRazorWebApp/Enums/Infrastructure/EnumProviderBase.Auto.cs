/****************************
 * EnumProviderBase.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure
{
    /// <summary>
    /// Base class for classes that make Enumeration definitions available within the ConceptMeta Razor Web App
    /// </summary>
    public partial class EnumProviderBase<T>
        : IEnumProvider<T>
    {

        #region Instance Properties
        protected Dictionary<T, string> Dictionary { get; set; }

        #endregion

        #region Instance Methods
        public Dictionary<T, string> GetDictionary()
        {
            if (Dictionary == null)
            {
                BuildDictionary();
            }
            return Dictionary;
        }
        protected virtual void BuildDictionary()
        {
        }

        #endregion
    }
}

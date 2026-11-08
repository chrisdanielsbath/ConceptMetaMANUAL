/****************************
 * EnumSet.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure
{
    /// <summary>
    /// Base class for classes that make Enumeration definitions available within the ConceptMeta Razor Web App
    /// </summary>
    public partial class EnumSet<T>
        where T : Enum
    {

        #region Instance Variables
        private Dictionary<T, string> _dictionary;

        #endregion

        #region Constructors
        public EnumSet(IEnumProvider<T> provider)
        {
            this._dictionary = provider.GetDictionary();
        }

        #endregion

        #region Instance Methods
        public List<DropdownOption> GetNewDropdownOptions()
        {
            List<DropdownOption> result = new List<DropdownOption>();
            foreach (T enumValue in _dictionary.Keys)
            {
                result.Add(new DropdownOption()
                {
                    PkString = enumValue.ToString(),
                    ValueString = enumValue.ToString()  // _dictionary.GetValueOrDefault(enumValue, ")
                });
            }
            return result;
        }

        #endregion
    }
}

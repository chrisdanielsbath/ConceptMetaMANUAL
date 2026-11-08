/****************************
 * BoolSet.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using ConceptMeta.ConceptMetaDb.RazorWebApp.Models;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure
{
    /// <summary>
    /// Class that makes Boolean definitions available within the ConceptMeta Razor Web App
    /// </summary>
    public partial class BoolSet
    {

        #region Instance Variables
        private Dictionary<bool, string> _dictionary;

        #endregion

        #region Constructors
        public BoolSet()
        {
            this._dictionary = new Dictionary<bool, string> {
                { true, "Yes" },
                { false, "No" }
            };
        }

        #endregion

        #region Instance Methods
        public List<DropdownOption> GetNewDropdownOptions()
        {
            List<DropdownOption> result = new List<DropdownOption>();
            foreach (bool boolValue in _dictionary.Keys)
            {
                result.Add(new DropdownOption()
                {
                    PkString = boolValue.ToString(),
                    ValueString = _dictionary.GetValueOrDefault(boolValue, "")
                });
            }
            return result;
        }

        #endregion
    }
}

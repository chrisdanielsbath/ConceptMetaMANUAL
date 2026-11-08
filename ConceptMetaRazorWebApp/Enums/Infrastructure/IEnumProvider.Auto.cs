/****************************
 * IEnumProvider.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.ConceptMetaDb.RazorWebApp.Enums.Infrastructure
{
    /// <summary>
    /// Interface that must be implemented by all Enum Provider classes
    /// </summary>
    public partial interface IEnumProvider<T>
    {

        #region Instance Methods
        Dictionary<T, string> GetDictionary();

        #endregion
    }
}

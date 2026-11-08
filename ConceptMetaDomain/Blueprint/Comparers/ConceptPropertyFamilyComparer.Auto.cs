/****************************
 * ConceptPropertyFamilyComparer.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Blueprint.Comparers
{
    /// <summary>
    /// Comparer used when sorting ConceptPropertyFamily blueprint objects
    /// </summary>
    public partial class ConceptPropertyFamilyComparer
        : IComparer<ConceptPropertyFamily>
    {

        #region Instance Methods
        public int Compare(
            ConceptPropertyFamily x,
            ConceptPropertyFamily y)
        {
            int result = x.SeqNo.CompareTo(y.SeqNo);
            return result;
        }

        #endregion
    }
}

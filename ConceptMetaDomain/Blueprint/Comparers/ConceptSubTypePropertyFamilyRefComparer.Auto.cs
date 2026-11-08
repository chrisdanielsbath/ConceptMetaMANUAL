/****************************
 * ConceptSubTypePropertyFamilyRefComparer.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Blueprint.Comparers
{
    /// <summary>
    /// Comparer used when sorting ConceptSubTypePropertyFamilyRef blueprint objects
    /// </summary>
    public partial class ConceptSubTypePropertyFamilyRefComparer
        : IComparer<ConceptSubTypePropertyFamilyRef>
    {

        #region Instance Methods
        public int Compare(
            ConceptSubTypePropertyFamilyRef x,
            ConceptSubTypePropertyFamilyRef y)
        {
            int result = x.SeqNo.CompareTo(y.SeqNo);
            return result;
        }

        #endregion
    }
}

/****************************
 * ConceptUniqueKeyPropertyFamilyRefComparer.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Blueprint.Comparers
{
    /// <summary>
    /// Comparer used when sorting ConceptUniqueKeyPropertyFamilyRef blueprint objects
    /// </summary>
    public partial class ConceptUniqueKeyPropertyFamilyRefComparer
        : IComparer<ConceptUniqueKeyPropertyFamilyRef>
    {

        #region Instance Methods
        public int Compare(
            ConceptUniqueKeyPropertyFamilyRef x,
            ConceptUniqueKeyPropertyFamilyRef y)
        {
            int result = x.SeqNo.CompareTo(y.SeqNo);
            return result;
        }

        #endregion
    }
}

/****************************
 * QualifierComparer.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Blueprint.Comparers
{
    /// <summary>
    /// Comparer used when sorting Qualifier blueprint objects
    /// </summary>
    public partial class QualifierComparer
        : IComparer<Qualifier>
    {

        #region Instance Methods
        public int Compare(
            Qualifier x,
            Qualifier y)
        {
            int result = x.SeqNo.CompareTo(y.SeqNo);
            return result;
        }

        #endregion
    }
}

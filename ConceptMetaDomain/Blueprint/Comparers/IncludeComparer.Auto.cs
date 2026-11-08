/****************************
 * IncludeComparer.Auto.cs
 ****************************/
using System.Collections.Generic;

namespace ConceptMeta.Blueprint.Comparers
{
    /// <summary>
    /// Comparer used when sorting Include blueprint objects
    /// </summary>
    public partial class IncludeComparer
        : IComparer<Include>
    {

        #region Instance Methods
        public int Compare(
            Include x,
            Include y)
        {
            int result = x.SeqNo.CompareTo(y.SeqNo);
            return result;
        }

        #endregion
    }
}

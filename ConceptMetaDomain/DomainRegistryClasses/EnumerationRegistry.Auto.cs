/****************************
 * EnumerationRegistry.Auto.cs
 ****************************/
using System.Collections.Immutable;
using System.Linq;
using ConceptMeta.Collections;
using DomainModels = ConceptMeta.Domain;

namespace ConceptMeta.DomainRegistryClasses
{
    /// <summary>
    /// Registry to manage the object-valued children of a particular Enumeration domain object
    /// </summary>
    internal partial class EnumerationRegistry
    {

        #region Instance Variables
        private readonly IndexedSet<DomainModels.EnumerationMember> enumeratedValues = new IndexedSet<DomainModels.EnumerationMember>(e => e.EnumeratedValue);

        #endregion

        #region Constructors
        internal EnumerationRegistry(DomainModels.Enumeration enumeration)
        {
            Enumeration = enumeration;
        }

        #endregion

        #region Instance Properties
        private DomainModels.Enumeration Enumeration { get; }
        internal ConceptModelRegistry ConceptModelRegistry { get; set; }
        internal IndexedSet<DomainModels.EnumerationMember> EnumeratedValues => enumeratedValues;

        #endregion

        #region "Find one" methods
        internal DomainModels.EnumerationMember FindEnumerationMemberByEnumeratedValue(string enumeratedValue)
        {
            if (EnumeratedValues.ContainsKey(enumeratedValue))
            {
                return EnumeratedValues.GetItem(enumeratedValue);
            }
            return null;
        }

        #endregion
    }
}

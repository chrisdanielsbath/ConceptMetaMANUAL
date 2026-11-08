/****************************
 * ConceptSubTypeRegistry.Auto.cs
 ****************************/
using System.Collections.Immutable;
using System.Linq;
using ConceptMeta.Collections;
using DomainModels = ConceptMeta.Domain;

namespace ConceptMeta.DomainRegistryClasses
{
    /// <summary>
    /// Registry to manage the object-valued children of a particular ConceptSubType domain object
    /// </summary>
    internal partial class ConceptSubTypeRegistry
    {

        #region Instance Variables
        private readonly IndexedSet<DomainModels.ConceptSubTypePropertyFamilyRef> propertyFamilyRefs = new IndexedSet<DomainModels.ConceptSubTypePropertyFamilyRef>(c => c.PropertyFamilyName);

        #endregion

        #region Constructors
        internal ConceptSubTypeRegistry(DomainModels.ConceptSubType conceptSubType)
        {
            ConceptSubType = conceptSubType;
        }

        #endregion

        #region Instance Properties
        private DomainModels.ConceptSubType ConceptSubType { get; }
        internal ConceptRegistry ConceptRegistry { get; set; }
        internal IndexedSet<DomainModels.ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs => propertyFamilyRefs;

        #endregion

        #region "Find one" methods
        internal DomainModels.ConceptSubTypePropertyFamilyRef FindPropertyFamilyRefByPropertyFamilyName(string propertyFamilyName)
        {
            if (PropertyFamilyRefs.ContainsKey(propertyFamilyName))
            {
                return PropertyFamilyRefs.GetItem(propertyFamilyName);
            }
            return null;
        }

        #endregion
    }
}

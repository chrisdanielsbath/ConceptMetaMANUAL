/****************************
 * ConceptUniqueKeyRegistry.Auto.cs
 ****************************/
using System.Collections.Immutable;
using System.Linq;
using ConceptMeta.Collections;
using DomainModels = ConceptMeta.Domain;

namespace ConceptMeta.DomainRegistryClasses
{
    /// <summary>
    /// Registry to manage the object-valued children of a particular ConceptUniqueKey domain object
    /// </summary>
    internal partial class ConceptUniqueKeyRegistry
    {

        #region Instance Variables
        private readonly IndexedSet<DomainModels.ConceptUniqueKeyPropertyFamilyRef> propertyFamilyRefs = new IndexedSet<DomainModels.ConceptUniqueKeyPropertyFamilyRef>(c => c.PropertyFamilyName);

        #endregion

        #region Constructors
        internal ConceptUniqueKeyRegistry(DomainModels.ConceptUniqueKey conceptUniqueKey)
        {
            ConceptUniqueKey = conceptUniqueKey;
        }

        #endregion

        #region Instance Properties
        private DomainModels.ConceptUniqueKey ConceptUniqueKey { get; }
        internal ConceptRegistry ConceptRegistry { get; set; }
        internal IndexedSet<DomainModels.ConceptUniqueKeyPropertyFamilyRef> PropertyFamilyRefs => propertyFamilyRefs;

        #endregion

        #region "Find one" methods
        internal DomainModels.ConceptUniqueKeyPropertyFamilyRef FindPropertyFamilyRefByPropertyFamilyName(string propertyFamilyName)
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

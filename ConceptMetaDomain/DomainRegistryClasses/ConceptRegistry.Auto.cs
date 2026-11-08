/****************************
 * ConceptRegistry.Auto.cs
 ****************************/
using System.Collections.Immutable;
using System.Linq;
using ConceptMeta.Collections;
using DomainModels = ConceptMeta.Domain;

namespace ConceptMeta.DomainRegistryClasses
{
    /// <summary>
    /// Registry to manage the object-valued children of a particular Concept domain object
    /// </summary>
    internal partial class ConceptRegistry
    {

        #region Instance Variables
        private readonly IndexedSet<DomainModels.Include> includes = new IndexedSet<DomainModels.Include>(i => i.ItemValue);
        private readonly IndexedSet<DomainModels.Qualifier> qualifiers = new IndexedSet<DomainModels.Qualifier>(q => q.ItemValue);
        private readonly IndexedSet<DomainModels.ConceptPropertyFamily> propertyFamilies = new IndexedSet<DomainModels.ConceptPropertyFamily>(c => c.PropertyFamilyName);
        private readonly IndexedSet<DomainModels.ConceptUniqueKey> uniqueKeys = new IndexedSet<DomainModels.ConceptUniqueKey>(c => c.UniqueKeyName);
        private readonly IndexedSet<DomainModels.ConceptSubType> subTypes = new IndexedSet<DomainModels.ConceptSubType>(c => c.SubTypeName);
        private readonly IndexedSet<DomainModels.ConceptRef> properties = new IndexedSet<DomainModels.ConceptRef>(c => c.PropertyName);

        #endregion

        #region Constructors
        internal ConceptRegistry(DomainModels.Concept concept)
        {
            Concept = concept;
        }

        #endregion

        #region Instance Properties
        private DomainModels.Concept Concept { get; }
        internal ConceptModelRegistry ConceptModelRegistry { get; set; }
        internal IndexedSet<DomainModels.Include> Includes => includes;
        internal IndexedSet<DomainModels.Qualifier> Qualifiers => qualifiers;
        internal IndexedSet<DomainModels.ConceptPropertyFamily> PropertyFamilies => propertyFamilies;
        internal IndexedSet<DomainModels.ConceptUniqueKey> UniqueKeys => uniqueKeys;
        internal IndexedSet<DomainModels.ConceptSubType> SubTypes => subTypes;
        internal IndexedSet<DomainModels.ConceptRef> Properties => properties;

        #endregion

        #region "Find one" methods
        internal DomainModels.Include FindIncludeByItemValue(string itemValue)
        {
            if (Includes.ContainsKey(itemValue))
            {
                return Includes.GetItem(itemValue);
            }
            return null;
        }
        internal DomainModels.Qualifier FindQualifierByItemValue(string itemValue)
        {
            if (Qualifiers.ContainsKey(itemValue))
            {
                return Qualifiers.GetItem(itemValue);
            }
            return null;
        }
        internal DomainModels.ConceptPropertyFamily FindPropertyFamilyByPropertyFamilyName(string propertyFamilyName)
        {
            if (PropertyFamilies.ContainsKey(propertyFamilyName))
            {
                return PropertyFamilies.GetItem(propertyFamilyName);
            }
            return null;
        }
        internal DomainModels.ConceptUniqueKey FindUniqueKeyByUniqueKeyName(string uniqueKeyName)
        {
            if (UniqueKeys.ContainsKey(uniqueKeyName))
            {
                return UniqueKeys.GetItem(uniqueKeyName);
            }
            return null;
        }
        internal DomainModels.ConceptSubType FindSubTypeBySubTypeName(string subTypeName)
        {
            if (SubTypes.ContainsKey(subTypeName))
            {
                return SubTypes.GetItem(subTypeName);
            }
            return null;
        }
        internal DomainModels.ConceptRef FindPropertyByPropertyName(string propertyName)
        {
            if (Properties.ContainsKey(propertyName))
            {
                return Properties.GetItem(propertyName);
            }
            return null;
        }

        #endregion

        #region "Get many" methods

        /// <summary>
        /// For ConceptRef.PropertyFamily
        /// </summary>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.ConceptRef> GetPropertiesByPropertyFamilyName(string propertyFamilyName)
        {
            ImmutableList<DomainModels.ConceptRef> result = Properties
                .Where(c => c.PropertyFamilyName == propertyFamilyName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For ConceptSubTypePropertyFamilyRef.ConceptPropertyFamily
        /// </summary>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.ConceptSubTypePropertyFamilyRef> GetPropertyFamilyRefsByPropertyFamilyName(string propertyFamilyName)
        {
            ImmutableList<DomainModels.ConceptSubTypePropertyFamilyRef> result = SubTypes
                .SelectMany(c => c.PropertyFamilyRefs)
                .Where(c => c.PropertyFamilyName == propertyFamilyName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For ConceptUniqueKeyPropertyFamilyRef.ConceptPropertyFamily
        /// </summary>
        /// <param name="propertyFamilyName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.ConceptUniqueKeyPropertyFamilyRef> GetUniqueKeyPropertyFamilyRefsByPropertyFamilyName(string propertyFamilyName)
        {
            ImmutableList<DomainModels.ConceptUniqueKeyPropertyFamilyRef> result = UniqueKeys
                .SelectMany(c => c.PropertyFamilyRefs)
                .Where(c => c.PropertyFamilyName == propertyFamilyName)
                .ToImmutableList();
            return result;
        }

        #endregion
    }
}

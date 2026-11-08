/****************************
 * ConceptUniqueKey.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A unique key index that can be used to uniquely identify objects of a particular type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptUniqueKey: {UniqueKeyName}")]
    public partial class ConceptUniqueKey
    {

        #region Constructors
        public ConceptUniqueKey()
        {
            ConceptUniqueKeyRegistry = new ConceptUniqueKeyRegistry(this);
        }

        #endregion

        #region Instance Properties

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// The Name value of the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyPropertyFamilyRef" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptUniqueKeyPropertyFamilyRef> PropertyFamilyRefs => ConceptUniqueKeyRegistry.PropertyFamilyRefs;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptUniqueKey,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return UniqueKeyName;
        }

        /// <summary>
        /// Links the ConceptUniqueKey to the parent Concept and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="concept"></param>
        public void Fixup(Concept concept)
        {
            Concept = concept;
            ConceptUniqueKeyRegistry.ConceptRegistry = concept.ConceptRegistry;
            foreach (ConceptUniqueKeyPropertyFamilyRef c in PropertyFamilyRefs)
            {
                c.Fixup(this);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptUniqueKey
        /// </summary>
        internal ConceptUniqueKeyRegistry ConceptUniqueKeyRegistry { get; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; private set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> UniqueKeyRefs => ConceptUniqueKeyRegistry
            .ConceptRegistry
            .ConceptModelRegistry
            .GetUniqueKeyRefsByReferencedConceptNameReferencedUniqueKeyName(ConceptName, UniqueKeyName);

        #endregion
    }
}

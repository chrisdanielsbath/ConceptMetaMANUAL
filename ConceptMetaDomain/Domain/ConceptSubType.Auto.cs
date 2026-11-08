/****************************
 * ConceptSubType.Auto.cs
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
    /// A specialised variety of an entity
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptSubType: {SubTypeName}")]
    public partial class ConceptSubType
    {

        #region Constructors
        public ConceptSubType()
        {
            ConceptSubTypeRegistry = new ConceptSubTypeRegistry(this);
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
        /// The name of the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string SubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRef" /> objects
        /// </summary>
        [DataMember]
        public IList<ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs => ConceptSubTypeRegistry.PropertyFamilyRefs;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptSubType,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return SubTypeName;
        }

        /// <summary>
        /// Links the ConceptSubType to the parent Concept and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="concept"></param>
        public void Fixup(Concept concept)
        {
            Concept = concept;
            ConceptSubTypeRegistry.ConceptRegistry = concept.ConceptRegistry;
            foreach (ConceptSubTypePropertyFamilyRef c in PropertyFamilyRefs)
            {
                c.Fixup(this);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptSubType
        /// </summary>
        internal ConceptSubTypeRegistry ConceptSubTypeRegistry { get; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; private set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> SubTypeRefs => ConceptSubTypeRegistry
            .ConceptRegistry
            .ConceptModelRegistry
            .GetSubTypeRefsBySpecialisedConceptNameSpecialisedSubTypeName(ConceptName, SubTypeName);

        #endregion
    }
}

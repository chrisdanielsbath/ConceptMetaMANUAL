/****************************
 * ConceptPropertyFamily.Auto.cs
 ****************************/
using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.Domain.JsonConverters;
using ConceptMeta.JsonConverters;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A family of properties
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptPropertyFamily: {PropertyFamilyName}")]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptPropertyFamily
    {

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
        public string PropertyFamilyName { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptPropertyFamily,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PropertyFamilyName;
        }

        /// <summary>
        /// Links the ConceptPropertyFamily to the parent Concept and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="concept"></param>
        public void Fixup(Concept concept)
        {
            Concept = concept;
            ConceptRegistry = concept.ConceptRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the Concept
        /// </summary>
        internal ConceptRegistry ConceptRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="Concept" /> object
        /// </summary>
        [JsonIgnore]
        public Concept Concept { get; private set; }

        /// <summary>
        /// The set of child <see cref="ConceptRef" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<ConceptRef> Properties => ConceptRegistry
            .GetPropertiesByPropertyFamilyName(PropertyFamilyName);

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRef" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs => ConceptRegistry
            .GetPropertyFamilyRefsByPropertyFamilyName(PropertyFamilyName);

        /// <summary>
        /// The set of child <see cref="ConceptUniqueKeyPropertyFamilyRef" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<ConceptUniqueKeyPropertyFamilyRef> UniqueKeyPropertyFamilyRefs => ConceptRegistry
            .GetUniqueKeyPropertyFamilyRefsByPropertyFamilyName(PropertyFamilyName);

        #endregion
    }
}

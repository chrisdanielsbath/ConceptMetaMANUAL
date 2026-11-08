/****************************
 * Include.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.Domain.JsonConverters;
using ConceptMeta.JsonConverters;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A Linq expression, starting from the current entity, that defines an item to be hydrated when hydrating the current entity
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Include: {ItemValue}")]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "ItemValue")]
    public partial class Include
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
        /// The ConceptName value for the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string ConceptName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ItemValue { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the Include,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ItemValue;
        }

        /// <summary>
        /// Links the Include to the parent Concept and recurses in order to link up child objects similarly
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

        #endregion
    }
}

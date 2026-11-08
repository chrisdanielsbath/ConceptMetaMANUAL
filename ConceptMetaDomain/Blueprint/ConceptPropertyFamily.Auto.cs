/****************************
 * ConceptPropertyFamily.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using ConceptMeta.Blueprint.JsonConverters;
using ConceptMeta.JsonConverters;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A family of properties
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptPropertyFamily: {PropertyFamilyName}")]
    [System.Text.Json.Serialization.JsonConverter(typeof(ConceptPropertyFamilyJsonConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptPropertyFamily
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// </summary>
        [DataMember]
        public int ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        /// <summary>
        /// The ID of the Concept
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptId { get; set; }

        /// <summary>
        /// The name of the Concept
        /// </summary>
        [DataMember]
        public string ConceptName { get; set; }

        [DataMember]
        public string PropertyFamilyName { get; set; }

        /// <summary>
        /// Sequence number
        /// </summary>
        [DataMember]
        public int SeqNo { get; set; }

        #endregion
    }
}

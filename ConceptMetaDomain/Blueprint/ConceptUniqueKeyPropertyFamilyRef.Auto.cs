/****************************
 * ConceptUniqueKeyPropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using ConceptMeta.Blueprint.JsonConverters;
using ConceptMeta.JsonConverters;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptUniqueKeyPropertyFamilyRef: {PropertyFamilyName}")]
    [System.Text.Json.Serialization.JsonConverter(typeof(ConceptUniqueKeyPropertyFamilyRefJsonConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptUniqueKeyPropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptUniqueKeyPropertyFamilyRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptUniqueKeyPropertyFamilyRefId { get; set; }

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
        /// </summary>
        [DataMember]
        public int ConceptId { get; set; }

        /// <summary>
        /// The name of the Concept
        /// </summary>
        [DataMember]
        public string ConceptName { get; set; }

        /// <summary>
        /// The ID of the ConceptUniqueKey
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptUniqueKeyId { get; set; }

        /// <summary>
        /// The UniqueKeyName value for the ConceptUniqueKey
        /// </summary>
        [DataMember]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The ID of the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public int ConceptPropertyFamilyId { get; set; }

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
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

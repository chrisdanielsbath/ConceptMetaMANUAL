/****************************
 * ConceptSubTypePropertyFamilyRef.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using ConceptMeta.Blueprint.JsonConverters;
using ConceptMeta.JsonConverters;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptSubTypePropertyFamilyRef: {PropertyFamilyName}")]
    [System.Text.Json.Serialization.JsonConverter(typeof(ConceptSubTypePropertyFamilyRefJsonConverter))]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptSubTypePropertyFamilyRef
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubTypePropertyFamilyRef
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptSubTypePropertyFamilyRefId { get; set; }

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
        /// The ID of the ConceptSubType
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptSubTypeId { get; set; }

        /// <summary>
        /// The SubTypeName value for the ConceptSubType
        /// </summary>
        [DataMember]
        public string SubTypeName { get; set; }

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

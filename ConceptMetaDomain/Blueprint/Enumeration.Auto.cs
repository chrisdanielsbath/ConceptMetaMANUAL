/****************************
 * Enumeration.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A constrained vocabulary
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Enumeration: {EnumerationName}")]
    public partial class Enumeration
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the Enumeration
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? EnumerationId { get; set; }

        /// <summary>
        /// The ID of the ConceptModel
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [DataMember]
        public int? ConceptModelId { get; set; }

        /// <summary>
        /// The ModelName value for the ConceptModel
        /// </summary>
        [DataMember]
        public string ModelName { get; set; }

        [DataMember]
        public string EnumerationName { get; set; }

        [DataMember]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The ID of the DataType
        /// </summary>
        [DataMember]
        public int DataTypeId { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="EnumerationMember" /> objects
        /// </summary>
        [DataMember]
        public List<EnumerationMember> EnumeratedValues { get; set; }

        #endregion
    }
}

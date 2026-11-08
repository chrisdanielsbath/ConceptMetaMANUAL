/****************************
 * ConceptSubType.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace ConceptMeta.Blueprint
{
    /// <summary>
    /// A specialised variety of an entity
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptSubType: {SubTypeName}")]
    public partial class ConceptSubType
    {

        #region Instance Properties

        /// <summary>
        /// The ID of the ConceptSubType
        /// NOTE: This is a persistence-only identifier.
        /// A nullable data type has been chosen, with the intention that the property value should be omitted
        /// when calling 'create' methods, and wherever the underlying store does not require identifiers for nested objects.
        /// </summary>
        [DataMember]
        public int? ConceptSubTypeId { get; set; }

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
        public string SubTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="ConceptSubTypePropertyFamilyRef" /> objects
        /// </summary>
        [DataMember]
        public List<ConceptSubTypePropertyFamilyRef> PropertyFamilyRefs { get; set; }

        #endregion
    }
}

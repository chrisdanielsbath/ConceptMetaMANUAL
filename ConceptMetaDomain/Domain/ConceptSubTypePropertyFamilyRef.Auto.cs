/****************************
 * ConceptSubTypePropertyFamilyRef.Auto.cs
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
    /// A record which associates a given sub type with a particular family of properties, signifying that the family is relevant to that sub type
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptSubTypePropertyFamilyRef: {PropertyFamilyName}")]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptSubTypePropertyFamilyRef
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

        /// <summary>
        /// The SubTypeName value for the ConceptSubType
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string SubTypeName { get; set; }

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public string PropertyFamilyName { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptSubTypePropertyFamilyRef,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PropertyFamilyName;
        }

        /// <summary>
        /// Links the ConceptSubTypePropertyFamilyRef to the parent ConceptSubType and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="conceptSubType"></param>
        public void Fixup(ConceptSubType conceptSubType)
        {
            ConceptSubType = conceptSubType;
            ConceptSubTypeRegistry = conceptSubType.ConceptSubTypeRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptSubType
        /// </summary>
        internal ConceptSubTypeRegistry ConceptSubTypeRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="ConceptSubType" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptSubType ConceptSubType { get; private set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily ConceptPropertyFamily => ConceptSubTypeRegistry
            .ConceptRegistry
            .FindPropertyFamilyByPropertyFamilyName(PropertyFamilyName);

        #endregion
    }
}

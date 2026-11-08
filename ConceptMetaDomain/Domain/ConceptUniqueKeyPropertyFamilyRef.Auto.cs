/****************************
 * ConceptUniqueKeyPropertyFamilyRef.Auto.cs
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
    /// A record that associates a given unique key with a particular family of properties, signifying that the family of properties is relevant to that unique key
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptUniqueKeyPropertyFamilyRef: {PropertyFamilyName}")]
    [Newtonsoft.Json.JsonConverter(typeof(ScalarJsonConverter), "PropertyFamilyName")]
    public partial class ConceptUniqueKeyPropertyFamilyRef
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
        /// The UniqueKeyName value for the ConceptUniqueKey
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string UniqueKeyName { get; set; }

        /// <summary>
        /// The business-facing identifier for the ConceptPropertyFamily
        /// </summary>
        [DataMember]
        public string PropertyFamilyName { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptUniqueKeyPropertyFamilyRef,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return PropertyFamilyName;
        }

        /// <summary>
        /// Links the ConceptUniqueKeyPropertyFamilyRef to the parent ConceptUniqueKey and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="conceptUniqueKey"></param>
        public void Fixup(ConceptUniqueKey conceptUniqueKey)
        {
            ConceptUniqueKey = conceptUniqueKey;
            ConceptUniqueKeyRegistry = conceptUniqueKey.ConceptUniqueKeyRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptUniqueKey
        /// </summary>
        internal ConceptUniqueKeyRegistry ConceptUniqueKeyRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="ConceptUniqueKey" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptUniqueKey ConceptUniqueKey { get; private set; }

        /// <summary>
        /// The associated <see cref="ConceptPropertyFamily" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptPropertyFamily ConceptPropertyFamily => ConceptUniqueKeyRegistry
            .ConceptRegistry
            .FindPropertyFamilyByPropertyFamilyName(PropertyFamilyName);

        #endregion
    }
}

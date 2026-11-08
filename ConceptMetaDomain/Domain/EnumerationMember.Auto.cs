/****************************
 * EnumerationMember.Auto.cs
 ****************************/
using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// An item within a constrained vocabulary
    /// </summary>
    [DataContract]
    [DebuggerDisplay("EnumerationMember: {EnumeratedValue}")]
    public partial class EnumerationMember
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
        /// The DataTypeName value for the DataType
        /// NOTE: This is an implied property
        /// </summary>
        [JsonIgnore]
        public string DataTypeName
        {
            get
            {
                return Enumeration?.DataTypeName;
            }
        }

        /// <summary>
        /// The EnumerationName value for the Enumeration
        /// NOTE: This is a reference (or partial reference) to the entity that is normally present as the parent within the DOM.
        /// A nullable data type has been chosen, with the intention that:
        /// a) the property value should be set to null and omitted from any message in which the current entity is nested within that parent entity.
        /// b) the property value should be set to a value and included in any message in which the current entity appears elsewhere in the DOM.
        /// </summary>
        [JsonIgnore]
        [DataMember]
        public string EnumerationName { get; set; }

        [DataMember]
        public string EnumeratedValue { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string EnumeratedValueDescription { get; set; }

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the EnumerationMember,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EnumeratedValue;
        }

        /// <summary>
        /// Links the EnumerationMember to the parent Enumeration and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="enumeration"></param>
        public void Fixup(Enumeration enumeration)
        {
            Enumeration = enumeration;
            EnumerationRegistry = enumeration.EnumerationRegistry;
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the Enumeration
        /// </summary>
        internal EnumerationRegistry EnumerationRegistry { get; private set; }

        /// <summary>
        /// The associated <see cref="Enumeration" /> object
        /// </summary>
        [JsonIgnore]
        public Enumeration Enumeration { get; private set; }

        #endregion
    }
}

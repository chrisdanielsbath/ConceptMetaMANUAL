/****************************
 * Enumeration.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A constrained vocabulary
    /// </summary>
    [DataContract]
    [DebuggerDisplay("Enumeration: {EnumerationName}")]
    public partial class Enumeration
    {

        #region Constructors
        public Enumeration()
        {
            EnumerationRegistry = new EnumerationRegistry(this);
        }

        #endregion

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

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string EnumerationName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string EnumerationDescription { get; set; }

        /// <summary>
        /// The DataTypeName value for the DataType
        /// </summary>
        [DataMember]
        public string DataTypeName { get; set; }

        /// <summary>
        /// The set of child <see cref="EnumerationMember" /> objects
        /// </summary>
        [DataMember]
        public IList<EnumerationMember> EnumeratedValues => EnumerationRegistry.EnumeratedValues;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the Enumeration,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return EnumerationName;
        }

        /// <summary>
        /// Links the Enumeration to the parent ConceptModel and recurses in order to link up child objects similarly
        /// </summary>
        /// <param name="conceptModel"></param>
        public void Fixup(ConceptModel conceptModel)
        {
            ConceptModel = conceptModel;
            EnumerationRegistry.ConceptModelRegistry = conceptModel.ConceptModelRegistry;
            foreach (EnumerationMember e in EnumeratedValues)
            {
                e.Fixup(this);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the Enumeration
        /// </summary>
        internal EnumerationRegistry EnumerationRegistry { get; }

        /// <summary>
        /// The associated <see cref="ConceptModel" /> object
        /// </summary>
        [JsonIgnore]
        public ConceptModel ConceptModel { get; private set; }

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [JsonIgnore]
        public IImmutableList<Concept> Concepts => EnumerationRegistry
            .ConceptModelRegistry
            .GetConceptsByEnumerationName(EnumerationName);

        /// <summary>
        /// The associated <see cref="DataType" /> object
        /// </summary>
        [JsonIgnore]
        public DataType DataType => EnumerationRegistry
            .ConceptModelRegistry
            .FindDataTypeByDataTypeName(DataTypeName);

        #endregion
    }
}

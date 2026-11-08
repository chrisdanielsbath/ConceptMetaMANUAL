/****************************
 * ConceptModel.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using ConceptMeta.DomainRegistryClasses;

namespace ConceptMeta.Domain
{
    /// <summary>
    /// A model, made primarily of scalar concepts and object concepts
    /// </summary>
    [DataContract]
    [DebuggerDisplay("ConceptModel: {ModelName}")]
    public partial class ConceptModel
    {

        #region Constructors
        public ConceptModel()
        {
            ConceptModelRegistry = new ConceptModelRegistry(this);
        }

        #endregion

        #region Instance Properties

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public string ModelName { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [DataMember]
        public int? DefaultStringLength { get; set; }

        /// <summary>
        /// The set of child <see cref="DataType" /> objects
        /// </summary>
        [DataMember]
        public IList<DataType> DataTypes => ConceptModelRegistry.DataTypes;

        /// <summary>
        /// The set of child <see cref="Enumeration" /> objects
        /// </summary>
        [DataMember]
        public IList<Enumeration> Enumerations => ConceptModelRegistry.Enumerations;

        /// <summary>
        /// The set of child <see cref="Concept" /> objects
        /// </summary>
        [DataMember]
        public IList<Concept> Concepts => ConceptModelRegistry.Concepts;

        #endregion

        #region Instance Methods

        /// <summary>
        /// Returns a string value to represent the ConceptModel,
        /// in a format that is suitable for display within a user interface
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ModelName;
        }

        /// <summary>
        /// Links child objects to this ConceptModel and recurses in order to link up child objects similarly
        /// </summary>
        public void Fixup()
        {
            foreach (DataType d in DataTypes)
            {
                d.Fixup(this);
            }
            foreach (Enumeration e in Enumerations)
            {
                e.Fixup(this);
            }
            foreach (Concept c in Concepts)
            {
                c.Fixup(this);
            }
        }

        #endregion

        #region Navigation Properties

        /// <summary>
        /// The registry that manages the child objects owned by the ConceptModel
        /// </summary>
        internal ConceptModelRegistry ConceptModelRegistry { get; }

        #endregion
    }
}

/****************************
 * ConceptModelRegistry.Auto.cs
 ****************************/
using System.Collections.Immutable;
using System.Linq;
using ConceptMeta.Collections;
using DomainModels = ConceptMeta.Domain;

namespace ConceptMeta.DomainRegistryClasses
{
    /// <summary>
    /// Registry to manage the object-valued children of a particular ConceptModel domain object
    /// </summary>
    internal partial class ConceptModelRegistry
    {

        #region Instance Variables
        private readonly IndexedSet<DomainModels.DataType> dataTypes = new IndexedSet<DomainModels.DataType>(d => d.DataTypeName);
        private readonly IndexedSet<DomainModels.Enumeration> enumerations = new IndexedSet<DomainModels.Enumeration>(e => e.EnumerationName);
        private readonly IndexedSet<DomainModels.Concept> concepts = new IndexedSet<DomainModels.Concept>(c => c.ConceptName);

        #endregion

        #region Constructors
        internal ConceptModelRegistry(DomainModels.ConceptModel conceptModel)
        {
            ConceptModel = conceptModel;
        }

        #endregion

        #region Instance Properties
        private DomainModels.ConceptModel ConceptModel { get; }
        internal IndexedSet<DomainModels.DataType> DataTypes => dataTypes;
        internal IndexedSet<DomainModels.Enumeration> Enumerations => enumerations;
        internal IndexedSet<DomainModels.Concept> Concepts => concepts;

        #endregion

        #region "Find one" methods
        internal DomainModels.DataType FindDataTypeByDataTypeName(string dataTypeName)
        {
            if (DataTypes.ContainsKey(dataTypeName))
            {
                return DataTypes.GetItem(dataTypeName);
            }
            return null;
        }
        internal DomainModels.Enumeration FindEnumerationByEnumerationName(string enumerationName)
        {
            if (Enumerations.ContainsKey(enumerationName))
            {
                return Enumerations.GetItem(enumerationName);
            }
            return null;
        }
        internal DomainModels.Concept FindConceptByConceptName(string conceptName)
        {
            if (Concepts.ContainsKey(conceptName))
            {
                return Concepts.GetItem(conceptName);
            }
            return null;
        }

        #endregion

        #region "Get many" methods

        /// <summary>
        /// For Concept.BasedOnConcept
        /// </summary>
        /// <param name="basedOnConceptName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetDerivedConceptsByBasedOnConceptName(string basedOnConceptName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.BasedOnConceptName == basedOnConceptName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.DataType
        /// </summary>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetConceptsByDataTypeName(string dataTypeName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.DataTypeName == dataTypeName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.Enumeration
        /// </summary>
        /// <param name="enumerationName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetConceptsByEnumerationName(string enumerationName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.EnumerationName == enumerationName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.ReferencedConcept
        /// </summary>
        /// <param name="referencedConceptName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetReferencedByConceptsByReferencedConceptName(string referencedConceptName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.ReferencedConceptName == referencedConceptName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.ReferencedUniqueKey
        /// </summary>
        /// <param name="referencedConceptName"></param>
        /// <param name="referencedUniqueKeyName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetUniqueKeyRefsByReferencedConceptNameReferencedUniqueKeyName(
            string referencedConceptName,
            string referencedUniqueKeyName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.ReferencedConceptName == referencedConceptName)
                .Where(c => c.ReferencedUniqueKeyName == referencedUniqueKeyName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.SpecialisedConcept
        /// </summary>
        /// <param name="specialisedConceptName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetSpecialisedByConceptsBySpecialisedConceptName(string specialisedConceptName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.SpecialisedConceptName == specialisedConceptName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Concept.SpecialisedSubType
        /// </summary>
        /// <param name="specialisedConceptName"></param>
        /// <param name="specialisedSubTypeName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Concept> GetSubTypeRefsBySpecialisedConceptNameSpecialisedSubTypeName(
            string specialisedConceptName,
            string specialisedSubTypeName)
        {
            ImmutableList<DomainModels.Concept> result = Concepts
                .Where(c => c.SpecialisedConceptName == specialisedConceptName)
                .Where(c => c.SpecialisedSubTypeName == specialisedSubTypeName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For ConceptRef.ReferencedConcept
        /// </summary>
        /// <param name="referencedConceptName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.ConceptRef> GetReferencedByPropertiesByReferencedConceptName(string referencedConceptName)
        {
            ImmutableList<DomainModels.ConceptRef> result = Concepts
                .SelectMany(c => c.Properties)
                .Where(c => c.ReferencedConceptName == referencedConceptName)
                .ToImmutableList();
            return result;
        }

        /// <summary>
        /// For Enumeration.DataType
        /// </summary>
        /// <param name="dataTypeName"></param>
        /// <returns></returns>
        internal IImmutableList<DomainModels.Enumeration> GetEnumerationsByDataTypeName(string dataTypeName)
        {
            ImmutableList<DomainModels.Enumeration> result = Enumerations
                .Where(e => e.DataTypeName == dataTypeName)
                .ToImmutableList();
            return result;
        }

        #endregion
    }
}

/****************************
 * ConceptModelBlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Blueprint.Comparers;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositories
{
    /// <summary>
    /// Repository class for the <see cref="BlueprintModels.ConceptModel" /> entity
    /// </summary>
    public partial class ConceptModelBlueprintRepository
        : ConceptMetaDbBlueprintAggregateRootRepository<BlueprintModels.ConceptModel, DbEntities.ConceptModel, IConceptMetaDbUnitOfWork>,
        IConceptModelBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;
        protected IDataTypeBlueprintRepository DataTypeRepository => BlueprintUnitOfWork.DataTypes;
        protected IEnumerationBlueprintRepository EnumerationRepository => BlueprintUnitOfWork.Enumerations;
        protected IEnumerationMemberBlueprintRepository EnumerationMemberRepository => BlueprintUnitOfWork.EnumerationMembers;
        protected IConceptBlueprintRepository ConceptRepository => BlueprintUnitOfWork.Concepts;
        protected IIncludeBlueprintRepository IncludeRepository => BlueprintUnitOfWork.Includes;
        protected IQualifierBlueprintRepository QualifierRepository => BlueprintUnitOfWork.Qualifiers;
        protected IConceptPropertyFamilyBlueprintRepository ConceptPropertyFamilyRepository => BlueprintUnitOfWork.ConceptPropertyFamilies;
        protected IConceptUniqueKeyBlueprintRepository ConceptUniqueKeyRepository => BlueprintUnitOfWork.ConceptUniqueKeys;
        protected IConceptUniqueKeyPropertyFamilyRefBlueprintRepository ConceptUniqueKeyPropertyFamilyRefRepository => BlueprintUnitOfWork.ConceptUniqueKeyPropertyFamilyRefs;
        protected IConceptSubTypeBlueprintRepository ConceptSubTypeRepository => BlueprintUnitOfWork.ConceptSubTypes;
        protected IConceptSubTypePropertyFamilyRefBlueprintRepository ConceptSubTypePropertyFamilyRefRepository => BlueprintUnitOfWork.ConceptSubTypePropertyFamilyRefs;
        protected IConceptRefBlueprintRepository ConceptRefRepository => BlueprintUnitOfWork.ConceptRefs;

        #endregion

        #region Constructors
        public ConceptModelBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbAggregateRootRepository<DbEntities.ConceptModel> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Identify the items as they currently exist in the data store
        /// </summary>
        /// <param name="oldConceptModelAggregates"></param>
        /// <param name="conceptModel_ItemsOld"></param>
        /// <param name="conceptModel_DataTypes_ItemsOld"></param>
        /// <param name="conceptModel_Enumerations_ItemsOld"></param>
        /// <param name="conceptModel_Enumerations_EnumeratedValues_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_Includes_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_Qualifiers_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_PropertyFamilies_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_UniqueKeys_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_SubTypes_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld"></param>
        /// <param name="conceptModel_Concepts_Properties_ItemsOld"></param>
        private void IdentifyOldItems(
            IQueryable<BlueprintModels.ConceptModel> oldConceptModelAggregates,
            out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsOld,
            out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsOld,
            out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsOld,
            out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsOld,
            out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsOld,
            out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsOld,
            out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld,
            out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsOld)
        {
            //-------
            // Identify old items
            //-------

            // identify old items for ConceptModel (Aggregate Root)
            conceptModel_ItemsOld = oldConceptModelAggregates
                    .ToList();

            // identify old items for DataTypes (Level 1)
            conceptModel_DataTypes_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes)
                    .ToList();

            // identify old items for Enumerations (Level 2)
            conceptModel_Enumerations_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .ToList();

            // identify old items for Enumerations.EnumeratedValues (Level 3)
            conceptModel_Enumerations_EnumeratedValues_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues)
                    .ToList();

            // identify old items for Concepts (Level 3)
            conceptModel_Concepts_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .ToList();

            // identify old items for Concepts.Includes (Level 4)
            conceptModel_Concepts_Includes_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes)
                    .ToList();

            // identify old items for Concepts.Qualifiers (Level 4)
            conceptModel_Concepts_Qualifiers_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers)
                    .ToList();

            // identify old items for Concepts.PropertyFamilies (Level 4)
            conceptModel_Concepts_PropertyFamilies_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies)
                    .ToList();

            // identify old items for Concepts.UniqueKeys (Level 4)
            conceptModel_Concepts_UniqueKeys_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .ToList();

            // identify old items for Concepts.SubTypes (Level 4)
            conceptModel_Concepts_SubTypes_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .ToList();

            // identify old items for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs)
                    .ToList();

            // identify old items for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs)
                    .ToList();

            // identify old items for Concepts.Properties (Level 5)
            conceptModel_Concepts_Properties_ItemsOld = oldConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties)
                    .ToList();
        }
        private void PopulateConceptModelKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for ConceptModel (Aggregate Root)
            PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates);

            // populate missing primary keys for ConceptModel (Aggregate Root)
            PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates);
        }
        private async Task PopulateConceptModelKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for ConceptModel (Aggregate Root)
            await PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates);

            // populate missing primary keys for ConceptModel (Aggregate Root)
            await PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates);
        }
        private void PropagateConceptModelKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for ConceptModel (Aggregate Root) are propagated to children
            CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates);
        }
        private void PopulateDataTypesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for DataTypes (Level 1)
            DataTypeRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes));

            // populate missing primary keys for DataTypes (Level 1)
            DataTypeRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes));
        }
        private async Task PopulateDataTypesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for DataTypes (Level 1)
            await DataTypeRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes));

            // populate missing primary keys for DataTypes (Level 1)
            await DataTypeRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes));
        }
        private void PropagateDataTypesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for DataTypes (Level 1) are propagated to children
            DataTypeRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes));
        }
        private void PopulateEnumerationsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Enumerations (Level 2)
            EnumerationRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations));

            // populate missing primary keys for Enumerations (Level 2)
            EnumerationRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations));
        }
        private async Task PopulateEnumerationsKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Enumerations (Level 2)
            await EnumerationRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations));

            // populate missing primary keys for Enumerations (Level 2)
            await EnumerationRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations));
        }
        private void PropagateEnumerationsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for Enumerations (Level 2) are propagated to children
            EnumerationRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations));
        }
        private void PopulateEnumerations_EnumeratedValuesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues));

            // populate missing primary keys for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues));
        }
        private async Task PopulateEnumerations_EnumeratedValuesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Enumerations.EnumeratedValues (Level 3)
            await EnumerationMemberRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues));

            // populate missing primary keys for Enumerations.EnumeratedValues (Level 3)
            await EnumerationMemberRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues));
        }
        private void PopulateConceptsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts (Level 3)
            ConceptRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts));

            // populate missing primary keys for Concepts (Level 3)
            ConceptRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts));
        }
        private async Task PopulateConceptsKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts (Level 3)
            await ConceptRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts));

            // populate missing primary keys for Concepts (Level 3)
            await ConceptRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts));
        }
        private void AddConcepts(
            IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates,
            IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToAdd)
        {
            // the first set of concepts to be added will consist of new independent concepts and
            // new concepts that don't depend on another new concept

            IEnumerable<string> newConceptTags = 
                conceptModel_Concepts_ItemsToAdd
                     .Select(concept => concept.ModelName + "|" + concept.ConceptName);

            // identify new concepts that are dependent on existing concepts
            IEnumerable <BlueprintModels.Concept> moreConceptsToAdd =
                conceptModel_Concepts_ItemsToAdd
                    .Where(concept => 
                        false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.BasedOnConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.BasedOnConceptName)
                        )
                        && false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.ReferencedConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.ReferencedConceptName)
                        )
                        && false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.SpecialisedConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.SpecialisedConceptName)
                        )
                    )
                    .ToList();

            // identify independent concepts and union them with those identified above
            IEnumerable<BlueprintModels.Concept> conceptsToAdd =
                conceptModel_Concepts_ItemsToAdd
                    .Where(concept => 
                        String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.BasedOnConceptName)
                        && String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.ReferencedConceptName)
                        && String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.SpecialisedConceptName))
                    .Union(moreConceptsToAdd)
                    .ToList();

            // conceptsToAdd now contains the first set of concepts to be added

            while (conceptsToAdd.Count() > 0)
            {
                ConceptRepository.AddSterilisedRange(conceptsToAdd);

                DbUnitOfWork.SaveChanges();

                // get the ids of the newly added concepts, and update the details we hold accordingly
                foreach (BlueprintModels.Concept conceptToAdd in conceptsToAdd)
                {
                    DbEntities.Concept conceptAdded = DbUnitOfWork.Concepts.GetByModelNameConceptName(conceptToAdd.ModelName, conceptToAdd.ConceptName);
                    conceptToAdd.ConceptId = conceptAdded.ConceptId;
                }

                IEnumerable<string> newlyAddedConceptTags = conceptsToAdd
                    .Select(concept => concept.ModelName + "|" + concept.ConceptName);

                // get the next set of concepts to be added
                conceptsToAdd =
                    conceptModel_Concepts_ItemsToAdd
                        .Where(concept => 
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.BasedOnConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.BasedOnConceptName)
                            )
                            && false ==
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.ReferencedConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.ReferencedConceptName)
                            )
                            && false ==
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.SpecialisedConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.SpecialisedConceptName)
                            )
                        )
                        .ToList();

                // populate foreign keys for Concepts (Level 3)
                ConceptRepository.PopulateForeignKeyValuesFromParents(
                    conceptsToAdd);
            }
            // we've now done all the Concept additions.  We'll handle updates and removals later
        }
        private async Task AddConceptsAsync(
            IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates,
            IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToAdd)
        {
            // the first set of concepts to be added will consist of new independent concepts and
            // new concepts that don't depend on another new concept

            IEnumerable<string> newConceptTags = 
                conceptModel_Concepts_ItemsToAdd
                     .Select(concept => concept.ModelName + "|" + concept.ConceptName);

            // identify new concepts that are dependent on existing concepts
            IEnumerable <BlueprintModels.Concept> moreConceptsToAdd =
                conceptModel_Concepts_ItemsToAdd
                    .Where(concept => 
                        false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.BasedOnConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.BasedOnConceptName)
                        )
                        && false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.ReferencedConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.ReferencedConceptName)
                        )
                        && false ==
                        (
                            !String.IsNullOrEmpty(concept.ModelName)
                            && !String.IsNullOrEmpty(concept.SpecialisedConceptName)
                            && newConceptTags.Contains(concept.ModelName + "|" + concept.SpecialisedConceptName)
                        )
                    )
                    .ToList();

            // identify independent concepts and union them with those identified above
            IEnumerable<BlueprintModels.Concept> conceptsToAdd =
                conceptModel_Concepts_ItemsToAdd
                    .Where(concept => 
                        String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.BasedOnConceptName)
                        && String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.ReferencedConceptName)
                        && String.IsNullOrEmpty(concept.ModelName)
                        && String.IsNullOrEmpty(concept.SpecialisedConceptName))
                    .Union(moreConceptsToAdd)
                    .ToList();

            // conceptsToAdd now contains the first set of concepts to be added

            while (conceptsToAdd.Count() > 0)
            {
                ConceptRepository.AddSterilisedRange(conceptsToAdd);

                await DbUnitOfWork.SaveChangesAsync();

                // get the ids of the newly added concepts, and update the details we hold accordingly
                foreach (BlueprintModels.Concept conceptToAdd in conceptsToAdd)
                {
                    DbEntities.Concept conceptAdded = await DbUnitOfWork.Concepts.GetByModelNameConceptNameAsync(conceptToAdd.ModelName, conceptToAdd.ConceptName);
                    conceptToAdd.ConceptId = conceptAdded.ConceptId;
                }

                IEnumerable<string> newlyAddedConceptTags = conceptsToAdd
                    .Select(concept => concept.ModelName + "|" + concept.ConceptName);

                // get the next set of concepts to be added
                conceptsToAdd =
                    conceptModel_Concepts_ItemsToAdd
                        .Where(concept => 
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.BasedOnConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.BasedOnConceptName)
                            )
                            && false ==
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.ReferencedConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.ReferencedConceptName)
                            )
                            && false ==
                            (
                                (
                                    concept.ConceptId == default || concept.ConceptId == default(int)
                                )
                                && !String.IsNullOrEmpty(concept.ModelName)
                                && !String.IsNullOrEmpty(concept.SpecialisedConceptName)
                                && newConceptTags.Contains(concept.ModelName + "|" + concept.SpecialisedConceptName)
                            )
                        )
                        .ToList();

                // populate foreign keys for Concepts (Level 3)
                await ConceptRepository.PopulateForeignKeyValuesFromParentsAsync(
                    conceptsToAdd);
            }
            // we've now done all the Concept additions.  We'll handle updates and removals later
        }
        private void PropagateConceptsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for Concepts (Level 3) are propagated to children
            ConceptRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts));
        }
        private void PopulateConcepts_IncludesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Includes (Level 4)
            IncludeRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes));

            // populate missing primary keys for Concepts.Includes (Level 4)
            IncludeRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes));
        }
        private async Task PopulateConcepts_IncludesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Includes (Level 4)
            await IncludeRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes));

            // populate missing primary keys for Concepts.Includes (Level 4)
            await IncludeRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes));
        }
        private void PopulateConcepts_QualifiersKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Qualifiers (Level 4)
            QualifierRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers));

            // populate missing primary keys for Concepts.Qualifiers (Level 4)
            QualifierRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers));
        }
        private async Task PopulateConcepts_QualifiersKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Qualifiers (Level 4)
            await QualifierRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers));

            // populate missing primary keys for Concepts.Qualifiers (Level 4)
            await QualifierRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers));
        }
        private void PopulateConcepts_PropertyFamiliesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies));

            // populate missing primary keys for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies));
        }
        private async Task PopulateConcepts_PropertyFamiliesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.PropertyFamilies (Level 4)
            await ConceptPropertyFamilyRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies));

            // populate missing primary keys for Concepts.PropertyFamilies (Level 4)
            await ConceptPropertyFamilyRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies));
        }
        private void PropagateConcepts_PropertyFamiliesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for Concepts.PropertyFamilies (Level 4) are propagated to children
            ConceptPropertyFamilyRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies));
        }
        private void PopulateConcepts_UniqueKeysKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys));

            // populate missing primary keys for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys));
        }
        private async Task PopulateConcepts_UniqueKeysKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.UniqueKeys (Level 4)
            await ConceptUniqueKeyRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys));

            // populate missing primary keys for Concepts.UniqueKeys (Level 4)
            await ConceptUniqueKeyRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys));
        }
        private void PropagateConcepts_UniqueKeysKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for Concepts.UniqueKeys (Level 4) are propagated to children
            ConceptUniqueKeyRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys));
        }
        private void PopulateConcepts_SubTypesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes));

            // populate missing primary keys for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes));
        }
        private async Task PopulateConcepts_SubTypesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.SubTypes (Level 4)
            await ConceptSubTypeRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes));

            // populate missing primary keys for Concepts.SubTypes (Level 4)
            await ConceptSubTypeRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes));
        }
        private void PropagateConcepts_SubTypesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // ensure logical business keys for Concepts.SubTypes (Level 4) are propagated to children
            ConceptSubTypeRepository.CopyLogicalBusinessKeysToNestedObjects(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes));
        }
        private void PopulateConcepts_UniqueKeys_PropertyFamilyRefsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs));

            // populate missing primary keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs));
        }
        private async Task PopulateConcepts_UniqueKeys_PropertyFamilyRefsKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            await ConceptUniqueKeyPropertyFamilyRefRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs));

            // populate missing primary keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            await ConceptUniqueKeyPropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs));
        }
        private void PopulateConcepts_SubTypes_PropertyFamilyRefsKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs));

            // populate missing primary keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs));
        }
        private async Task PopulateConcepts_SubTypes_PropertyFamilyRefsKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            await ConceptSubTypePropertyFamilyRefRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs));

            // populate missing primary keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            await ConceptSubTypePropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs));
        }
        private void PopulateConcepts_PropertiesKeys(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Properties (Level 5)
            ConceptRefRepository.PopulateForeignKeyValuesFromParents(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties));

            // populate missing primary keys for Concepts.Properties (Level 5)
            ConceptRefRepository.PopulateMissingPrimaryKeysIfKnown(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties));
        }
        private async Task PopulateConcepts_PropertiesKeysAsync(IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates)
        {
            // populate foreign keys for Concepts.Properties (Level 5)
            await ConceptRefRepository.PopulateForeignKeyValuesFromParentsAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties));

            // populate missing primary keys for Concepts.Properties (Level 5)
            await ConceptRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties));
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Method to identify and perform necessary changes
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        protected override void AddAndUpdateAndRemoveEntitiesForAggregates(
            IEnumerable<BlueprintModels.ConceptModel> oldItems,
            IEnumerable<BlueprintModels.ConceptModel> newItems)
        {
            // renumber items as required
            RenumberNestedObjects(newItems, true);

            IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates = newItems.AsQueryable();
            IQueryable<BlueprintModels.ConceptModel> oldConceptModelAggregates = oldItems.AsQueryable();

            //-------
            // Identify old items
            //-------

            IdentifyOldItems(
                oldConceptModelAggregates,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsOld,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsOld,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsOld,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsOld,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsOld,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsOld,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsOld);

            //-------
            // Handle Level 0 PRE SAVE
            //-------

            // populate keys for ConceptModel (Aggregate Root)
            PopulateConceptModelKeys(newConceptModelAggregates);

            // identify items to add, update and remove for ConceptModel (Aggregate Root)
            IdentifyItemsPerAction(
                conceptModel_ItemsOld,
                newConceptModelAggregates,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToRemove);

            // perform additions and updates for ConceptModel (Aggregate Root)
            AddSterilisedRange(conceptModel_ItemsToAdd);
            UpdateSterilisedRange(conceptModel_ItemsToUpdate1);

            //-------
            // Save Level 0
            //-------

            // save the changes to Level 0 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 0 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 0 items will now have unique keys.
            // ensure newly allocated keys are populated
            PopulateConceptModelKeys(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 0 items to child objects
            PropagateConceptModelKeys(newConceptModelAggregates);

            //-------
            // Handle Level 1 PRE SAVE
            //-------

            // populate keys for DataTypes (Level 1)
            PopulateDataTypesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for DataTypes (Level 1)
            DataTypeRepository.IdentifyItemsPerAction(
                conceptModel_DataTypes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes),
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToAdd,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToRemove);

            // perform additions and updates for DataTypes (Level 1)
            DataTypeRepository.AddSterilisedRange(conceptModel_DataTypes_ItemsToAdd);
            DataTypeRepository.UpdateSterilisedRange(conceptModel_DataTypes_ItemsToUpdate1);

            //-------
            // Save Level 1
            //-------

            // save the changes to Level 1 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 1 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 1 items will now have unique keys.
            // ensure newly allocated keys are populated
            PopulateDataTypesKeys(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 1 items to child objects
            PropagateDataTypesKeys(newConceptModelAggregates);

            //-------
            // Handle Level 2 PRE SAVE
            //-------

            // populate keys for Enumerations (Level 2)
            PopulateEnumerationsKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Enumerations (Level 2)
            EnumerationRepository.IdentifyItemsPerAction(
                conceptModel_Enumerations_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations),
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToAdd,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToRemove);

            // perform additions and updates for Enumerations (Level 2)
            EnumerationRepository.AddSterilisedRange(conceptModel_Enumerations_ItemsToAdd);
            EnumerationRepository.UpdateSterilisedRange(conceptModel_Enumerations_ItemsToUpdate1);

            //-------
            // Save Level 2
            //-------

            // save the changes to Level 2 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 2 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 2 items will now have unique keys.
            // ensure newly allocated keys are populated
            PopulateEnumerationsKeys(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 2 items to child objects
            PropagateEnumerationsKeys(newConceptModelAggregates);

            //-------
            // Handle Level 3 PRE SAVE
            //-------

            // populate keys for Enumerations.EnumeratedValues (Level 3)
            PopulateEnumerations_EnumeratedValuesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.IdentifyItemsPerAction(
                conceptModel_Enumerations_EnumeratedValues_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues),
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToAdd,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToRemove);

            // perform additions and updates for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.AddSterilisedRange(conceptModel_Enumerations_EnumeratedValues_ItemsToAdd);
            EnumerationMemberRepository.UpdateSterilisedRange(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate1);

            // populate keys for Concepts (Level 3)
            PopulateConceptsKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts (Level 3)
            ConceptRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts),
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToAdd,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToRemove);

            // perform additions for Concepts (Level 3) (we'll handle updates later)
            AddConcepts(
                newConceptModelAggregates,
                conceptModel_Concepts_ItemsToAdd);

            //-------
            // Save Level 3
            //-------

            // save the changes to Level 3 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 3 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 3 items will now have unique keys.
            // ensure newly allocated keys are populated
            PopulateConceptsKeys(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 3 items to child objects
            PropagateConceptsKeys(newConceptModelAggregates);

            // perform updates for Concepts (Level 3)
            ConceptRepository.UpdateSterilisedRange(conceptModel_Concepts_ItemsToUpdate1);

            // re-save the changes to Level 3 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 4 PRE SAVE
            //-------

            // populate keys for Concepts.Includes (Level 4)
            PopulateConcepts_IncludesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Includes (Level 4)
            IncludeRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Includes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes),
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToAdd,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToRemove);

            // perform additions and updates for Concepts.Includes (Level 4)
            IncludeRepository.AddSterilisedRange(conceptModel_Concepts_Includes_ItemsToAdd);
            IncludeRepository.UpdateSterilisedRange(conceptModel_Concepts_Includes_ItemsToUpdate1);

            // populate keys for Concepts.Qualifiers (Level 4)
            PopulateConcepts_QualifiersKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Qualifiers (Level 4)
            QualifierRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Qualifiers_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers),
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToAdd,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToRemove);

            // perform additions and updates for Concepts.Qualifiers (Level 4)
            QualifierRepository.AddSterilisedRange(conceptModel_Concepts_Qualifiers_ItemsToAdd);
            QualifierRepository.UpdateSterilisedRange(conceptModel_Concepts_Qualifiers_ItemsToUpdate1);

            // populate keys for Concepts.PropertyFamilies (Level 4)
            PopulateConcepts_PropertyFamiliesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_PropertyFamilies_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies),
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToRemove);

            // perform additions and updates for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.AddSterilisedRange(conceptModel_Concepts_PropertyFamilies_ItemsToAdd);
            ConceptPropertyFamilyRepository.UpdateSterilisedRange(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate1);

            // populate keys for Concepts.UniqueKeys (Level 4)
            PopulateConcepts_UniqueKeysKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_UniqueKeys_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys),
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToRemove);

            // perform additions and updates for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.AddSterilisedRange(conceptModel_Concepts_UniqueKeys_ItemsToAdd);
            ConceptUniqueKeyRepository.UpdateSterilisedRange(conceptModel_Concepts_UniqueKeys_ItemsToUpdate1);

            // populate keys for Concepts.SubTypes (Level 4)
            PopulateConcepts_SubTypesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_SubTypes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes),
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToRemove);

            // perform additions and updates for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.AddSterilisedRange(conceptModel_Concepts_SubTypes_ItemsToAdd);
            ConceptSubTypeRepository.UpdateSterilisedRange(conceptModel_Concepts_SubTypes_ItemsToUpdate1);

            //-------
            // Save Level 4
            //-------

            // save the changes to Level 4 objects
            DbUnitOfWork.SaveChanges();

            //-------
            // Handle Level 4 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 4 items will now have unique keys.
            // ensure newly allocated keys are populated
            PopulateConcepts_PropertyFamiliesKeys(newConceptModelAggregates);
            PopulateConcepts_UniqueKeysKeys(newConceptModelAggregates);
            PopulateConcepts_SubTypesKeys(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 4 items to child objects
            PropagateConcepts_PropertyFamiliesKeys(newConceptModelAggregates);
            PropagateConcepts_UniqueKeysKeys(newConceptModelAggregates);
            PropagateConcepts_SubTypesKeys(newConceptModelAggregates);

            //-------
            // Handle Level 5 PRE SAVE
            //-------

            // populate keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            PopulateConcepts_UniqueKeys_PropertyFamilyRefsKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs),
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToRemove);

            // perform additions and updates for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.AddSterilisedRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToAdd);
            ConceptUniqueKeyPropertyFamilyRefRepository.UpdateSterilisedRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate1);

            // populate keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            PopulateConcepts_SubTypes_PropertyFamilyRefsKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs),
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToRemove);

            // perform additions and updates for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.AddSterilisedRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToAdd);
            ConceptSubTypePropertyFamilyRefRepository.UpdateSterilisedRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate1);

            // populate keys for Concepts.Properties (Level 5)
            PopulateConcepts_PropertiesKeys(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Properties (Level 5)
            ConceptRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Properties_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties),
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToRemove);

            // perform additions and updates for Concepts.Properties (Level 5)
            ConceptRefRepository.AddSterilisedRange(conceptModel_Concepts_Properties_ItemsToAdd);
            ConceptRefRepository.UpdateSterilisedRange(conceptModel_Concepts_Properties_ItemsToUpdate1);

            //-------
            // Save Level 5
            //-------

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            //-------
            // Perform removals and a second round of updates
            //-------

            // now perform removals and a second round of updates working from the bottom up
            // Level 5

            if (conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_UniqueKeys_PropertyFamilyRefs that require further updates (Level 5)
                ConceptUniqueKeyPropertyFamilyRefRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
                ConceptUniqueKeyPropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
                // and perform the updates
                ConceptUniqueKeyPropertyFamilyRefRepository.UpdateRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
            }
            ConceptUniqueKeyPropertyFamilyRefRepository.RemoveRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToRemove);

            if (conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_SubTypes_PropertyFamilyRefs that require further updates (Level 5)
                ConceptSubTypePropertyFamilyRefRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
                ConceptSubTypePropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
                // and perform the updates
                ConceptSubTypePropertyFamilyRefRepository.UpdateRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
            }
            ConceptSubTypePropertyFamilyRefRepository.RemoveRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToRemove);

            if (conceptModel_Concepts_Properties_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Properties that require further updates (Level 5)
                ConceptRefRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_Properties_ItemsToUpdate2);
                ConceptRefRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_Properties_ItemsToUpdate2);
                // and perform the updates
                ConceptRefRepository.UpdateRange(conceptModel_Concepts_Properties_ItemsToUpdate2);
            }
            ConceptRefRepository.RemoveRange(conceptModel_Concepts_Properties_ItemsToRemove);

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 4

            if (conceptModel_Concepts_Includes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Includes that require further updates (Level 4)
                IncludeRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_Includes_ItemsToUpdate2);
                IncludeRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_Includes_ItemsToUpdate2);
                // and perform the updates
                IncludeRepository.UpdateRange(conceptModel_Concepts_Includes_ItemsToUpdate2);
            }
            IncludeRepository.RemoveRange(conceptModel_Concepts_Includes_ItemsToRemove);

            if (conceptModel_Concepts_Qualifiers_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Qualifiers that require further updates (Level 4)
                QualifierRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
                QualifierRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
                // and perform the updates
                QualifierRepository.UpdateRange(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
            }
            QualifierRepository.RemoveRange(conceptModel_Concepts_Qualifiers_ItemsToRemove);

            if (conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_PropertyFamilies that require further updates (Level 4)
                ConceptPropertyFamilyRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
                ConceptPropertyFamilyRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
                // and perform the updates
                ConceptPropertyFamilyRepository.UpdateRange(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
            }
            ConceptPropertyFamilyRepository.RemoveRange(conceptModel_Concepts_PropertyFamilies_ItemsToRemove);

            if (conceptModel_Concepts_UniqueKeys_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_UniqueKeys that require further updates (Level 4)
                ConceptUniqueKeyRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
                ConceptUniqueKeyRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
                // and perform the updates
                ConceptUniqueKeyRepository.UpdateRange(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
            }
            ConceptUniqueKeyRepository.RemoveRange(conceptModel_Concepts_UniqueKeys_ItemsToRemove);

            if (conceptModel_Concepts_SubTypes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_SubTypes that require further updates (Level 4)
                ConceptSubTypeRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
                ConceptSubTypeRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
                // and perform the updates
                ConceptSubTypeRepository.UpdateRange(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
            }
            ConceptSubTypeRepository.RemoveRange(conceptModel_Concepts_SubTypes_ItemsToRemove);

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 3

            if (conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Enumerations_EnumeratedValues that require further updates (Level 3)
                EnumerationMemberRepository.PopulateForeignKeyValuesFromParents(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
                EnumerationMemberRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
                // and perform the updates
                EnumerationMemberRepository.UpdateRange(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
            }
            EnumerationMemberRepository.RemoveRange(conceptModel_Enumerations_EnumeratedValues_ItemsToRemove);

            if (conceptModel_Concepts_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts that require further updates (Level 3)
                ConceptRepository.PopulateForeignKeyValuesFromParents(conceptModel_Concepts_ItemsToUpdate2);
                ConceptRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Concepts_ItemsToUpdate2);
                // and perform the updates
                ConceptRepository.UpdateRange(conceptModel_Concepts_ItemsToUpdate2);
            }
            ConceptRepository.RemoveRange(conceptModel_Concepts_ItemsToRemove);

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 2

            if (conceptModel_Enumerations_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Enumerations that require further updates (Level 2)
                EnumerationRepository.PopulateForeignKeyValuesFromParents(conceptModel_Enumerations_ItemsToUpdate2);
                EnumerationRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_Enumerations_ItemsToUpdate2);
                // and perform the updates
                EnumerationRepository.UpdateRange(conceptModel_Enumerations_ItemsToUpdate2);
            }
            EnumerationRepository.RemoveRange(conceptModel_Enumerations_ItemsToRemove);

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 1

            if (conceptModel_DataTypes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for DataTypes that require further updates (Level 1)
                DataTypeRepository.PopulateForeignKeyValuesFromParents(conceptModel_DataTypes_ItemsToUpdate2);
                DataTypeRepository.PopulateMissingPrimaryKeysIfKnown(conceptModel_DataTypes_ItemsToUpdate2);
                // and perform the updates
                DataTypeRepository.UpdateRange(conceptModel_DataTypes_ItemsToUpdate2);
            }
            DataTypeRepository.RemoveRange(conceptModel_DataTypes_ItemsToRemove);

            // save changes...
            DbUnitOfWork.SaveChanges();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 0

            if (conceptModel_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for ConceptModel (Aggregate Root)
                PopulateForeignKeyValuesFromParents(conceptModel_ItemsToUpdate2);
                PopulateMissingPrimaryKeysIfKnown(conceptModel_ItemsToUpdate2);
                // and perform the updates
                UpdateRange(conceptModel_ItemsToUpdate2);
            }
            RemoveRange(conceptModel_ItemsToRemove);

            //-------
            // Save removals and second round of updates
            //-------

            // save changes
            DbUnitOfWork.SaveChanges();
        }

        /// <summary>
        /// Method to identify and perform necessary changes
        /// </summary>
        /// <param name="oldItems"></param>
        /// <param name="newItems"></param>
        /// <returns></returns>
        protected override async Task AddAndUpdateAndRemoveEntitiesForAggregatesAsync(
            IEnumerable<BlueprintModels.ConceptModel> oldItems,
            IEnumerable<BlueprintModels.ConceptModel> newItems)
        {
            // renumber items as required
            RenumberNestedObjects(newItems, true);

            IQueryable<BlueprintModels.ConceptModel> newConceptModelAggregates = newItems.AsQueryable();
            IQueryable<BlueprintModels.ConceptModel> oldConceptModelAggregates = oldItems.AsQueryable();

            //-------
            // Identify old items
            //-------

            IdentifyOldItems(
                oldConceptModelAggregates,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsOld,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsOld,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsOld,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsOld,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsOld,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsOld,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsOld);

            //-------
            // Handle Level 0 PRE SAVE
            //-------

            // populate keys for ConceptModel (Aggregate Root)
            await PopulateConceptModelKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for ConceptModel (Aggregate Root)
            IdentifyItemsPerAction(
                conceptModel_ItemsOld,
                newConceptModelAggregates,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptModel> conceptModel_ItemsToRemove);

            // perform additions and updates for ConceptModel (Aggregate Root)
            AddSterilisedRange(conceptModel_ItemsToAdd);
            await UpdateSterilisedRangeAsync(conceptModel_ItemsToUpdate1);

            //-------
            // Save Level 0
            //-------

            // save the changes to Level 0 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 0 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 0 items will now have unique keys.
            // ensure newly allocated keys are populated
            await PopulateConceptModelKeysAsync(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 0 items to child objects
            PropagateConceptModelKeys(newConceptModelAggregates);

            //-------
            // Handle Level 1 PRE SAVE
            //-------

            // populate keys for DataTypes (Level 1)
            await PopulateDataTypesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for DataTypes (Level 1)
            DataTypeRepository.IdentifyItemsPerAction(
                conceptModel_DataTypes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.DataTypes != null)
                    .SelectMany(conceptModel => conceptModel.DataTypes),
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToAdd,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.DataType> conceptModel_DataTypes_ItemsToRemove);

            // perform additions and updates for DataTypes (Level 1)
            DataTypeRepository.AddSterilisedRange(conceptModel_DataTypes_ItemsToAdd);
            await DataTypeRepository.UpdateSterilisedRangeAsync(conceptModel_DataTypes_ItemsToUpdate1);

            //-------
            // Save Level 1
            //-------

            // save the changes to Level 1 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 1 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 1 items will now have unique keys.
            // ensure newly allocated keys are populated
            await PopulateDataTypesKeysAsync(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 1 items to child objects
            PropagateDataTypesKeys(newConceptModelAggregates);

            //-------
            // Handle Level 2 PRE SAVE
            //-------

            // populate keys for Enumerations (Level 2)
            await PopulateEnumerationsKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Enumerations (Level 2)
            EnumerationRepository.IdentifyItemsPerAction(
                conceptModel_Enumerations_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations),
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToAdd,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Enumeration> conceptModel_Enumerations_ItemsToRemove);

            // perform additions and updates for Enumerations (Level 2)
            EnumerationRepository.AddSterilisedRange(conceptModel_Enumerations_ItemsToAdd);
            await EnumerationRepository.UpdateSterilisedRangeAsync(conceptModel_Enumerations_ItemsToUpdate1);

            //-------
            // Save Level 2
            //-------

            // save the changes to Level 2 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 2 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 2 items will now have unique keys.
            // ensure newly allocated keys are populated
            await PopulateEnumerationsKeysAsync(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 2 items to child objects
            PropagateEnumerationsKeys(newConceptModelAggregates);

            //-------
            // Handle Level 3 PRE SAVE
            //-------

            // populate keys for Enumerations.EnumeratedValues (Level 3)
            await PopulateEnumerations_EnumeratedValuesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.IdentifyItemsPerAction(
                conceptModel_Enumerations_EnumeratedValues_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Enumerations != null)
                    .SelectMany(conceptModel => conceptModel.Enumerations)
                    .Where(enumeration => enumeration.EnumeratedValues != null)
                    .SelectMany(enumeration => enumeration.EnumeratedValues),
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToAdd,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.EnumerationMember> conceptModel_Enumerations_EnumeratedValues_ItemsToRemove);

            // perform additions and updates for Enumerations.EnumeratedValues (Level 3)
            EnumerationMemberRepository.AddSterilisedRange(conceptModel_Enumerations_EnumeratedValues_ItemsToAdd);
            await EnumerationMemberRepository.UpdateSterilisedRangeAsync(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate1);

            // populate keys for Concepts (Level 3)
            await PopulateConceptsKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts (Level 3)
            ConceptRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts),
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToAdd,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Concept> conceptModel_Concepts_ItemsToRemove);

            // perform additions for Concepts (Level 3) (we'll handle updates later)
            await AddConceptsAsync(
                newConceptModelAggregates,
                conceptModel_Concepts_ItemsToAdd);

            //-------
            // Save Level 3
            //-------

            // save the changes to Level 3 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 3 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 3 items will now have unique keys.
            // ensure newly allocated keys are populated
            await PopulateConceptsKeysAsync(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 3 items to child objects
            PropagateConceptsKeys(newConceptModelAggregates);

            // perform updates for Concepts (Level 3)
            await ConceptRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_ItemsToUpdate1);

            // re-save the changes to Level 3 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 4 PRE SAVE
            //-------

            // populate keys for Concepts.Includes (Level 4)
            await PopulateConcepts_IncludesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Includes (Level 4)
            IncludeRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Includes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Includes != null)
                    .SelectMany(concept => concept.Includes),
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToAdd,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Include> conceptModel_Concepts_Includes_ItemsToRemove);

            // perform additions and updates for Concepts.Includes (Level 4)
            IncludeRepository.AddSterilisedRange(conceptModel_Concepts_Includes_ItemsToAdd);
            await IncludeRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_Includes_ItemsToUpdate1);

            // populate keys for Concepts.Qualifiers (Level 4)
            await PopulateConcepts_QualifiersKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Qualifiers (Level 4)
            QualifierRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Qualifiers_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Qualifiers != null)
                    .SelectMany(concept => concept.Qualifiers),
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToAdd,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.Qualifier> conceptModel_Concepts_Qualifiers_ItemsToRemove);

            // perform additions and updates for Concepts.Qualifiers (Level 4)
            QualifierRepository.AddSterilisedRange(conceptModel_Concepts_Qualifiers_ItemsToAdd);
            await QualifierRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_Qualifiers_ItemsToUpdate1);

            // populate keys for Concepts.PropertyFamilies (Level 4)
            await PopulateConcepts_PropertyFamiliesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_PropertyFamilies_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.PropertyFamilies != null)
                    .SelectMany(concept => concept.PropertyFamilies),
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptPropertyFamily> conceptModel_Concepts_PropertyFamilies_ItemsToRemove);

            // perform additions and updates for Concepts.PropertyFamilies (Level 4)
            ConceptPropertyFamilyRepository.AddSterilisedRange(conceptModel_Concepts_PropertyFamilies_ItemsToAdd);
            await ConceptPropertyFamilyRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate1);

            // populate keys for Concepts.UniqueKeys (Level 4)
            await PopulateConcepts_UniqueKeysKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_UniqueKeys_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys),
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptUniqueKey> conceptModel_Concepts_UniqueKeys_ItemsToRemove);

            // perform additions and updates for Concepts.UniqueKeys (Level 4)
            ConceptUniqueKeyRepository.AddSterilisedRange(conceptModel_Concepts_UniqueKeys_ItemsToAdd);
            await ConceptUniqueKeyRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_UniqueKeys_ItemsToUpdate1);

            // populate keys for Concepts.SubTypes (Level 4)
            await PopulateConcepts_SubTypesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_SubTypes_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes),
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptSubType> conceptModel_Concepts_SubTypes_ItemsToRemove);

            // perform additions and updates for Concepts.SubTypes (Level 4)
            ConceptSubTypeRepository.AddSterilisedRange(conceptModel_Concepts_SubTypes_ItemsToAdd);
            await ConceptSubTypeRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_SubTypes_ItemsToUpdate1);

            //-------
            // Save Level 4
            //-------

            // save the changes to Level 4 objects
            await DbUnitOfWork.SaveChangesAsync();

            //-------
            // Handle Level 4 POST SAVE
            //-------

            /*
            // the act of saving means all newly added Level 4 items will now have unique keys.
            // ensure newly allocated keys are populated
            await PopulateConcepts_PropertyFamiliesKeysAsync(newConceptModelAggregates);
            await PopulateConcepts_UniqueKeysKeysAsync(newConceptModelAggregates);
            await PopulateConcepts_SubTypesKeysAsync(newConceptModelAggregates);
            */

            // propagate newly allocated keys of Level 4 items to child objects
            PropagateConcepts_PropertyFamiliesKeys(newConceptModelAggregates);
            PropagateConcepts_UniqueKeysKeys(newConceptModelAggregates);
            PropagateConcepts_SubTypesKeys(newConceptModelAggregates);

            //-------
            // Handle Level 5 PRE SAVE
            //-------

            // populate keys for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            await PopulateConcepts_UniqueKeys_PropertyFamilyRefsKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.UniqueKeys != null)
                    .SelectMany(concept => concept.UniqueKeys)
                    .Where(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs != null)
                    .SelectMany(conceptUniqueKey => conceptUniqueKey.PropertyFamilyRefs),
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptUniqueKeyPropertyFamilyRef> conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToRemove);

            // perform additions and updates for Concepts.UniqueKeys.PropertyFamilyRefs (Level 5)
            ConceptUniqueKeyPropertyFamilyRefRepository.AddSterilisedRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToAdd);
            await ConceptUniqueKeyPropertyFamilyRefRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate1);

            // populate keys for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            await PopulateConcepts_SubTypes_PropertyFamilyRefsKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.SubTypes != null)
                    .SelectMany(concept => concept.SubTypes)
                    .Where(conceptSubType => conceptSubType.PropertyFamilyRefs != null)
                    .SelectMany(conceptSubType => conceptSubType.PropertyFamilyRefs),
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptSubTypePropertyFamilyRef> conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToRemove);

            // perform additions and updates for Concepts.SubTypes.PropertyFamilyRefs (Level 5)
            ConceptSubTypePropertyFamilyRefRepository.AddSterilisedRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToAdd);
            await ConceptSubTypePropertyFamilyRefRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate1);

            // populate keys for Concepts.Properties (Level 5)
            await PopulateConcepts_PropertiesKeysAsync(newConceptModelAggregates);

            // identify items to add, update and remove for Concepts.Properties (Level 5)
            ConceptRefRepository.IdentifyItemsPerAction(
                conceptModel_Concepts_Properties_ItemsOld,
                newConceptModelAggregates
                    .Where(conceptModel => conceptModel.Concepts != null)
                    .SelectMany(conceptModel => conceptModel.Concepts)
                    .Where(concept => concept.Properties != null)
                    .SelectMany(concept => concept.Properties),
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToAdd,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToUpdate1,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToUpdate2,
                out IEnumerable<BlueprintModels.ConceptRef> conceptModel_Concepts_Properties_ItemsToRemove);

            // perform additions and updates for Concepts.Properties (Level 5)
            ConceptRefRepository.AddSterilisedRange(conceptModel_Concepts_Properties_ItemsToAdd);
            await ConceptRefRepository.UpdateSterilisedRangeAsync(conceptModel_Concepts_Properties_ItemsToUpdate1);

            //-------
            // Save Level 5
            //-------

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            //-------
            // Perform removals and a second round of updates
            //-------

            // now perform removals and a second round of updates working from the bottom up
            // Level 5

            if (conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_UniqueKeys_PropertyFamilyRefs that require further updates (Level 5)
                await ConceptUniqueKeyPropertyFamilyRefRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
                await ConceptUniqueKeyPropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
                // and perform the updates
                await ConceptUniqueKeyPropertyFamilyRefRepository.UpdateRangeAsync(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToUpdate2);
            }
            ConceptUniqueKeyPropertyFamilyRefRepository.RemoveRange(conceptModel_Concepts_UniqueKeys_PropertyFamilyRefs_ItemsToRemove);

            if (conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_SubTypes_PropertyFamilyRefs that require further updates (Level 5)
                await ConceptSubTypePropertyFamilyRefRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
                await ConceptSubTypePropertyFamilyRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
                // and perform the updates
                await ConceptSubTypePropertyFamilyRefRepository.UpdateRangeAsync(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToUpdate2);
            }
            ConceptSubTypePropertyFamilyRefRepository.RemoveRange(conceptModel_Concepts_SubTypes_PropertyFamilyRefs_ItemsToRemove);

            if (conceptModel_Concepts_Properties_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Properties that require further updates (Level 5)
                await ConceptRefRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_Properties_ItemsToUpdate2);
                await ConceptRefRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_Properties_ItemsToUpdate2);
                // and perform the updates
                await ConceptRefRepository.UpdateRangeAsync(conceptModel_Concepts_Properties_ItemsToUpdate2);
            }
            ConceptRefRepository.RemoveRange(conceptModel_Concepts_Properties_ItemsToRemove);

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 4

            if (conceptModel_Concepts_Includes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Includes that require further updates (Level 4)
                await IncludeRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_Includes_ItemsToUpdate2);
                await IncludeRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_Includes_ItemsToUpdate2);
                // and perform the updates
                await IncludeRepository.UpdateRangeAsync(conceptModel_Concepts_Includes_ItemsToUpdate2);
            }
            IncludeRepository.RemoveRange(conceptModel_Concepts_Includes_ItemsToRemove);

            if (conceptModel_Concepts_Qualifiers_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_Qualifiers that require further updates (Level 4)
                await QualifierRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
                await QualifierRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
                // and perform the updates
                await QualifierRepository.UpdateRangeAsync(conceptModel_Concepts_Qualifiers_ItemsToUpdate2);
            }
            QualifierRepository.RemoveRange(conceptModel_Concepts_Qualifiers_ItemsToRemove);

            if (conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_PropertyFamilies that require further updates (Level 4)
                await ConceptPropertyFamilyRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
                await ConceptPropertyFamilyRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
                // and perform the updates
                await ConceptPropertyFamilyRepository.UpdateRangeAsync(conceptModel_Concepts_PropertyFamilies_ItemsToUpdate2);
            }
            ConceptPropertyFamilyRepository.RemoveRange(conceptModel_Concepts_PropertyFamilies_ItemsToRemove);

            if (conceptModel_Concepts_UniqueKeys_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_UniqueKeys that require further updates (Level 4)
                await ConceptUniqueKeyRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
                await ConceptUniqueKeyRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
                // and perform the updates
                await ConceptUniqueKeyRepository.UpdateRangeAsync(conceptModel_Concepts_UniqueKeys_ItemsToUpdate2);
            }
            ConceptUniqueKeyRepository.RemoveRange(conceptModel_Concepts_UniqueKeys_ItemsToRemove);

            if (conceptModel_Concepts_SubTypes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts_SubTypes that require further updates (Level 4)
                await ConceptSubTypeRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
                await ConceptSubTypeRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
                // and perform the updates
                await ConceptSubTypeRepository.UpdateRangeAsync(conceptModel_Concepts_SubTypes_ItemsToUpdate2);
            }
            ConceptSubTypeRepository.RemoveRange(conceptModel_Concepts_SubTypes_ItemsToRemove);

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 3

            if (conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Enumerations_EnumeratedValues that require further updates (Level 3)
                await EnumerationMemberRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
                await EnumerationMemberRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
                // and perform the updates
                await EnumerationMemberRepository.UpdateRangeAsync(conceptModel_Enumerations_EnumeratedValues_ItemsToUpdate2);
            }
            EnumerationMemberRepository.RemoveRange(conceptModel_Enumerations_EnumeratedValues_ItemsToRemove);

            if (conceptModel_Concepts_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Concepts that require further updates (Level 3)
                await ConceptRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Concepts_ItemsToUpdate2);
                await ConceptRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Concepts_ItemsToUpdate2);
                // and perform the updates
                await ConceptRepository.UpdateRangeAsync(conceptModel_Concepts_ItemsToUpdate2);
            }
            ConceptRepository.RemoveRange(conceptModel_Concepts_ItemsToRemove);

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 2

            if (conceptModel_Enumerations_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for Enumerations that require further updates (Level 2)
                await EnumerationRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_Enumerations_ItemsToUpdate2);
                await EnumerationRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_Enumerations_ItemsToUpdate2);
                // and perform the updates
                await EnumerationRepository.UpdateRangeAsync(conceptModel_Enumerations_ItemsToUpdate2);
            }
            EnumerationRepository.RemoveRange(conceptModel_Enumerations_ItemsToRemove);

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 1

            if (conceptModel_DataTypes_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for DataTypes that require further updates (Level 1)
                await DataTypeRepository.PopulateForeignKeyValuesFromParentsAsync(conceptModel_DataTypes_ItemsToUpdate2);
                await DataTypeRepository.PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_DataTypes_ItemsToUpdate2);
                // and perform the updates
                await DataTypeRepository.UpdateRangeAsync(conceptModel_DataTypes_ItemsToUpdate2);
            }
            DataTypeRepository.RemoveRange(conceptModel_DataTypes_ItemsToRemove);

            // save changes...
            await DbUnitOfWork.SaveChangesAsync();

            // ...and clear the cache so that entities are no longer tracked
            DbUnitOfWork.ClearCache();

            // Level 0

            if (conceptModel_ItemsToUpdate2.Count() > 0)
            {
                // populate keys for ConceptModel (Aggregate Root)
                await PopulateForeignKeyValuesFromParentsAsync(conceptModel_ItemsToUpdate2);
                await PopulateMissingPrimaryKeysIfKnownAsync(conceptModel_ItemsToUpdate2);
                // and perform the updates
                await UpdateRangeAsync(conceptModel_ItemsToUpdate2);
            }
            RemoveRange(conceptModel_ItemsToRemove);

            //-------
            // Save removals and second round of updates
            //-------

            // save changes
            await DbUnitOfWork.SaveChangesAsync();
        }

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptModel
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptModel conceptModel)
        {
            return new object[] { conceptModel.ConceptModelId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptModel ToDbEntity(BlueprintModels.ConceptModel blueprintObj)
        {
            return (DbEntities.ConceptModel)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptModel),
                typeof(DbEntities.ConceptModel));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptModel> ToDbEntities(IEnumerable<BlueprintModels.ConceptModel> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptModel>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptModel>),
                typeof(IEnumerable<DbEntities.ConceptModel>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptModel"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptModel ToBlueprintObject(DbEntities.ConceptModel conceptModel)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptModel result = (BlueprintModels.ConceptModel)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptModel,
                typeof(DbEntities.ConceptModel),
                typeof(BlueprintModels.ConceptModel));

            // sort nested objects
            BlueprintUnitOfWork.ConceptModels.SortNestedObjects(new List<BlueprintModels.ConceptModel> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptModel> ToBlueprintObjects(IEnumerable<DbEntities.ConceptModel> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptModel> result = (IEnumerable<BlueprintModels.ConceptModel>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptModel>),
                typeof(IEnumerable<BlueprintModels.ConceptModel>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptModels.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptModel> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptModel>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptModel> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptModel> result = (IEnumerable<BlueprintModels.ConceptModel>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptModel, BlueprintModels.ConceptModel>>),
                typeof(IEnumerable<BlueprintModels.ConceptModel>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptModels.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.ConceptModel GetAggregateByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];

            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                DbUnitOfWork.ConceptModelAggregates.GetByModelName(
                modelName);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the aggregate that has the supplied business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptModel> GetAggregateByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];

            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                await DbUnitOfWork.ConceptModelAggregates.GetByModelNameAsync(
                modelName);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.ConceptModel GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            return GetByModelName(
                modelName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptModel> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            return await GetByModelNameAsync(
                modelName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptModel> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptModel conceptModel in items)
            {
                foreach (BlueprintModels.DataType dataType in conceptModel.DataTypes)
                {
                    dataType.ModelName = conceptModel.ModelName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.DataTypes.CopyLogicalBusinessKeysToNestedObjects(conceptModel.DataTypes, true);
                }
                foreach (BlueprintModels.Enumeration enumeration in conceptModel.Enumerations)
                {
                    enumeration.ModelName = conceptModel.ModelName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Enumerations.CopyLogicalBusinessKeysToNestedObjects(conceptModel.Enumerations, true);
                }
                foreach (BlueprintModels.Concept concept in conceptModel.Concepts)
                {
                    concept.ModelName = conceptModel.ModelName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Concepts.CopyLogicalBusinessKeysToNestedObjects(conceptModel.Concepts, true);
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a conceptModel to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptModel, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + (e.ModelName != null ? e.ModelName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptModel, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptModelId == default || e.ConceptModelId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptModel fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptModel> toObjects)
        {
            foreach (BlueprintModels.ConceptModel obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptModelId = fromBlueprintObj.ConceptModelId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptModel> items)
        {
            // nothing to do
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptModel> items)
        {
            // nothing to do
            await Task.CompletedTask;
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptModel> items)
        {
            foreach (BlueprintModels.ConceptModel item in items)
            {
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = DbUnitOfWork.ConceptModels.GetConceptModelIdByModelName(
                            item.ModelName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptModel> items)
        {
            foreach (BlueprintModels.ConceptModel item in items)
            {
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = await DbUnitOfWork.ConceptModels.GetConceptModelIdByModelNameAsync(
                            item.ModelName);
                    }
                }
            }
        }

        /// <summary>
        /// Renumbers nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void RenumberNestedObjects(
            IEnumerable<BlueprintModels.ConceptModel> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptModel conceptModel in items)
            {
                if (recurse)
                {
                    BlueprintUnitOfWork.DataTypes.RenumberNestedObjects(conceptModel.DataTypes, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Enumerations.RenumberNestedObjects(conceptModel.Enumerations, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Concepts.RenumberNestedObjects(conceptModel.Concepts, true);
                }
            }
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.ConceptModel> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.ConceptModel conceptModel in items
                .Where(item => item != null))
            {
                if (recurse)
                {
                    BlueprintUnitOfWork.DataTypes.SortNestedObjects(conceptModel.DataTypes, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Enumerations.SortNestedObjects(conceptModel.Enumerations, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Concepts.SortNestedObjects(conceptModel.Concepts, true);
                }
            }
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetByConceptModelId(int conceptModelId)
        {
            // get the rich entity
            DbEntities.ConceptModel conceptModel =
                DbUnitOfWork.ConceptModels.GetRichEntityByConceptModelId(
                    conceptModelId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetByConceptModelIdAsync(int conceptModelId)
        {
            // get the rich entity
            DbEntities.ConceptModel conceptModel =
                await DbUnitOfWork.ConceptModels.GetRichEntityByConceptModelIdAsync(
                    conceptModelId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetAggregateByConceptModelId(int conceptModelId)
        {
            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                DbUnitOfWork.ConceptModels.GetAggregateByConceptModelId(
                    conceptModelId);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ConceptModelId
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetAggregateByConceptModelIdAsync(int conceptModelId)
        {
            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                await DbUnitOfWork.ConceptModels.GetAggregateByConceptModelIdAsync(
                    conceptModelId);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetByModelName(string modelName)
        {
            // get the rich entity
            DbEntities.ConceptModel conceptModel =
                DbUnitOfWork.ConceptModels.GetRichEntityByModelName(
                    modelName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetByModelNameAsync(string modelName)
        {
            // get the rich entity
            DbEntities.ConceptModel conceptModel =
                await DbUnitOfWork.ConceptModels.GetRichEntityByModelNameAsync(
                    modelName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptModel GetAggregateByModelName(string modelName)
        {
            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                DbUnitOfWork.ConceptModels.GetAggregateByModelName(
                    modelName);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        /// <summary>
        /// Gets the unique ConceptModel aggregate that is identified by the specified ModelName
        /// </summary>
        /// <param name="modelName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptModel> GetAggregateByModelNameAsync(string modelName)
        {
            // get the aggregate
            DbEntities.ConceptModel conceptModel =
                await DbUnitOfWork.ConceptModels.GetAggregateByModelNameAsync(
                    modelName);

            // transform the aggregate and return the result
            return ToBlueprintObject(conceptModel);
        }

        #endregion
    }
}

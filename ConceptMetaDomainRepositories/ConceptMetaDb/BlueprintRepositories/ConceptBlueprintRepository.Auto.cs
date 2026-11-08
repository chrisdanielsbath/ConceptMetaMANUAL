/****************************
 * ConceptBlueprintRepository.Auto.cs
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
    /// Repository class for the <see cref="BlueprintModels.Concept" /> entity
    /// </summary>
    public partial class ConceptBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.Concept, DbEntities.Concept, IConceptMetaDbUnitOfWork>,
        IConceptBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.Concept> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified concept
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.Concept concept)
        {
            return new object[] { concept.ConceptId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.Concept ToDbEntity(BlueprintModels.Concept blueprintObj)
        {
            return (DbEntities.Concept)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.Concept),
                typeof(DbEntities.Concept));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.Concept> ToDbEntities(IEnumerable<BlueprintModels.Concept> blueprintObjects)
        {
            return (IEnumerable<DbEntities.Concept>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Concept>),
                typeof(IEnumerable<DbEntities.Concept>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="concept"></param>
        /// <returns></returns>
        protected override BlueprintModels.Concept ToBlueprintObject(DbEntities.Concept concept)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.Concept result = (BlueprintModels.Concept)BlueprintUnitOfWork.FromEntityMapper.Map(
                concept,
                typeof(DbEntities.Concept),
                typeof(BlueprintModels.Concept));

            // sort nested objects
            BlueprintUnitOfWork.Concepts.SortNestedObjects(new List<BlueprintModels.Concept> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Concept> ToBlueprintObjects(IEnumerable<DbEntities.Concept> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Concept> result = (IEnumerable<BlueprintModels.Concept>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.Concept>),
                typeof(IEnumerable<BlueprintModels.Concept>));

            // sort nested objects
            BlueprintUnitOfWork.Concepts.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.Concept> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.Concept>),
                typeof(IEnumerable<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.Concept> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.Concept> result = (IEnumerable<BlueprintModels.Concept>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.Concept, BlueprintModels.Concept>>),
                typeof(IEnumerable<BlueprintModels.Concept>));

            // sort nested objects
            BlueprintUnitOfWork.Concepts.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        #endregion

        #region Methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override BlueprintModels.Concept GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            return GetByModelNameConceptName(
                modelName,
                conceptName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.Concept> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            return await GetByModelNameConceptNameAsync(
                modelName,
                conceptName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.Concept> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.Concept concept in items)
            {
                foreach (BlueprintModels.Include include in concept.Includes)
                {
                    include.ModelName = concept.ModelName;
                    include.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Includes.CopyLogicalBusinessKeysToNestedObjects(concept.Includes, true);
                }
                foreach (BlueprintModels.Qualifier qualifier in concept.Qualifiers)
                {
                    qualifier.ModelName = concept.ModelName;
                    qualifier.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Qualifiers.CopyLogicalBusinessKeysToNestedObjects(concept.Qualifiers, true);
                }
                foreach (BlueprintModels.ConceptPropertyFamily propertyFamily in concept.PropertyFamilies)
                {
                    propertyFamily.ModelName = concept.ModelName;
                    propertyFamily.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptPropertyFamilies.CopyLogicalBusinessKeysToNestedObjects(concept.PropertyFamilies, true);
                }
                foreach (BlueprintModels.ConceptUniqueKey uniqueKey in concept.UniqueKeys)
                {
                    uniqueKey.ModelName = concept.ModelName;
                    uniqueKey.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeys.CopyLogicalBusinessKeysToNestedObjects(concept.UniqueKeys, true);
                }
                foreach (BlueprintModels.ConceptSubType subType in concept.SubTypes)
                {
                    subType.ModelName = concept.ModelName;
                    subType.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypes.CopyLogicalBusinessKeysToNestedObjects(concept.SubTypes, true);
                }
                foreach (BlueprintModels.ConceptRef property in concept.Properties)
                {
                    property.ModelName = concept.ModelName;
                    property.ConceptName = concept.ConceptName;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptRefs.CopyLogicalBusinessKeysToNestedObjects(concept.Properties, true);
                }
            }
        }

        /// <summary>
        /// Gets a function that maps a concept to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Concept, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptModelId.ToString() + "|"
                + (e.ConceptName != null ? e.ConceptName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.Concept, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptId == default || e.ConceptId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.Concept fromBlueprintObj,
            IEnumerable<BlueprintModels.Concept> toObjects)
        {
            foreach (BlueprintModels.Concept obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptId = fromBlueprintObj.ConceptId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.Concept> items)
        {
            foreach (BlueprintModels.Concept item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = DbUnitOfWork.ConceptModels.GetConceptModelIdByModelName(
                            item.ModelName);
                    }
                }
                if (item.DataTypeId == default || item.DataTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.DataTypeName != default && item.DataTypeName != "")
                    {
                        item.DataTypeId = DbUnitOfWork.DataTypes.GetDataTypeIdByModelNameDataTypeName(
                            item.ModelName,
                            item.DataTypeName);
                    }
                }
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationName(
                            item.ModelName,
                            item.EnumerationName);
                    }
                }
                if (item.ReferencedConceptUniqueKeyId == default || item.ReferencedConceptUniqueKeyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ReferencedConceptName != default && item.ReferencedConceptName != ""
                        && item.ReferencedUniqueKeyName != default && item.ReferencedUniqueKeyName != "")
                    {
                        item.ReferencedConceptUniqueKeyId = DbUnitOfWork.ConceptUniqueKeys.GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyName(
                            item.ModelName,
                            item.ReferencedConceptName,
                            item.ReferencedUniqueKeyName);
                    }
                }
                if (item.SpecialisedConceptSubTypeId == default || item.SpecialisedConceptSubTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.SpecialisedConceptName != default && item.SpecialisedConceptName != ""
                        && item.SpecialisedSubTypeName != default && item.SpecialisedSubTypeName != "")
                    {
                        item.SpecialisedConceptSubTypeId = DbUnitOfWork.ConceptSubTypes.GetConceptSubTypeIdByModelNameConceptNameSubTypeName(
                            item.ModelName,
                            item.SpecialisedConceptName,
                            item.SpecialisedSubTypeName);
                    }
                }
                // populate recursive foreign key fields
                if (item.BasedOnConceptId == default || item.BasedOnConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.BasedOnConceptName != default && item.BasedOnConceptName != "")
                    {
                        item.BasedOnConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.BasedOnConceptName);
                    }
                }
                if (item.ReferencedConceptId == default || item.ReferencedConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ReferencedConceptName != default && item.ReferencedConceptName != "")
                    {
                        item.ReferencedConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.ReferencedConceptName);
                    }
                }
                if (item.SpecialisedConceptId == default || item.SpecialisedConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.SpecialisedConceptName != default && item.SpecialisedConceptName != "")
                    {
                        item.SpecialisedConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.SpecialisedConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.Concept> items)
        {
            foreach (BlueprintModels.Concept item in items)
            {
                // populate non-recursive foreign key fields
                if (item.ConceptModelId == default || item.ConceptModelId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != "")
                    {
                        item.ConceptModelId = await DbUnitOfWork.ConceptModels.GetConceptModelIdByModelNameAsync(
                            item.ModelName);
                    }
                }
                if (item.DataTypeId == default || item.DataTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.DataTypeName != default && item.DataTypeName != "")
                    {
                        item.DataTypeId = await DbUnitOfWork.DataTypes.GetDataTypeIdByModelNameDataTypeNameAsync(
                            item.ModelName,
                            item.DataTypeName);
                    }
                }
                if (item.EnumerationId == default || item.EnumerationId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.EnumerationName != default && item.EnumerationName != "")
                    {
                        item.EnumerationId = await DbUnitOfWork.Enumerations.GetEnumerationIdByModelNameEnumerationNameAsync(
                            item.ModelName,
                            item.EnumerationName);
                    }
                }
                if (item.ReferencedConceptUniqueKeyId == default || item.ReferencedConceptUniqueKeyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ReferencedConceptName != default && item.ReferencedConceptName != ""
                        && item.ReferencedUniqueKeyName != default && item.ReferencedUniqueKeyName != "")
                    {
                        item.ReferencedConceptUniqueKeyId = await DbUnitOfWork.ConceptUniqueKeys.GetConceptUniqueKeyIdByModelNameConceptNameUniqueKeyNameAsync(
                            item.ModelName,
                            item.ReferencedConceptName,
                            item.ReferencedUniqueKeyName);
                    }
                }
                if (item.SpecialisedConceptSubTypeId == default || item.SpecialisedConceptSubTypeId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.SpecialisedConceptName != default && item.SpecialisedConceptName != ""
                        && item.SpecialisedSubTypeName != default && item.SpecialisedSubTypeName != "")
                    {
                        item.SpecialisedConceptSubTypeId = await DbUnitOfWork.ConceptSubTypes.GetConceptSubTypeIdByModelNameConceptNameSubTypeNameAsync(
                            item.ModelName,
                            item.SpecialisedConceptName,
                            item.SpecialisedSubTypeName);
                    }
                }
                // populate recursive foreign key fields
                if (item.BasedOnConceptId == default || item.BasedOnConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.BasedOnConceptName != default && item.BasedOnConceptName != "")
                    {
                        item.BasedOnConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.BasedOnConceptName);
                    }
                }
                if (item.ReferencedConceptId == default || item.ReferencedConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ReferencedConceptName != default && item.ReferencedConceptName != "")
                    {
                        item.ReferencedConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.ReferencedConceptName);
                    }
                }
                if (item.SpecialisedConceptId == default || item.SpecialisedConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.SpecialisedConceptName != default && item.SpecialisedConceptName != "")
                    {
                        item.SpecialisedConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.SpecialisedConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.Concept> items)
        {
            foreach (BlueprintModels.Concept item in items)
            {
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptName(
                            item.ModelName,
                            item.ConceptName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.Concept> items)
        {
            foreach (BlueprintModels.Concept item in items)
            {
                if (item.ConceptId == default || item.ConceptId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != "")
                    {
                        item.ConceptId = await DbUnitOfWork.Concepts.GetConceptIdByModelNameConceptNameAsync(
                            item.ModelName,
                            item.ConceptName);
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
            IEnumerable<BlueprintModels.Concept> items,
            bool recurse = true)
        {
            int i;
            foreach (BlueprintModels.Concept concept in items)
            {
                i = 1;
                foreach (BlueprintModels.Include include in concept.Includes)
                {
                    include.SeqNo = i++;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Includes.RenumberNestedObjects(concept.Includes, true);
                }
                i = 1;
                foreach (BlueprintModels.Qualifier qualifier in concept.Qualifiers)
                {
                    qualifier.SeqNo = i++;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.Qualifiers.RenumberNestedObjects(concept.Qualifiers, true);
                }
                i = 1;
                foreach (BlueprintModels.ConceptPropertyFamily propertyFamily in concept.PropertyFamilies)
                {
                    propertyFamily.SeqNo = i++;
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptPropertyFamilies.RenumberNestedObjects(concept.PropertyFamilies, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeys.RenumberNestedObjects(concept.UniqueKeys, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypes.RenumberNestedObjects(concept.SubTypes, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptRefs.RenumberNestedObjects(concept.Properties, true);
                }
            }
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.Concept> items,
            bool recurse = true)
        {
            foreach (BlueprintModels.Concept concept in items
                .Where(item => item != null))
            {
                concept.Includes.Sort(new IncludeComparer());
                if (recurse)
                {
                    BlueprintUnitOfWork.Includes.SortNestedObjects(concept.Includes, true);
                }
                concept.Qualifiers.Sort(new QualifierComparer());
                if (recurse)
                {
                    BlueprintUnitOfWork.Qualifiers.SortNestedObjects(concept.Qualifiers, true);
                }
                concept.PropertyFamilies.Sort(new ConceptPropertyFamilyComparer());
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptPropertyFamilies.SortNestedObjects(concept.PropertyFamilies, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptUniqueKeys.SortNestedObjects(concept.UniqueKeys, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptSubTypes.SortNestedObjects(concept.SubTypes, true);
                }
                if (recurse)
                {
                    BlueprintUnitOfWork.ConceptRefs.SortNestedObjects(concept.Properties, true);
                }
            }
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public BlueprintModels.Concept GetByConceptId(int conceptId)
        {
            // get the rich entity
            DbEntities.Concept concept =
                DbUnitOfWork.Concepts.GetRichEntityByConceptId(
                    conceptId);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptId
        /// </summary>
        /// <param name="conceptId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Concept> GetByConceptIdAsync(int conceptId)
        {
            // get the rich entity
            DbEntities.Concept concept =
                await DbUnitOfWork.Concepts.GetRichEntityByConceptIdAsync(
                    conceptId);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public BlueprintModels.Concept GetByModelNameConceptName(
            string modelName,
            string conceptName)
        {
            // get the rich entity
            DbEntities.Concept concept =
                DbUnitOfWork.Concepts.GetRichEntityByModelNameConceptName(
                    modelName,
                    conceptName);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ModelName, ConceptName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Concept> GetByModelNameConceptNameAsync(
            string modelName,
            string conceptName)
        {
            // get the rich entity
            DbEntities.Concept concept =
                await DbUnitOfWork.Concepts.GetRichEntityByModelNameConceptNameAsync(
                    modelName,
                    conceptName);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public BlueprintModels.Concept GetByConceptModelIdConceptName(
            int conceptModelId,
            string conceptName)
        {
            // get the rich entity
            DbEntities.Concept concept =
                DbUnitOfWork.Concepts.GetRichEntityByConceptModelIdConceptName(
                    conceptModelId,
                    conceptName);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        /// <summary>
        /// Gets the unique Concept that is identified by the specified ConceptModelId, ConceptName
        /// </summary>
        /// <param name="conceptModelId"></param>
        /// <param name="conceptName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.Concept> GetByConceptModelIdConceptNameAsync(
            int conceptModelId,
            string conceptName)
        {
            // get the rich entity
            DbEntities.Concept concept =
                await DbUnitOfWork.Concepts.GetRichEntityByConceptModelIdConceptNameAsync(
                    conceptModelId,
                    conceptName);

            // transform the rich entity and return the result
            return ToBlueprintObject(concept);
        }

        #endregion
    }
}

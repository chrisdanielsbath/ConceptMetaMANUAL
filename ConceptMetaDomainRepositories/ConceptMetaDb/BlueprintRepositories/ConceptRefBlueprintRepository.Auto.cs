/****************************
 * ConceptRefBlueprintRepository.Auto.cs
 ****************************/
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DbEntities = ConceptMeta.ConceptMetaDb.Entities;
using BlueprintModels = ConceptMeta.Blueprint;
using ConceptMeta.Blueprint.Comparers;
using ConceptMeta.ConceptMetaDb.BlueprintRepositoryInterfaces;

namespace ConceptMeta.ConceptMetaDb.BlueprintRepositories
{
    /// <summary>
    /// Repository class for the <see cref="BlueprintModels.ConceptRef" /> entity
    /// </summary>
    public partial class ConceptRefBlueprintRepository
        : ConceptMetaDbBlueprintRepository<BlueprintModels.ConceptRef, DbEntities.ConceptRef, IConceptMetaDbUnitOfWork>,
        IConceptRefBlueprintRepository
    {

        #region Instance Properties
        private IConceptMetaDbUnitOfWork ConceptMetaDbUnitOfWork => DbUnitOfWork;

        #endregion

        #region Constructors
        public ConceptRefBlueprintRepository(
            IConceptMetaDbBlueprintUnitOfWork<IConceptMetaDbUnitOfWork> blueprintUnitOfWork,
            IConceptMetaDbRepository<DbEntities.ConceptRef> dbEntityRepository)
            : base (blueprintUnitOfWork, dbEntityRepository)
        {
        }

        #endregion

        #region Protected methods that must be implemented separately in each concrete class

        /// <summary>
        /// Gets the object array of primary key values that can be used to identify the specified conceptRef
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override object[] GetPrimaryKeyObjectArray(BlueprintModels.ConceptRef conceptRef)
        {
            return new object[] { conceptRef.ConceptRefId };
        }

        /// <summary>
        /// Converts a blueprint object to a database entity
        /// </summary>
        /// <param name="blueprintObj"></param>
        /// <returns></returns>
        protected override DbEntities.ConceptRef ToDbEntity(BlueprintModels.ConceptRef blueprintObj)
        {
            return (DbEntities.ConceptRef)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObj,
                typeof(BlueprintModels.ConceptRef),
                typeof(DbEntities.ConceptRef));
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of database entities
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<DbEntities.ConceptRef> ToDbEntities(IEnumerable<BlueprintModels.ConceptRef> blueprintObjects)
        {
            return (IEnumerable<DbEntities.ConceptRef>)BlueprintUnitOfWork.ToEntityMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptRef>),
                typeof(IEnumerable<DbEntities.ConceptRef>));
        }

        /// <summary>
        /// Applies mappings and sorting to convert a database entity to a blueprint object
        /// </summary>
        /// <param name="conceptRef"></param>
        /// <returns></returns>
        protected override BlueprintModels.ConceptRef ToBlueprintObject(DbEntities.ConceptRef conceptRef)
        {
            // map the supplied item to a blueprint object
            BlueprintModels.ConceptRef result = (BlueprintModels.ConceptRef)BlueprintUnitOfWork.FromEntityMapper.Map(
                conceptRef,
                typeof(DbEntities.ConceptRef),
                typeof(BlueprintModels.ConceptRef));

            // sort nested objects
            BlueprintUnitOfWork.ConceptRefs.SortNestedObjects(new List<BlueprintModels.ConceptRef> { result });

            // return the blueprint object
            return result;
        }

        /// <summary>
        /// Applies mappings and sorting to convert a set of database entities to a set of blueprint objects
        /// </summary>
        /// <param name="dbEntities"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptRef> ToBlueprintObjects(IEnumerable<DbEntities.ConceptRef> dbEntities)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptRef> result = (IEnumerable<BlueprintModels.ConceptRef>)BlueprintUnitOfWork.FromEntityMapper.Map(
                dbEntities,
                typeof(IEnumerable<DbEntities.ConceptRef>),
                typeof(IEnumerable<BlueprintModels.ConceptRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptRefs.SortNestedObjects(result);

            // return the set of blueprint objects
            return result;
        }

        /// <summary>
        /// Converts a set of blueprint objects to a set of entity/blueprint pairs
        /// </summary>
        /// <param name="blueprintObjects"></param>
        /// <returns></returns>
        protected override IEnumerable<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>> ToEntityBlueprintPairs(IEnumerable<BlueprintModels.ConceptRef> blueprintObjects)
        {
            // map the supplied items to entity/blueprint pairs
            return(IEnumerable<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>>)BlueprintUnitOfWork.ToEntityBlueprintPairMapper.Map(
                blueprintObjects,
                typeof(IEnumerable<BlueprintModels.ConceptRef>),
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>>));
        }

        /// <summary>
        /// Converts a set of entity/blueprint pairs to a set of blueprint objects
        /// </summary>
        /// <param name="entityBlueprintPairs"></param>
        /// <returns></returns>
        protected override IEnumerable<BlueprintModels.ConceptRef> ToBlueprintObjects(IEnumerable<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>> entityBlueprintPairs)
        {
            // map the supplied items to blueprint objects
            IEnumerable<BlueprintModels.ConceptRef> result = (IEnumerable<BlueprintModels.ConceptRef>)BlueprintUnitOfWork.FromEntityBlueprintPairMapper.Map(
                entityBlueprintPairs,
                typeof(IEnumerable<KeyValuePair<DbEntities.ConceptRef, BlueprintModels.ConceptRef>>),
                typeof(IEnumerable<BlueprintModels.ConceptRef>));

            // sort nested objects
            BlueprintUnitOfWork.ConceptRefs.SortNestedObjects(result);

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
        public override BlueprintModels.ConceptRef GetByBusinessKey(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string propertyName = (string)keyValues[2];
            return GetByModelNameConceptNamePropertyName(
                modelName,
                conceptName,
                propertyName
            );
        }

        /// <summary>
        /// Gets the unique entity that has the specified business key
        /// </summary>
        /// <param name="keyValues"></param>
        /// <returns></returns>
        public override async Task<BlueprintModels.ConceptRef> GetByBusinessKeyAsync(params object[] keyValues)
        {
            string modelName = (string)keyValues[0];
            string conceptName = (string)keyValues[1];
            string propertyName = (string)keyValues[2];
            return await GetByModelNameConceptNamePropertyNameAsync(
                modelName,
                conceptName,
                propertyName
            );
        }

        /// <summary>
        /// Copies logical business key values to nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void CopyLogicalBusinessKeysToNestedObjects(
            IEnumerable<BlueprintModels.ConceptRef> items,
            bool recurse = true)
        {
            // nothing to copy
        }

        /// <summary>
        /// Gets a function that maps a conceptRef to a string representation of its logical key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptRef, string> GetLogicalKeyFunction()
        {
            return (e => ""
                + e.ConceptId.ToString() + "|"
                + (e.PropertyName != null ? e.PropertyName.ToString() + "|" : "<null>|")
            );
        }

        /// <summary>
        /// Gets a predicate that identifies items without a primary key
        /// </summary>
        /// <returns></returns>
        public override Func<BlueprintModels.ConceptRef, bool> GetMissingPrimaryKeyPredicate()
        {
            return (e => 
                (e.ConceptRefId == default || e.ConceptRefId == default(int)));
        }

        /// <summary>
        /// Copies primary key values from a blueprint object to each object within a collection
        /// </summary>
        /// <param name="fromBlueprintObj">the blueprint object from which to copy the primary key</param>
        /// <param name="toObjects">the set of objects in which to set the primary key</param>
        public override void CopyPrimaryKeyValuesFromEntityToObjects(
            BlueprintModels.ConceptRef fromBlueprintObj,
            IEnumerable<BlueprintModels.ConceptRef> toObjects)
        {
            foreach (BlueprintModels.ConceptRef obj in toObjects)
            {
                // populate the primary key within the object
                obj.ConceptRefId = fromBlueprintObj.ConceptRefId;
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateForeignKeyValuesFromParents(IEnumerable<BlueprintModels.ConceptRef> items)
        {
            foreach (BlueprintModels.ConceptRef item in items)
            {
                // populate non-recursive foreign key fields
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
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyName(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates foreign key fields using business key values from parent objects
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateForeignKeyValuesFromParentsAsync(IEnumerable<BlueprintModels.ConceptRef> items)
        {
            foreach (BlueprintModels.ConceptRef item in items)
            {
                // populate non-recursive foreign key fields
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
                if (item.ConceptPropertyFamilyId == default || item.ConceptPropertyFamilyId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyFamilyName != default && item.PropertyFamilyName != "")
                    {
                        item.ConceptPropertyFamilyId = await DbUnitOfWork.ConceptPropertyFamilies.GetConceptPropertyFamilyIdByModelNameConceptNamePropertyFamilyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyFamilyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        public override void PopulateMissingPrimaryKeysIfKnown(IEnumerable<BlueprintModels.ConceptRef> items)
        {
            foreach (BlueprintModels.ConceptRef item in items)
            {
                if (item.ConceptRefId == default || item.ConceptRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyName != default && item.PropertyName != "")
                    {
                        item.ConceptRefId = DbUnitOfWork.ConceptRefs.GetConceptRefIdByModelNameConceptNamePropertyName(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyName);
                    }
                }
            }
        }

        /// <summary>
        /// Populates missing primary key fields where the values to use can be deduced using the logical key
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public override async Task PopulateMissingPrimaryKeysIfKnownAsync(IEnumerable<BlueprintModels.ConceptRef> items)
        {
            foreach (BlueprintModels.ConceptRef item in items)
            {
                if (item.ConceptRefId == default || item.ConceptRefId == default(int))
                {
                    if (item.ModelName != default && item.ModelName != ""
                        && item.ConceptName != default && item.ConceptName != ""
                        && item.PropertyName != default && item.PropertyName != "")
                    {
                        item.ConceptRefId = await DbUnitOfWork.ConceptRefs.GetConceptRefIdByModelNameConceptNamePropertyNameAsync(
                            item.ModelName,
                            item.ConceptName,
                            item.PropertyName);
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
            IEnumerable<BlueprintModels.ConceptRef> items,
            bool recurse = true)
        {
            // nothing to renumber
        }

        /// <summary>
        /// Sorts nested objects
        /// </summary>
        /// <param name="items"></param>
        /// <param name="recurse"></param>
        public override void SortNestedObjects(
            IEnumerable<BlueprintModels.ConceptRef> items,
            bool recurse = true)
        {
            // nothing to sort
        }

        #endregion

        #region Methods that find objects

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptRef GetByConceptRefId(int conceptRefId)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                DbUnitOfWork.ConceptRefs.GetRichEntityByConceptRefId(
                    conceptRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptRefId
        /// </summary>
        /// <param name="conceptRefId"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptRef> GetByConceptRefIdAsync(int conceptRefId)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                await DbUnitOfWork.ConceptRefs.GetRichEntityByConceptRefIdAsync(
                    conceptRefId);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptRef GetByModelNameConceptNamePropertyName(
            string modelName,
            string conceptName,
            string propertyName)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                DbUnitOfWork.ConceptRefs.GetRichEntityByModelNameConceptNamePropertyName(
                    modelName,
                    conceptName,
                    propertyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ModelName, ConceptName, PropertyName
        /// </summary>
        /// <param name="modelName"></param>
        /// <param name="conceptName"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptRef> GetByModelNameConceptNamePropertyNameAsync(
            string modelName,
            string conceptName,
            string propertyName)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                await DbUnitOfWork.ConceptRefs.GetRichEntityByModelNameConceptNamePropertyNameAsync(
                    modelName,
                    conceptName,
                    propertyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public BlueprintModels.ConceptRef GetByConceptIdPropertyName(
            int conceptId,
            string propertyName)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                DbUnitOfWork.ConceptRefs.GetRichEntityByConceptIdPropertyName(
                    conceptId,
                    propertyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        /// <summary>
        /// Gets the unique ConceptRef that is identified by the specified ConceptId, PropertyName
        /// </summary>
        /// <param name="conceptId"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public async Task<BlueprintModels.ConceptRef> GetByConceptIdPropertyNameAsync(
            int conceptId,
            string propertyName)
        {
            // get the rich entity
            DbEntities.ConceptRef conceptRef =
                await DbUnitOfWork.ConceptRefs.GetRichEntityByConceptIdPropertyNameAsync(
                    conceptId,
                    propertyName);

            // transform the rich entity and return the result
            return ToBlueprintObject(conceptRef);
        }

        #endregion
    }
}
